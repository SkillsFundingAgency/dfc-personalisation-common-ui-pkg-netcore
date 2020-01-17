using System;
using System.Collections.Generic;
using System.Reflection;

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
    }
    [Serializable]
    public class AutoPropException : Exception
    {
        public AutoPropException(string message) : base(message)
        {

        }
    }
}
