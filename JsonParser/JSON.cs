using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.Parser
{
    
    public class JSON
    {
        static Parser<string> Null => new WordParser("null", true);

        static Parser<char> bracketOpen => new CharParser('{');

        static Parser<char> bracketClose => new CharParser('{');

        static Parser<(char, char)> jsonObject => SequenceParser.Create(bracketOpen, bracketClose);

        public static async Task<JSONObject> ParseAsync(string parsed)
        {
            var (isSuccess, _, _) = await jsonObject.ParseAsync(new Cursol(parsed));
            return new JSONObject();
        }
    }
}
    