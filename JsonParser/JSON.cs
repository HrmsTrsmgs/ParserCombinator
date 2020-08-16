using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.Parser
{

    public class JSON
    {
        public static Parser<string> Null => new WordParser("null", true);

        public static async Task<JSONObject> ParseAsync(string parsed)
        {
            return new JSONObject();
        }
    }
}
    