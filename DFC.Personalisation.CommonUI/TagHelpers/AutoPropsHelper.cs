using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DFC.Personalisation.CommonUI.TagHelpers
{
    public static class AutoPropsHelper
    {
        public static void SetProps(Dictionary<string, string> options, object ob)
        {
            foreach (var k in options.Keys)
            {
                var prop = ob.GetType().GetProperty(k, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop != null)
                {
                    try
                    {
                        var val = options[k];
                        if (prop.PropertyType == typeof(bool))
                        {
                            prop.SetValue(ob, Convert.ToBoolean(val));
                            continue;
                        }
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(ob, Convert.ToInt32(val));
                            continue;
                        }
                        else
                        {
                            prop.SetValue(ob, val);
                        }
                    }
                    catch
                    {
                        throw new AutoPropException("Unable to Map property");
                    }
                }
            }
        }

        public static string CombineClassProps(List<string> items)
        {
            var returnString = new StringBuilder();

            foreach (var item in items.Where(item => !string.IsNullOrEmpty(item)))
            {
                returnString.Append(string.IsNullOrEmpty(returnString.ToString()) ? item : $" {item}");
            }

            return returnString.ToString();
        }
    }
    [Serializable]
    public class AutoPropException : Exception
    {
        public AutoPropException(string message) : base(message)
        {

        }
    }
}
