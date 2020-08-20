using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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

        static IParser<char> Dot => new CharParser('.');

        static IParser<char> Digit =>
            new OrParser<char>(
                new CharParser('1'),
                new CharParser('2'),
                new CharParser('3'),
                new CharParser('4'),
                new CharParser('5'),
                new CharParser('6'),
                new CharParser('7'),
                new CharParser('8'),
                new CharParser('9'),
                new CharParser('0'));

        static IParser<string> JString =>
            new ParserConverter<(char, string, char), string>(
                new SequenceParser<char, string, char>(
                    DoubleQuote,
                    new WordParser("a"),
                    DoubleQuote),
                t => t.Item2);

        static IParser<string> Digits =>
            new ParserConverter<IEnumerable<char>, string>(
                new OneOrMoreParser<char>(Digit),
                chars => new string(chars.ToArray()));

        static IParser<string> JFrac =
            new ParserConverter<(char, string), string>(
                new SequenceParser<char, string>(Dot, Digits),
                tuple => tuple.Item1.ToString() + tuple.Item2);

        static IParser<string> JInt =>
            new ParserConverter<(Optional<char>, string), string>(
                new SequenceParser<Optional<char>, string>(
                    new OptionalParser<char>(new CharParser('-')),
                    Digits),
                tuple => $"{(tuple.Item1.IsPresent ? "-" : "")}{tuple.Item2}");

        static IParser<JSONLiteral> JNumber =>
            new ParserConverter<(string, Optional<string>), JSONLiteral>(
                new SequenceParser<string, Optional<string>>(
                    JInt,
                    new OptionalParser<string>(JFrac)),
                tuple => 
                    new JSONLiteral(
                        tuple.Item1 + (tuple.Item2.IsPresent ? tuple.Item2.Value : ""), 
                        LiteralType.Number));

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
    