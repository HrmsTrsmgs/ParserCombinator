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
        static IParser<string> Null => new WordParser("null", true);

        static IParser<char> bracketOpen => new CharParser('{');

        static IParser<char> bracketClose => new CharParser('}');

        static IParser<char> doubleQuote => new CharParser('"');

        static IParser<char> collon => new CharParser(':');

        static IParser<string> @string = new WordParser(@"""a""");

        static IParser<int> number =>new ParserConverter<char, int>(new CharParser('1'), s => int.Parse(s.ToString()));


        static IParser<JSONObject> jsonObject =>
            ParserConverter.Create(
                SequenceParser.Create(
                    bracketOpen,
                    OptionalParser.Create(
                        SequenceParser.Create(
                            @string,
                            collon,
                            number)),
                    bracketClose),
                tuple => tuple.Item2.IsPresent ? new JSONObject { Pairs = { [tuple.Item2.Value.Item1[1..^1]] = new JSONLiteral(tuple.Item2.Value.Item3.ToString(), LiteralType.Number) } } : new JSONObject());

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
    