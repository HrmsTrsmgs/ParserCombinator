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

        

        static IParser<JSONLiteral> JNumber =>
            new ParserConverter<(Optional<char>, char), JSONLiteral>(
                new SequenceParser<Optional<char>, char>(
                    new OptionalParser<char>(new CharParser('-')),
                    new CharParser('1')),
                tuple => new JSONLiteral($"{(tuple.Item1.IsPresent ? "-" : "")}{tuple.Item2}", LiteralType.Number));

        static IParser<KeyValuePair<string, JSONLiteral>> JPair =>
            new ParserConverter<(string, char, JSONLiteral), KeyValuePair<string, JSONLiteral>>(
                new SequenceParser<string, char, JSONLiteral>(
                            JString,
                            Collon,
                            JNumber),
                tuple => new KeyValuePair<string, JSONLiteral>(tuple.Item1, tuple.Item3));

        static IParser<JSONObject> JObject =>
            new ParserConverter<(char, Optional<KeyValuePair<string, JSONLiteral>>, char), JSONObject>(
                new SequenceParser<char, Optional<KeyValuePair<string, JSONLiteral>>, char>(
                    BracketOpen,
                    new OptionalParser<KeyValuePair<string, JSONLiteral>>(JPair),
                    BracketClose),
                tuple => tuple.Item2.IsPresent ?
                    new JSONObject { Pairs = { [tuple.Item2.Value.Key] = tuple.Item2.Value.Value} } 
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
    