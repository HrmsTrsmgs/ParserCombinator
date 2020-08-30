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
        public async ValueTask<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            return await ParseCoreAsync(cursol);
        }

        protected abstract ValueTask<(bool isSuccess, Cursol cursol, T parsed)> ParseCoreAsync(Cursol cursol);
    }
}
