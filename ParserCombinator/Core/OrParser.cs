using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OrParser<T> : Parser<T>
    {
        Parser<T>[] Parsers { get; }

        public OrParser(params Parser<T>[] parsers)
        {
            Parsers = parsers;
        }

        protected override async ValueTask<(bool isSuccess, Cursol cursol, T parsed)> ParseCoreAsync(Cursol cursol)
        {
            foreach(var parser in Parsers)
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
