using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class DebugParser<T> : IParser<T>
    {


        IParser<T> parser { get; }
        Action hasBreakPoint { get; }
        public DebugParser(IParser<T> parser, Action hasBreakPoint)
        {
            this.parser = parser;
            this.hasBreakPoint = hasBreakPoint;
        }
        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            hasBreakPoint();
            return await parser.ParseAsync(cursol);
        }
    }
}
