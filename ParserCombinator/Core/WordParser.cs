using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
namespace Marimo.ParserCombinator.Core
{
    public class WordParser : IParser<string>
    {
        public string Word { get; }

        public bool IgnoreCase { get; }

        public WordParser(string word, bool ignoreCase = false)
        {
            Word = word;
            IgnoreCase = ignoreCase;
        }

        public async Task<(bool isSuccess,Cursol cursol, string parsed)>  ParseAsync(Cursol cursol)
        {
            
            var current = await SkipBlankAsync(cursol);

            var helper = new SequenceHelper(current);
            var returnValue = new List<char>();
            foreach (var parser in Word.Select(c => new CharParser(c, IgnoreCase)))
            {
                if (!await helper.ParseAsync(parser, value => returnValue.Add(value)))
                {
                    return (false, cursol, default);
                }
            }
            current = await SkipBlankAsync(helper.Current);
            return (true, current, new string(returnValue.ToArray()));
        }

        private async Task<Cursol> SkipBlankAsync(Cursol current)
        {
            var space = new CharParser(' ');
            while (true)
            {
                var result = await space.ParseAsync(current);
                if (!result.isSuccess) break;
                current = result.cursol;
            }

            return current;
        }
    }
}
