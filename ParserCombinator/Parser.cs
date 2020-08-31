using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public interface Parser
    {}

    public abstract class Parser<T> : Parser
    {
        public (bool isSuccess, Cursol cursol, T parsed) Parse(Cursol cursol)
        {
            return ParseCore(cursol);
        }

        protected abstract (bool isSuccess, Cursol cursol, T parsed) ParseCore(Cursol cursol);
    }
}
