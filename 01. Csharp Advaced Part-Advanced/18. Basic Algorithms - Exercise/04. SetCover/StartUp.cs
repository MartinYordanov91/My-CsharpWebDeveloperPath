namespace SetCover
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> primaryArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int countOfPiecePrimaryArray = int.Parse(Console.ReadLine());
            List<int[]> pieces = new();

            for (int i = 0; i < countOfPiecePrimaryArray; i++)
            {
                pieces.Add(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            List<int[]> worthPieces = SelectPieces(pieces, primaryArray);

            Console.WriteLine($"Sets to take ({worthPieces.Count}):");

            foreach (int[] curentPiece in worthPieces)
            {
                Console.WriteLine("{ " + string.Join(", ", curentPiece) + " }");
            }
        }
        public static List<int[]> SelectPieces(List<int[]> Allpiece, List<int> primaryArray)
        {
            List<int[]> ressultArray = new();
            List<Piece> pieces = new();

            foreach (int[] piece in Allpiece)
                pieces.Add(new Piece(piece));

            for (int i = 0; i < Allpiece.Count; i++)
            {
                pieces.ForEach(s => s.ValidationNumbersCount(ressultArray));
                Piece bestPiece = pieces
                    .OrderByDescending(s => s.ValidNumberCount)
                    .First();

                if (bestPiece.ValidNumberCount > 0)
                {
                    ressultArray.Add(bestPiece.SetNumber);
                    pieces.Remove(bestPiece);
                }
            }

            return ressultArray;
        }
    }
    public class Piece
    {
        public Piece(int[] array)
        {
            SetNumber = array;
            ValidNumberCount = 0;
        }

        public int[] SetNumber { get; set; }
        public int ValidNumberCount { get; set; }

        public void ValidationNumbersCount(List<int[]> resultArray)
        {
            ValidNumberCount = 0;

            foreach (int number in SetNumber)
            {
                bool isValide = true;

                foreach (int[] curentArray in resultArray)
                {
                    if (curentArray.Contains(number)) isValide = false;
                }

                if (isValide) ValidNumberCount++;
            }
        }
    }
}