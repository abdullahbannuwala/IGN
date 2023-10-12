using System;
using System.Collections;
using System.Text;
using System.Reflection;

public class ClassHelper
{
    public static string GetPropertiesAndValues(object obj, int level = 0)
    {
        if (obj == null)
            return "null";

        StringBuilder result = new StringBuilder();
        string indent = new string(' ', level * 4);

        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();

        foreach (var property in properties)
        {
            // Check for indexed properties
            if (property.GetIndexParameters().Length == 0)
            {
                object propValue = property.GetValue(obj);
                if (propValue is IEnumerable enumerable && !(propValue is string))
                {
                    result.AppendLine($"{indent}{property.Name}:");
                    int index = 0;
                    foreach (var item in enumerable)
                    {
                        result.AppendLine($"{indent}    [{index}] {GetPropertiesAndValues(item, level + 1)}");
                        index++;
                    }
                }
                else
                {
                    result.AppendLine($"{indent}{property.Name}: {propValue}");
                }
            }
            else
            {
                result.AppendLine($"{indent}{property.Name}: [Indexed property]");
            }
        }
        return result.ToString();
    }
}
