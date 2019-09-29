using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class WordParser
    {
        public string Word { get; }

        public WordParser(string word)
        {
            Word = word;
        }

        public async Task<(bool isSuccess,Cursol cursol)>  ParseAsync(Cursol cursol)
        {
            if (cursol.Text.StartsWith(Word))
            {
                return (true, cursol.GoFoward(Word.Length));
            }
            else
            {
                return (false, cursol);
            }
        }
    }
}
