

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
            // Check entered phrase
            if (string.IsNullOrWhiteSpace(phrase)) {
                return "So.. silent..";
            }
            // Make it lowercase
            var question = phrase.ToLower();
            //Process given question
            var analysis = talking.process(question);
            //Go through known responses
            var response = "...";
            switch (phrase)
            {
                case "hello":
                    if (memory.Exists("greeting","1"))
                    {
                        response = "We've already greeted Today.";
                    }
                    else
                    {
                        response = "Hello!";
                        memory.Put("greeting", "1");
                    }

                    break;

                case "bye":
                    if (memory.Exists("greeting","0"))
                    {
                        response = "Bye!";
                        memory.Put("greeting", "0");
                    }
                    else
                    {
                        response = "Bye without Hello first?!";
                    }

                    break;

                default:
                    var resp = memory.Read("TurnCount") ?? "undefined count";
                    response = $"Turn {resp}: You sent '{phrase}'";
                    break;
            }
            return response;
        }
    }
}