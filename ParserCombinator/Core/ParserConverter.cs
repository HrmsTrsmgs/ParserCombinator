using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ParserConverter<U, T> : IParser<T>
    {
        IParser<U> parser { get; }
        Func<U, T> converter { get; }

        public ParserConverter(IParser<U> parser, Func<U, T> converter)
        {
            this.parser = parser;
            this.converter = converter;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, afterCursol, parsed) = await parser.ParseAsync(cursol);
            
            return (isSuccess, afterCursol, (isSuccess ? converter(parsed) : default));
        }
    }
}
