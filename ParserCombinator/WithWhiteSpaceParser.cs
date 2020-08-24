using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Marimo.ParserCombinator
{
    public class WithWhiteSpaceParser<T> : IParser<T>
    {
        IParser<char> whiteSpace { get; }
        IParser<T> parser { get; }
        public WithWhiteSpaceParser(IParser<char> whiteSpace, IParser<T> parser)
        {
            this.whiteSpace = whiteSpace;
            this.parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var current = cursol;
            bool isSuccess;
            do
            {
                (isSuccess, current, _) = await whiteSpace.ParseAsync(current);
            } while (isSuccess);

            return await parser.ParseAsync(current);
        }
    }
}
