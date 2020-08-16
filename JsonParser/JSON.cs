using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.Parser
{
    
    public class JSON
    {
        static Parser<string> Null => new WordParser("null", true);

        static Parser<char> bracketOpen => new CharParser('{');

        static Parser<char> bracketClose => new CharParser('}');

        static Parser<JSONObject> jsonObject =>
            ParserConverter.Create(
                SequenceParser.Create(bracketOpen, bracketClose),
                _=> new JSONObject());

        public static async Task<JSONObject> ParseAsync(string text)
        {
            var (isSuccess, _, parsed) = await jsonObject.ParseAsync(new Cursol(text));
            if(isSuccess)
            {
                return parsed;
            }
            else
            {
                return null;
            }
        }
    }
}
    