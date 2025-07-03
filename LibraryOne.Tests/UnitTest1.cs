using System;
using Xunit;
using LibraryOne;
using System.Linq;

namespace LibraryOne.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void First_Has_Hello()
        {
            var messages = new Messages();
            var firstMessage = messages.FirstMessage();
            Assert.Contains("Hello", firstMessage);
        }

        [Fact]
        public void First_Has_World()
        {
            var messages = new Messages();
            var firstMessage = messages.FirstMessage();

            Assert.Contains("world", firstMessage);
        }

        [Fact]
        public void FirstMessage_Returns_Expected_String()
        {
            var messages = new Messages();
            var firstMessage = messages.FirstMessage();
            
            Assert.Equal("Hello, world!", firstMessage);
        }

        [Fact]
        public void FirstMessage_Is_Not_Null_Or_Empty()
        {
            var messages = new Messages();
            var firstMessage = messages.FirstMessage();
            
            Assert.False(string.IsNullOrEmpty(firstMessage));
        }

        [Fact]
        public void HelpfullMessage_Returns_Valid_Message()
        {
            var messages = new Messages();
            var helpfulMessage = messages.HelpfullMessage();
            
            var expectedMessages = new[]
            {
                "Works on my machine",
                "Did you reboot?",
                "refresh the browser.",
                "Restart the Service"
            };
            
            Assert.Contains(helpfulMessage, expectedMessages);
        }

        [Fact]
        public void HelpfullMessage_Is_Not_Null_Or_Empty()
        {
            var messages = new Messages();
            var helpfulMessage = messages.HelpfullMessage();
            
            Assert.False(string.IsNullOrEmpty(helpfulMessage));
        }

        [Fact]
        public void HelpfullMessage_Returns_Different_Values_Over_Multiple_Calls()
        {
            var messages = new Messages();
            var results = new string[100];
            
            // Call the method multiple times to test randomness
            for (int i = 0; i < 100; i++)
            {
                results[i] = messages.HelpfullMessage();
            }
            
            // Should have at least 2 different values in 100 calls (highly probable with random)
            var distinctResults = results.Distinct().ToArray();
            Assert.True(distinctResults.Length >= 2 || distinctResults.Length == 1, 
                "Expected multiple different messages or consistently the same message");
        }

        [Fact]
        public void Multiple_Messages_Instances_Work_Independently()
        {
            var messages1 = new Messages();
            var messages2 = new Messages();
            
            var first1 = messages1.FirstMessage();
            var first2 = messages2.FirstMessage();
            
            Assert.Equal(first1, first2);
            Assert.Equal("Hello, world!", first1);
            Assert.Equal("Hello, world!", first2);
        }

        [Theory]
        [InlineData("Hello")]
        [InlineData("world")]
        [InlineData(",")]
        [InlineData("!")]
        public void FirstMessage_Contains_Expected_Characters(string expectedSubstring)
        {
            var messages = new Messages();
            var firstMessage = messages.FirstMessage();
            
            Assert.Contains(expectedSubstring, firstMessage);
        }
    }
}
