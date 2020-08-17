﻿using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marimo.ParserCombinator
{
    public static class SequenceParser
    {
        public static SequenceParser<T1, T2> Create<T1, T2>(IParser<T1> parser1, IParser<T2> parser2)
            => new SequenceParser<T1, T2>(parser1, parser2);

        public static SequenceParser<T1, T2, T3> Create<T1, T2, T3>(IParser<T1> parser1, IParser<T2> parser2, IParser<T3> parser3)
            => new SequenceParser<T1, T2, T3>(parser1, parser2, parser3);
    }
}
