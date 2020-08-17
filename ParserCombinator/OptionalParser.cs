using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marimo.ParserCombinator
{
    public static class OptionalParser
    {
        public static OptionalParser<T> Create<T>(IParser<T> parser)
        {
            return new OptionalParser<T>(parser);
        }
    }
}
