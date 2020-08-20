using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OneOrMoreParser<T> : IParser<IEnumerable<T>>
    {
        IParser<T> parser;

        public OneOrMoreParser(IParser<T> parser)
        {
            this.parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, current, parsed) = await parser.ParseAsync(cursol);
            if (!isSuccess)
            {
                return (false, cursol, null);
            }
            var parseds = new List<T> { parsed };
            while (true)
            {
                (isSuccess, current, parsed) = await parser.ParseAsync(current);
                if (!isSuccess) 
                {
                    return (true, current, parseds);
                }
                parseds.Add(parsed);
            }
        }
    }
}
