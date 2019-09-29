using System;
using System.Collections.Generic;
using System.Text;

namespace Marimo.ParserCombinator
{
    public class Cursol
    { 
        public Cursol(string text) : this(text, 0)
        {

        }
        private Cursol(string text, int index)
        {
            Text = text;
            Index = index;
        }
        public string Text { get; }

        public int Index { get; }
        public Cursol GoFoward(int step)
        {
            return new Cursol(Text, Math.Min(Index + step, Text.Length));
        }
    }
}
