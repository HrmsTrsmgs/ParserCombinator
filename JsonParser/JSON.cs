﻿using Marimo.ParserCombinator;
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

        static IParser<string> @string =>
            new ParserConverter<(char, string, char), string>(
                new SequenceParser<char, string, char>(
                    doubleQuote,
                    new WordParser("a"),
                    doubleQuote),
                t => t.Item2);

        

        static IParser<int> number =>
            new ParserConverter<(Optional<char>, char), int>(
                new SequenceParser<Optional<char>, char>(
                    new OptionalParser<char>(new CharParser('-')),
                    new CharParser('1')),
                tuple => int.Parse($"{(tuple.Item1.IsPresent ? "-" : "")}{tuple.Item2}"));


        static IParser<JSONObject> jsonObject =>
            new ParserConverter<(char, Optional<(string, char, int)>, char), JSONObject>(
                new SequenceParser<char, Optional<(string, char, int)>, char>(
                    bracketOpen,
                    new OptionalParser<(string, char, int)>(
                        new SequenceParser<string, char, int>(
                            @string,
                            collon,
                            number)),
                    bracketClose),
                tuple => tuple.Item2.IsPresent ?
                    new JSONObject { Pairs = { [tuple.Item2.Value.Item1] = new JSONLiteral(tuple.Item2.Value.Item3.ToString(), LiteralType.Number) } } 
                    : new JSONObject());

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
    