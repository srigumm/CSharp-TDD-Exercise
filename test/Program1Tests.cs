using System;
using Xunit;
using src;
namespace test
{
    public class Program1Tests
    {
        [Theory]
        [InlineData()]
        [InlineData(null)]
        [InlineData("1")]
        public void Should_Return_Error_For_EmptyInputs(params string[] inputs)
        {
            var exception = Assert.Throws<Exception>(()=>Program.Main(inputs));
            Assert.Equal("Should provide 2 arguments",exception.Message);
        }

        [Theory]
        [InlineData("Five","Six")]
        [InlineData("Five","6")]
        public void Should_Return_Error_For_NonIntegerInputs(params string[] inputs)
        {
            var exception = Assert.Throws<Exception>(()=>Program.Main(inputs));
            Assert.Equal("Should provide only numbers",exception.Message);
        }

        [Theory]
        [InlineData("5","0","Second number cannot be zero")]
        [InlineData("1","1","First number cannot be less than 2")]
        [InlineData("5","25","Second number cannot be greater than first number")]
        [InlineData("25","7","First number not evenly divisible by second number")]
        [InlineData("-25","5","Either number is negative")]
        [InlineData("1010","5","First number must be < 1000")]
        public void Should_Return_Error_For_InvalidInputs(params string[] inputs)
        {
            var exception = Assert.Throws<Exception>(()=>Program.Main(inputs));
            Assert.Equal(inputs[2],exception.Message);
        }

        [Theory]
        [InlineData("25","5")]
        [InlineData("100","10")]
        [InlineData("21","7")]
        public void Should_Not_Return_Error_For_ValidInputs(params string[] inputs)
        {
            Program.Main(inputs); //Doesn't throw any exception
        }

    }
}
