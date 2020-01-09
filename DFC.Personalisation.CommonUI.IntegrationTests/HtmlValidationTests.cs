using DFC.Personalisation.CommonUI.Documentation;
using DFC.Personalisation.CommonUI.Documentation.Controllers;
using DFC.Personalisation.CommonUI.IntegrationTests.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.IntegrationTests
{

    public class HtmlValidationTests 
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        public HtmlValidationTests()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        private static List<string> GetControllerActions(Type controllerType)
        {
            
            var ActionResults =
                controllerType.GetMethods().Where(t => t.Name != "Dispose" && !t.IsSpecialName &&
                                                                     t.DeclaringType.IsSubclassOf(typeof(ControllerBase)) && t.IsPublic && !t.IsStatic
                                                                     && t.ReturnType == typeof(IActionResult)).ToList();
            return ActionResults.Select(x => $"/{controllerType.Name.Replace("Controller","")}/"+x.Name).ToList();
        }

       [TestCaseSource(nameof(GetControllerActions), new object []{typeof(ComponentsController)})]
        public async Task WhenComponent_ThenTheReturnedHTMLShouldPassW3Validation(string endpoint)
        {
            var resp = await _client.GetAsync(endpoint);
            var responseString = await resp.Content.ReadAsStringAsync();

            var validationResponse = string.Empty;

            using (var validationClient = new HttpClient())
            {
                validationClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");

                var content = new StringContent(responseString, Encoding.UTF8, "text/html");

                var uri = new Uri("https://validator.w3.org/nu/?out=json");
                var response = await validationClient.PostAsync(uri, content);

                validationResponse = await response.Content.ReadAsStringAsync();
            }
            
            var result = JsonConvert.DeserializeObject<ValidationResult>(validationResponse);

            var errors = result.Messages.Where(x => x.SubType == SubType.Fatal).ToList();

            if (errors.Any())
            {
                var because =$"Endpoint {endpoint} has the following errors";
                because = errors.Aggregate(because, (current, error) => current + $"\n {error.Message}, on component {error.Extract}");
                errors.Any().Should().BeFalse(because);
            }
            else
            {
                TestContext.Out.Write($"{endpoint} : Html Validation Passed");
            }

        }
    }
}
