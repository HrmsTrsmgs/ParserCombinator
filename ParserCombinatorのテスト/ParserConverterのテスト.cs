using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserCombinatorのテスト
{
    public class ParserConverterのテスト
    {
        ParserConverter<int, string> tested;

        public ParserConverterのテスト()
        {
            tested = ParserConverter.Create(new WordParser("123"), s => int.Parse(s));
        }


        [Fact]
        public async Task パースします()
        {
            await tested.ParseAsync(new Cursol("123"));
        }

        [Fact]
        public async Task 指定したパーサーと同じ条件で成功します()
        {
            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("123"));

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task 指定したパーサーと同じ条件で失敗します()
        {
            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("124"));

            isSuccess.IsFalse();
        }

        [Fact]
        public async Task 指定した通り変換がなされます()
        {
            var (_, _, parsed) = await tested.ParseAsync(new Cursol("123"));

            parsed.Is(123);
        }

        [Fact]
        public async Task 成功した時はカーソルが進みます()
        {
            var (_, cursol, _) = await tested.ParseAsync(new Cursol("123"));

            cursol.Index.Is(3);
        }
    }
}
