using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.ViewComponents
{
    public abstract class BaseViewComponent: ViewComponent
    {
        protected void SetProps(Dictionary<string,string> options)
        {
            foreach (var k in options.Keys)
            {
                var prop = this.GetType().GetProperty(k, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop != null)
                {
                    try
                    {
                        var val = options[k];
                        if (prop.PropertyType == typeof(bool))
                        {
                            prop.SetValue(this, Convert.ToBoolean(val));
                        }
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(this, Convert.ToInt32(val));
                        }
                        else
                        {
                            prop.SetValue(this, val);
                        }
                    }
                    catch
                    {
                        throw new Exception("Unable to Map property");
                    }
                }
            }
        }
    }
}
