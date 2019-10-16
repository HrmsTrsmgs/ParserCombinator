using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marimo.Parser
{

    public class JsonParser
    {
        public Parser<string> Null => new WordParser("null", true);
    }
}
    