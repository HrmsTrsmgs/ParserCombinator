using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class OrParserのテスト
    {
        [Fact]
        public async Task 一つ目の要素のパースに成功したら成功です()
        {
            var tested = new OrParser<string>(new WordParser("abc"), new WordParser("ab"));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("abc"));

            isSuccess.IsTrue();
        }


        [Fact]
        public async Task 一つ目の要素のパースに成功したら一つ目の要素が返ります()
        {
            var tested = new OrParser<string>(new WordParser("abc"), new WordParser("ab"));

            var (_, _, parsed) = await tested.ParseAsync(new Cursol("abc"));

            parsed.Is("abc");
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したら一つ目の要素の分だけカーソルが進みます()
        {
            var tested = new OrParser<string>(new WordParser("abc"), new WordParser("ab"));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("abc"));

            cursol.Index.Is("abc".Length);
       }

        [Fact]
        public async Task 一つ目の要素のパースに失敗し二つ目の要素には成功したら成功です()
        {
            var tested = new OrParser<string>(new WordParser("abc"), new WordParser("ab"));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("ab"));

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task 一つ目の要素のパースに失敗し二つ目の要素には成功したら二つ目の要素の分だけカーソルが進みます()
        {
            var tested = new OrParser<string>(new WordParser("abc"), new WordParser("ab"));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("ab"));

            cursol.Index.Is("ab".Length);
        }
    }
}
