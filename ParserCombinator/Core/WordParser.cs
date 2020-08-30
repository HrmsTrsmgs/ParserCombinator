using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Headers;
using System.Transactions;

namespace Marimo.ParserCombinator.Core
{
    public class WordParser : Parser<string>
    { 
        IEnumerable<Parser<char>> Parsers { get; }
        public bool IgnoreCase { get; }

        Parser<char> WhiteSpace { get; }

        public WordParser(string word, bool ignoreCase = false, Parser<char> whiteSpace = null)
        {
            Parsers = word.Select(c => new CharParser(c, ignoreCase));

            WhiteSpace = whiteSpace ?? new CharParser(' ');
        }

        protected override async ValueTask<(bool isSuccess,Cursol cursol, string parsed)>  ParseCoreAsync(Cursol cursol)
        {
            var current = await SkipBlankAsync(cursol);

            var returnValue = new List<char>();
            foreach (var parser in Parsers)
            {
                bool isSuccess;
                char parsed;
                (isSuccess, current, parsed) = await parser.ParseAsync(current);
                if(!isSuccess)
                {
                    return (false, cursol, null);
                }
                returnValue.Add(parsed);
            }
            current = await SkipBlankAsync(current);
            return (true, current, new string(returnValue.ToArray()));
        }

        private async Task<Cursol> SkipBlankAsync(Cursol current)
        {
            while (true)
            {
                bool isSuccess;
                (isSuccess, current, _) = await WhiteSpace.ParseAsync(current);
                if (!isSuccess) return current;
            }
        }
    }
}
