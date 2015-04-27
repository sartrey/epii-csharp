using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EPII
{
    public class Macro : Table<string>
    {
        /// <summary>
        /// <para>load macro from xml</para>
        /// <para>path:{item}/{key}</para>
        /// </summary>
        public void LoadXML(XElement xml, string path = "item/key")
        {
            var parts = path.Split(
                new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in xml.Elements(parts[0])) {
                _Data.Add(x.Attribute(parts[1]).Value, x.Value);
            }
        }

        public bool HasMacro(string text)
        {
            return Regex.IsMatch(text, @"\?\([^\s\?\(\)]+\)");
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
    }
}