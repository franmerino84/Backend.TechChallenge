using Backend.TechChallenge.Domain.Services.Email;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Email
{
    public class EmailNormalizerUnitTests
    {
        private readonly EmailNormalizer _emailNormalizer;

        public EmailNormalizerUnitTests()
        {
            _emailNormalizer = new EmailNormalizer();
        }

        [Fact]
        public void Normalize_ValidEmail_SameEmail()
        {
            var validEmail = "test@email.com";

            var result = _emailNormalizer.Normalize(validEmail);

            Assert.Equal(validEmail, result);
        }

        [Fact]
        public void Normalize_EmailWithPlus_RemovePlusAndFollowingCharactersBeforeAt()
        {
            var email = "test+other@email.com";
            var expected = "test@email.com";

            var result = _emailNormalizer.Normalize(email);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Normalize_EmailWithDot_RemoveDot()
        {
            var email = "test.other@email.com";
            var expected = "testother@email.com";

            var result = _emailNormalizer.Normalize(email);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Normalize_EmailWithDotAbndPlus_RemoveDotAndPlusAndFolllowingCharactersBeforeAt()
        {
            var email = "test.other+another@email.com";
            var expected = "testother@email.com";

            var result = _emailNormalizer.Normalize(email);

            Assert.Equal(expected, result);
        }
    }
}
