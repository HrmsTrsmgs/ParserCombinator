using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
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

        static Parser<char> doubleQuote => new CharParser('"');

        static Parser<char> collon => new CharParser(':');

        static Parser<string> @string = new WordParser(@"""a""");

        static Parser<int> number => ParserConverter.Create(new CharParser('1'), s => int.Parse(s.ToString()));


        static Parser<JSONObject> jsonObject =>
            ParserConverter.Create(
                SequenceParser.Create(
                    bracketOpen,
                    OptionalParser.Create(
                        SequenceParser.Create(
                            @string,
                            collon,
                            number)),
                    bracketClose),
                tuple => tuple.Item2.IsPresent ? new JSONObject { Pairs = { ["a"] = new JSONLiteral(tuple.Item2.Value.Item3.ToString(), LiteralType.Number) } } : new JSONObject());

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
    