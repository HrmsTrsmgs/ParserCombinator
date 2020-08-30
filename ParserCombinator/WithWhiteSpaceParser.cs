using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Marimo.ParserCombinator
{
    public class WithWhiteSpaceParser<T> : Parser<T>
    {
        Parser<char> WhiteSpace { get; }
        Parser<T> Parser { get; }
        public WithWhiteSpaceParser(Parser<char> whiteSpace, Parser<T> parser)
        {
            WhiteSpace = whiteSpace;
            Parser = parser;
        }

        protected override async ValueTask<(bool isSuccess, Cursol cursol, T parsed)> ParseCoreAsync(Cursol cursol)
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
