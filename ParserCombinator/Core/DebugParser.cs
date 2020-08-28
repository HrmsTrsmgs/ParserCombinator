using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class DebugParser<T> : IParser<T>
    {
        IParser<T> Parser { get; }
        Action HasBreakPoint { get; }
        public DebugParser(IParser<T> parser, Action hasBreakPoint)
        {
            Parser = parser;
            HasBreakPoint = hasBreakPoint;
        }
        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            HasBreakPoint();
            return await Parser.ParseAsync(cursol);
        }
    }
}
