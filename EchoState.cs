namespace AspNetCore_EchoBot_With_State
{
    /// <summary>
    /// Class for storing conversation state. 
    /// </summary>
    public class EchoState
    {
        public int TurnCount { get; set; } = 0;

        public bool greeting { get; set; }

        public bool Lycopersicon { get; set; }
    }
}
