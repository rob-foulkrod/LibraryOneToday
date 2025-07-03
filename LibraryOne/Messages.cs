using System;
using System.Threading.Tasks;

namespace LibraryOne
{
    public class Messages
    {
        public string FirstMessage()
        {
            return "Hello, world!";
        }

        private readonly string[] messages = {
            "Works on my machine",
            "Did you reboot?",
            "refresh the browser.",
            "Restart the Service",
        };

        private static readonly Random rnd = new();
        public string HelpfullMessage()
        {
            return messages[rnd.Next(messages.Length)];
        }

      
    }
}
