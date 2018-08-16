

namespace Lycopersicon_src.Brain
{
    /// <summary>
    /// Works as a hub for all brain's functions and entry points.
    /// </summary>
    public class Brain
    {
        private BrocasArea talking;

        public BrodmannArea memory;

        public string respond(string phrase)
        {
            //Check entered phrase

            if (string.IsNullOrWhiteSpace(phrase)) {
                return "So.. silent..";
            }
            var question = phrase.ToLower();
            //
            var response = "...";
            switch (phrase)
            {
                case "hello":
                    if (memory.greeting)
                    {
                        response = "We've already greeted Today.";
                    }
                    else
                    {
                        response = "Hello!";
                        memory.greeting = true;
                    }

                    break;

                case "bye":
                    if (memory.greeting)
                    {
                        response = "Bye!";
                        memory.greeting = false;
                    }
                    else
                    {
                        response = "Bye without Hello first?!";
                    }

                    break;

                default:
                    response = $"Turn {memory.TurnCount}: You sent '{phrase}'";
                    break;
            }
            return response;
        }
    }
}