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
        IParser<char> WhiteSpace { get; }
        IParser<T> Parser { get; }
        public WithWhiteSpaceParser(IParser<char> whiteSpace, IParser<T> parser)
        {
            WhiteSpace = whiteSpace;
            Parser = parser;
        }

        public async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var current = cursol;
            bool isSuccess;
            do
            {
                (isSuccess, current, _) = await WhiteSpace.ParseAsync(current);
            } while (isSuccess);

            return await Parser.ParseAsync(current);
        }
    }
}
