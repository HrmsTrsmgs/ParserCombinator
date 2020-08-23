using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.ParserCombinator.Test.Core
{
    public class RecursiveParserのテスト
    {
        [Fact]
        public async Task ParseAsyncは内部パーサーと同じように成功します()
        {
            var cursol = new Cursol("public");
            var parser = new CharParser('p');
            var tested = new RecursiveParser<char>(() => parser);
            (await tested.ParseAsync(cursol)).IsStructuralEqual(await parser.ParseAsync(cursol));
        }

    }
}
