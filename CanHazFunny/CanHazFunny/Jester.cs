using System;


namespace CanHazFunny
{
    public class Jester
    {
        private IJokeOutput? _JokeOutput;
        private IJokeService? _JokeService;

        public IJokeService JokeService {
            
            get 
            {
                return _JokeService!; 
            }
            set 
            {
                ArgumentNullException.ThrowIfNull(nameof(value));
                _JokeService = value; 

            }

        }

        public IJokeOutput JokeOutput
        {

            get
            {
                return _JokeOutput!;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(nameof(value));
                _JokeOutput = value;

            }

        }
        public Jester(IJokeOutput jokeOutput, IJokeService jokeService) {
            JokeOutput = jokeOutput; 
            JokeService = jokeService;
        
        }


        // What does Get Joke Do? It returns a joke
        // What does Tell Joke Do? It filters through Chuck Jokes & Sends it to output 
        public string GetJoke() {
            return JokeService.GetJoke();
        }

        public void TellJoke() {
            string joke; 
            do
            {
                joke = GetJoke(); 

            } while (joke.Contains("Chuck Norris", System.StringComparison.CurrentCulture));
            JokeOutput.Output(joke); 
        }
    }
}
