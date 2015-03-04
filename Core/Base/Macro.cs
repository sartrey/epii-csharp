using System.Text.RegularExpressions;

namespace EPII
{
    public class Macro : Table<string>
    {
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