using System;
using Xunit;

namespace Project1
{
    public class HelloWorldTest
    {
        [Fact]
        public void CanSayHello()
        {
            //arrange
            var a = 1;
            var b = 2;

            //act
            var result = Function(a, b);

            //assert
            Assert.Equal(42, result);
        }

        private object Function(int a, int b)
        {
            return 42;
        }
    }
}
