using DesafioIti.Core.Services;
using FluentAssertions;
using Xunit;


namespace DesafioIti.Tests.Services
{
    public class HashServiceTests
    {
        private readonly HashService _hashService;

        public HashServiceTests()
        {
            _hashService = new HashService();
        }


        [Fact]
        public void ValidateHash_ValidateHashLength_ExpectFalse()
        {
            var hasValue = "AbTp9!fo";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasDigit_ExpectFalse()
        {
            var hasValue = "AbTpsd!foi";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasLowerChar_ExpectFalse()
        {
            var hasValue = "ABTPSD!FOX1";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasUpperChar_ExpectFalse()
        {
            var hasValue = "abtpsd!fo1";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasSpecialChar_ExpectFalse()
        {
            var hasValue = @"abtpsdSfo1";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasDuplicateChar_ExpectFalse()
        {
            var hasValue = "aabtpsdSfo1!";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateHashHasWhiteSpace_ExpectFalse()
        {
            var hasValue = "AbTp9!fok ";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateHash_ValidateValidHash_ExpectTrue()
        {
            var hasValue = "AbTp9!fok";

            var result = _hashService.ValidateHash(hasValue).Result;

            result.Should().BeTrue();
        }
    }
}
