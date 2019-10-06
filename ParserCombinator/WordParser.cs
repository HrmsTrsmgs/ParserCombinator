using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            var readIndex = 0;

            while(cursol.Text[cursol.Index + readIndex] == ' ')
            {
                readIndex++;
            }

            var wordIndex = 0;

            while(readIndex < cursol.Text.Length && wordIndex < Word.Length && cursol.Text[cursol.Index + readIndex] == Word[wordIndex++])
            {
                readIndex++;
            }

            if (wordIndex == Word.Length)
            {
                while (cursol.Index + readIndex < cursol.Text.Length && cursol.Text[cursol.Index + readIndex] == ' ')
                {
                    readIndex++;
                }
                return (true, cursol.GoFoward(readIndex));
            }
            else
            {
                return (false, cursol);
            }
        }
    }
}
