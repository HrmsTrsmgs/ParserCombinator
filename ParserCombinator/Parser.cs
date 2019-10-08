using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public abstract class Parser
    {}

    public abstract class Parser<T> : Parser
    {
        public abstract Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol);
    }
}
