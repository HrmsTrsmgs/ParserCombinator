using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OrParser<T> : IParser<T>
    {
        IParser<T> parser1 { get; }
        IParser<T> parser2 { get; }
        public OrParser(IParser<T> parser1, IParser<T> parser2)
        {
            this.parser1 = parser1;
            this.parser2 = parser2;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var result = await  parser1.ParseAsync(cursol);
            return 
                result.isSuccess 
                ? result 
                : await parser2.ParseAsync(cursol);
        }
    }
}
