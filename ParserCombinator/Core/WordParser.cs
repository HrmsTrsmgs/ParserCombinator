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
    public class WordParser : IParser<string>
    { 
        IEnumerable<IParser<char>> Parsers { get; }
        public bool IgnoreCase { get; }

        IParser<char> WhiteSpace { get; }

        public WordParser(string word, bool ignoreCase = false, IParser<char> whiteSpace = null)
        {
            Parsers = word.Select(c => new CharParser(c, ignoreCase));

            WhiteSpace = whiteSpace ?? new CharParser(' ');
        }

        public async Task<(bool isSuccess,Cursol cursol, string parsed)>  ParseAsync(Cursol cursol)
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
