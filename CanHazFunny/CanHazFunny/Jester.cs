using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private JokeOutput _JokeOutput;
        private JokeService _JokeService; 
        public Jester(JokeOutput jokeOutput, JokeService jokeService) {
            _JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
            _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        
        }

        public static bool ContainsChuckNorris(string joke) {
            return joke?.IndexOf("Chuck Norris", StringComparison.OrdinalIgnoreCase) > -1; 
        }
        public string GetJoke() {
            string joke;
            do
            {
                joke = _JokeService.GetJoke();

            } while (ContainsChuckNorris(joke)); 
            return joke; 
        }

        public void TellJoke() {
            _JokeOutput.output(GetJoke()); 
        }
    }
}
