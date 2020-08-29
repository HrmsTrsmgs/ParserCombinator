using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class DebugParser<T> : Parser<T>
    {
        Parser<T> Parser { get; }
        Action HasBreakPoint { get; }
        public DebugParser(Parser<T> parser, Action hasBreakPoint)
        {
            Parser = parser;
            HasBreakPoint = hasBreakPoint;
        }
        public override async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            HasBreakPoint();
            return await Parser.ParseAsync(cursol);
        }
    }
}
