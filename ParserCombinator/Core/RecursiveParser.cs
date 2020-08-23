using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class RecursiveParser<T> : IParser<T>
    {
        Func<T> parserGetter { get; }
        public RecursiveParser(Func<T> parserGetter)
        {
            this.parserGetter = parserGetter;
        }

        public Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            throw new NotImplementedException();
        }
    }
}
