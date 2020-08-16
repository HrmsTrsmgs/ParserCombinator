using System;
using System.Collections.Generic;
using System.Text;

namespace Marimo.ParserCombinator.Core
{
    public class Cursol
    {
        public char? Current => Index < Text.Length ? Text[Index] : (char?)null;

        public int Index { get; }
        public string Text { get; }
        public Cursol(string text) : this(text, 0)
        {}
        private Cursol(string text, int index)
        {
            Text = text;
            Index = index;
        }
        
        public Cursol GoFoward(int step) => new Cursol(Text, Math.Min(Index + step, Text.Length));

        public Cursol Copy() => new Cursol(Text, Index);
    }
}
