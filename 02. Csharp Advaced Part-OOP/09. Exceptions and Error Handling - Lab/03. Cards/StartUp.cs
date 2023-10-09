namespace Cards
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string[] cardarg = tokens[i].Split();
                string face = cardarg[0].Trim();
                string suit = cardarg[1].Trim();
                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" " , cards));
        }
    }

    public class Card
    {
        private List<string> validFace = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private List<string> validSuit = new List<string>() { "S", "H", "D", "C" };
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Suit = suit;
            Face = face;
        }

        public string Suit
        {
            get { return suit; }
            set
            {
                if (validSuit.Any(x => x == value) == false)
                {
                    throw new ArgumentException("Invalid card!");
                }

                if(value == "S") { suit = "\u2660"; }
                if(value == "H") { suit = "\u2665"; }
                if(value == "D") { suit = "\u2666"; }
                if(value == "C") { suit = "\u2663"; }
            }
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (validFace.Any(x => x == value) == false)
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public override string ToString()
            => $"[{face}{suit}]";
    }
}