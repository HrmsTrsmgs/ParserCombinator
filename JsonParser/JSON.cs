using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Marimo.Parser
{
    
    public class JSON
    {
        static IParser<char> WhiteSpace => new CharParser(' ');

        static IParser<char> BraceOpen => new CharParser('{');
        
        static IParser<char> BraceClose => new CharParser('}');

        static IParser<char> BracketOpen => new CharParser('[');

        static IParser<char> BracketClose => new CharParser(']');

        static IParser<char> DoubleQuote => new CharParser('"');

        static IParser<char> Collon => new CharParser(':');

        static IParser<char> Dot => new CharParser('.');

        static IParser<char> Plus => new CharParser('+');

        static IParser<char> Minus => new CharParser('-');

        static IParser<char> BackSlash => new CharParser('\\');

        static IParser<char> Comma => new CharParser(',');

        static IParser<char> BraceOpenSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                BraceOpen);
        static IParser<char> BraceCloseSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                BraceClose);

        static IParser<char> BracketOpenSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                BracketOpen);

        static IParser<char> BracketCloseSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                BracketClose);

        static IParser<char> CollonSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                Collon);

        static IParser<char> CommaSign =>
            new WithWhiteSpaceParser<char>(
                WhiteSpace,
                Comma);

        static IParser<JSONLiteral> JNull =>
            new ParserConverter<string, JSONLiteral>(
                new WordParser("null", true),
                word => new JSONLiteral(LiteralType.Null));

        static IParser<JSONLiteral> JBoolean =>
            new ParserConverter<string, JSONLiteral>(
                new OrParser<string>(
                    new WordParser("true", true),
                    new WordParser("false", true)),
                word => new JSONLiteral(word, LiteralType.Boolean));

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
            new ParserConverter<IEnumerable<char>, string>(
                new ZeroOrMoreParser<char>(Digit),
                chars => new string(chars.ToArray()));

        static IParser<string> JExp =>
            new ParserConverter<(char, Optional<char>, string), string>(
                new SequenceParser<char, Optional<char>, string>(
                    new CharParser('e', true),
                    new OptionalParser<char>(
                        new OrParser<char>(Plus, Minus)),
                    Digits),
                tuple => tuple.Item1.ToString() 
                + (tuple.Item2.IsPresent ? tuple.Item2.Value.ToString() : "")
                + tuple.Item3);

        static IParser<string> JFrac =>
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
            new ParserConverter<(string, Optional<string>, Optional<string>), JSONLiteral>(
                new SequenceParser<string, Optional<string>, Optional<string>>(
                    JInt,
                    new OptionalParser<string>(JFrac),
                    new OptionalParser<string>(JExp)),
                tuple => 
                    new JSONLiteral(
                        tuple.Item1 
                        + (tuple.Item2.IsPresent ? tuple.Item2.Value : "")
                        + (tuple.Item3.IsPresent ? tuple.Item3.Value : ""), 
                        LiteralType.Number));

        static IParser<char> ControlChar =>
            new ParserConverter<(char, char), char>(
                new SequenceParser<char, char>(
                    BackSlash,
                    new OrParser<char>(
                        DoubleQuote,
                        BackSlash,
                        new CharParser('b'),
                        new CharParser('n'),
                        new CharParser('f'),
                        new CharParser('r'),
                        new CharParser('t'))),
                tuple => tuple.Item2 switch
                {
                    'b' => '\b',
                    'n' => '\n',
                    'f' => '\f',
                    'r' => '\r',
                    't' => '\t',
                    var c => c
                });

        static IParser<char> JChar =>
            new OrParser<char>(
                new ExpectCharParser(
                    new OrParser<char>(
                        DoubleQuote,
                        BackSlash)),
                ControlChar);

        static IParser<JSONLiteral> JString =>
            new ParserConverter<(char, IEnumerable<char>, char), JSONLiteral>(
                new SequenceParser<char, IEnumerable<char>, char>(
                    DoubleQuote,
                    new ZeroOrMoreParser<char>(JChar),
                    DoubleQuote),
                tuple => new JSONLiteral(new string(tuple.Item2.ToArray()), LiteralType.String));

        static IParser<JSONLiteral> JLiteral =>
            new OrParser<JSONLiteral>(
                JString,
                JBoolean,
                JNull,
                JNumber);

        static IParser<IJSONValue> JValue =>
            new WithWhiteSpaceParser<IJSONValue>(
                WhiteSpace,
                new OrParser<IJSONValue>(
                    new RecursiveParser<IJSONValue>(
                        () => new ParserConverter<JSONArray, IJSONValue>(JArray, array => array)),
                    new RecursiveParser<IJSONValue>(
                        () => new ParserConverter<JSONObject, IJSONValue>(JObject, obj => obj)),
                    new ParserConverter<JSONLiteral, IJSONValue>(JLiteral, literal => literal)));

        static IParser<IEnumerable<IJSONValue>> JElements =>
            new DelimitedSequenceParser<IJSONValue, char>(
                JValue,
                CommaSign);

        static IParser<JSONArray> JArray =>
            new ParserConverter<(char, IEnumerable<IJSONValue>, char), JSONArray>(
                new SequenceParser<char, IEnumerable<IJSONValue>, char>(
                    BracketOpenSign,
                    JElements,
                    BracketCloseSign),
                tuple => new JSONArray(tuple.Item2.Any() ? tuple.Item2 : null));
                

        static IParser<KeyValuePair<string, IJSONValue>> JPair =>
            new ParserConverter<(JSONLiteral, char, IJSONValue), KeyValuePair<string, IJSONValue>>(
                new SequenceParser<JSONLiteral, char, IJSONValue>(
                            JString,
                            CollonSign,
                            JValue),
                tuple => new KeyValuePair<string, IJSONValue>(tuple.Item1.Value, tuple.Item3));

        static IParser<JSONObject> JObject =>
            new ParserConverter<(char, IEnumerable<KeyValuePair<string, IJSONValue>>, char), JSONObject>(
                new SequenceParser<char, IEnumerable<KeyValuePair<string, IJSONValue>>, char>(
                    BraceOpenSign,
                    new DelimitedSequenceParser<KeyValuePair<string, IJSONValue>, char>(
                        JPair,
                        CommaSign),
                    BraceCloseSign),
                tuple => new JSONObject { Pairs = tuple.Item2.ToDictionary(kv => kv.Key, kv => kv.Value) });

        public static async Task<JSONObject> ParseAsync(string text)
        {
            var (isSuccess, _, parsed) = await JObject.ParseAsync(new Cursol(text));
            if(isSuccess)
            {
                return parsed;
            }
            throw new ParseException();
        }
    }
}
    