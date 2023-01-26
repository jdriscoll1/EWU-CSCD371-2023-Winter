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
            if (jokeOutput is null) {
                throw new ArgumentNullException("Joke Output"); 
            }
            if (jokeService is null) {
                throw new ArgumentNullException("Joke Service"); 
            }
            _JokeOutput = jokeOutput;
            _JokeService = jokeService;
        
        }

        public bool ContainsChuckNorris(string joke) {
            return joke?.IndexOf("Chuck Norris", StringComparison.OrdinalIgnoreCase) > -1; 
        }
        public string GetJoke() {
            string joke;
            do
            {
                joke = _JokeService.GetJoke();
            } while (!ContainsChuckNorris(joke)); 
            return _JokeService.GetJoke(); 
        }

        public void TellJoke() {
            _JokeOutput.output(GetJoke()); 
        }
    }
}
