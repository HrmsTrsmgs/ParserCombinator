using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public abstract class Parser
    {
        public abstract Task<(bool isSuccess, Cursol cursol)> ParseAsync(Cursol cursol);
    }

    public abstract class Parser<T> : Parser
    {
    }
}
