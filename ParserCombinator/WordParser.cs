using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class WordParser : Parser<string>
    {
        public string Word { get; }

        public WordParser(string word)
        {
            Word = word;
        }

        public override async Task<(bool isSuccess,Cursol cursol, string parsed)>  ParseAsync(Cursol cursol)
        {
            var readIndex = 0;

            while(cursol.Text[cursol.Index + readIndex] == ' ')
            {
                readIndex++;
            }

            var wordIndex = 0;

            while(readIndex < cursol.Text.Length && wordIndex < Word.Length && cursol.Text[cursol.Index + readIndex] == Word[wordIndex])
            {
                readIndex++;
                wordIndex++;
            }

            if (wordIndex == Word.Length)
            {
                while (cursol.Index + readIndex < cursol.Text.Length && cursol.Text[cursol.Index + readIndex] == ' ')
                {
                    readIndex++;
                }
                return (true, cursol.GoFoward(readIndex), Word);
            }
            else
            {
                return (false, cursol, default);
            }
        }
    }
}
