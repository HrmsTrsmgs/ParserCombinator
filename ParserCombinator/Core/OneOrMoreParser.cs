using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OneOrMoreParser<T> : IParser<IEnumerable<T>>
    {
        IParser<T> Parser { get; }

        public OneOrMoreParser(IParser<T> parser)
        {
            Parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, current, parsed) = await Parser.ParseAsync(cursol);
            if (!isSuccess)
            {
                return (false, cursol, null);
            }
            var parseds = new List<T> { parsed };
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
