using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class RecursiveParser<T> : Parser<T>
    {
        Func<Parser<T>> ParserGetter { get; }
        public RecursiveParser(Func<Parser<T>> parserGetter)
        {
            ParserGetter = parserGetter;
        }

        public override async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
            => await ParserGetter().ParseAsync(cursol);
    }
}
