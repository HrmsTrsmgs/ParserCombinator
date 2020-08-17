using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public interface IParser
    {}

    public interface IParser<T> : IParser
    {
        Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol);
    }
}
