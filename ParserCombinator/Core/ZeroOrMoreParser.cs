using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ZeroOrMoreParser<T> : IParser<IEnumerable<T>>
    {
        IParser<T> Parser { get; }

        public ZeroOrMoreParser(IParser<T> parser)
        {
            Parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            var parseds = new List<T> { };
            bool isSuccess;
            T parsed;
            var current = cursol;
            while (true)
            {
                (isSuccess, current, parsed) = await Parser.ParseAsync(current);
                if (!isSuccess)
                {
                    return (true, current, parseds);
                }
                parseds.Add(parsed);
            }
        }
    }
}
