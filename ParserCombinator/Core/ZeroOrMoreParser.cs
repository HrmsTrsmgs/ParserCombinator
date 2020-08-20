using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ZeroOrMoreParser<T> : IParser<IEnumerable<T>>
    {
        IParser<T> parser;

        public ZeroOrMoreParser(IParser<T> parser)
        {
            this.parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            var parseds = new List<T> { };
            var (isSuccess, current, parsed) = await parser.ParseAsync(cursol);
            return (true, current, parseds);
        }
    }
}
