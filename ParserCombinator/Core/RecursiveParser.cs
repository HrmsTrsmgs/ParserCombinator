using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class RecursiveParser<T> : IParser<T>
    {
        Func<IParser<T>> ParserGetter { get; }
        public RecursiveParser(Func<IParser<T>> parserGetter)
        {
            this.ParserGetter = parserGetter;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            return await ParserGetter().ParseAsync(cursol);
        }
    }
}
