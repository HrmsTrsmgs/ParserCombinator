using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OrParser<T> : IParser<T>
    {
        IParser<T>[] parsers { get; }

        public OrParser(params IParser<T>[] parsers)
        {
            this.parsers = parsers;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            foreach(var parser in parsers)
            {
                var result = await parser.ParseAsync(cursol);
                
                if(result.isSuccess)
                {
                    return result;
                }
            }
            return (false, cursol, default);
        }
    }
}
