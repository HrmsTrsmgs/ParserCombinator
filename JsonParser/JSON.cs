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

        static IParser<char> BracketOpen => new CharParser('{');

        static IParser<char> BracketClose => new CharParser('}');

        static IParser<char> DoubleQuote => new CharParser('"');

        static IParser<char> Collon => new CharParser(':');

        static IParser<string> JString =>
            new ParserConverter<(char, string, char), string>(
                new SequenceParser<char, string, char>(
                    DoubleQuote,
                    new WordParser("a"),
                    DoubleQuote),
                t => t.Item2);

        

        static IParser<int> JNumber =>
            new ParserConverter<(Optional<char>, char), int>(
                new SequenceParser<Optional<char>, char>(
                    new OptionalParser<char>(new CharParser('-')),
                    new CharParser('1')),
                tuple => int.Parse($"{(tuple.Item1.IsPresent ? "-" : "")}{tuple.Item2}"));


        static IParser<JSONObject> JObject =>
            new ParserConverter<(char, Optional<(string, char, int)>, char), JSONObject>(
                new SequenceParser<char, Optional<(string, char, int)>, char>(
                    BracketOpen,
                    new OptionalParser<(string, char, int)>(
                        new SequenceParser<string, char, int>(
                            JString,
                            Collon,
                            JNumber)),
                    BracketClose),
                tuple => tuple.Item2.IsPresent ?
                    new JSONObject { Pairs = { [tuple.Item2.Value.Item1] = new JSONLiteral(tuple.Item2.Value.Item3.ToString(), LiteralType.Number) } } 
                    : new JSONObject());

        public static async Task<JSONObject> ParseAsync(string text)
        {
            var (isSuccess, _, parsed) = await JObject.ParseAsync(new Cursol(text));
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
    