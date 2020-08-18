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

        static IParser<string> Digits =>
            new ParserConverter<(char, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>), string>(
                new SequenceParser<char, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>, Optional<char>>(
                    Digit,
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit),
                    new OptionalParser<char>(Digit)),
            tuple => 
            tuple.Item1 
            + (tuple.Item2.IsPresent ? tuple.Item2.Value.ToString() : "") 
            + (tuple.Item3.IsPresent ? tuple.Item3.Value.ToString() : "")
            + (tuple.Item4.IsPresent ? tuple.Item4.Value.ToString() : "")
            + (tuple.Item5.IsPresent ? tuple.Item5.Value.ToString() : "")
            + (tuple.Item6.IsPresent ? tuple.Item6.Value.ToString() : "")
            + (tuple.Item7.IsPresent ? tuple.Item7.Value.ToString() : "")
            + (tuple.Item8.IsPresent ? tuple.Item8.Value.ToString() : "")
            + (tuple.Item9.IsPresent ? tuple.Item9.Value.ToString() : "")
            + (tuple.Item10.IsPresent ? tuple.Item10.Value.ToString() : ""));

        static IParser<JSONLiteral> JNumber =>
            new ParserConverter<(Optional<char>, string), JSONLiteral>(
                new SequenceParser<Optional<char>, string>(
                    new OptionalParser<char>(new CharParser('-')),
                    Digits),
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
    