using System;
using System.Xml.Linq;

namespace EPII
{
    public class Macro : Table<string>
    {
        public void Add(XElement xml)
        {
            var xmls_items = xml.Elements("item");
            foreach (var x in xmls_items) {
                var key = x.Attribute("key").Value;
                var value = Restore(x.Value);
                var xml_fix = x.Attribute("fix");
                if (xml_fix != null)
                    value = Fix(value, xml_fix.Value);
                _Data[key] = value;
            }
        }

        public void Add(string key, string value, string fix = null)
        {
            _Data[key] = (fix == null ? value : Fix(value, fix));
        }

        public bool HasMacro(string text)
        {
            return (text.IndexOf("?") >= 0);
        }

        public void Optimize()
        {
            foreach (var key in _Data.Keys)
                _Data[key] = Restore(_Data[key]);
        }

        public string Restore(string text)
        {
            var result = text;
            while (HasMacro(result)) {
                bool dead = true;
                foreach (var kvp in _Data) {
                    var replace = "?(" + kvp.Key + ")";
                    if (result.Contains(replace))
                        dead = false;
                    result = result.Replace(replace, kvp.Value);
                }
                if (dead) break;
            }
            return result;
        }

        public string Fix(string text, string fix)
        {
            if (fix == "uri") {
                var parts = text.Split(
                    new string[] { ".." },
                    StringSplitOptions.RemoveEmptyEntries);
                var result = "";
                for (int i = 0; i < parts.Length - 1; i++) {
                    var pos = parts[i].LastIndexOf('\\');
                    if (pos == parts[i].Length - 1)
                        pos = parts[i].LastIndexOf('\\', pos - 1);
                    result += parts[i].Substring(0, pos);
                }
                result += parts[parts.Length - 1];
                return result;
            }
            throw new ArgumentException();
        }

        public XElement ToXML(string root = "macro")
        {
            var xml = new XElement(root);
            foreach (var kvp in _Data) {
                var x = new XElement("item",
                    new XAttribute("key", kvp.Key),
                    kvp.Value);
                xml.Add(x);
            }
            return xml;
        }
    }
}