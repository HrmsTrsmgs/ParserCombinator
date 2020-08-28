using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OptionalParser<T> : IParser<Optional<T>>
    {
        IParser<T> Parser { get; }
        public OptionalParser(IParser<T> parser)
        {
            Parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, Optional<T> parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, afterCursol, parsed) = await Parser.ParseAsync(cursol);
            return (true, afterCursol, new Optional<T>(isSuccess, parsed));
        }
    }
}
