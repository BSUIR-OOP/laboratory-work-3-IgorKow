using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3.Classes
{
    public class JsonSerializator : IJsonSerializator
    {
        public TeacherstList Deserialize(string json)
        {
            TeachersList res = new TeachersList();
            json = Regex.Replace(json, "[]['\n\t,\":]", string.Empty);
            string[] stream = json.Split('{', '}');
            foreach (string s in stream)
            {
                if (!s.Equals(""))
                {
                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    string[] token = s.Split(' ');
                    for (int i = 0; i < token.Length; i += 2)
                    {
                        tokens.Add(token[i], token[i + 1]);
                    }
                    Type type = Type.GetType(tokens["type"]);
                    Teachers c = (Teachers)Activator.CreateInstance(type);
                    foreach (var f in type.GetProperties())
                    {
                        if (f.PropertyType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    foreach (var f in type.GetFields())
                    {
                        if (f.FieldType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    res.Add(c);
                }
            }
            return res;
        }

        public string Serialize(TeachersList teachers)
        {
            int cnt = 0;
            string res = "[";
            foreach (Teachers teach in teachers)
            {
                cnt++;
                res += "\n\t{\n";
                Type type = teach.GetType();
                res += $"\t\t\"type\": \"{type.FullName}\",\n ";
                foreach (var f in type.GetFields())
                {
                    if (f.FieldType.Equals(typeof(string)))
                        res += $"\t\t\"{f.Name}\": \"{f.GetValue(teach)}\", \n";
                    else
                        res += $"\t\t\"{f.Name}\": {f.GetValue(teach)}, \n";
                }
                foreach (var f in type.GetProperties())
                {
                    if (f.PropertyType.Equals(typeof(string)))
                        res += $"\t\t\"{f.Name}\": \"{f.GetValue(teach)}\", \n";
                    else
                        res += $"\t\t\"{f.Name}\": {f.GetValue(teach)}, \n";
                }
                res = res.Remove(res.LastIndexOf(',')) + "\n";
                res += "\t},";
            }
            res = res.Remove(res.LastIndexOf(',')) + "\n";
            res += "]";
            return res;
        }
    }
}
