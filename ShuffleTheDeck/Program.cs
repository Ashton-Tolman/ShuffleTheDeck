/* Ashton Tolman
 * Spring 2026
 * ShuffleTheDeck
 * https://github.com/Ashton-Tolman/ShuffleTheDeck.git
 */
/*TODO
 * [] Make array of full deck
 * [] Display array
 * []
 * []
 * []
*/
namespace ShuffleTheDeck
{
    internal class Program
    {
        //global array
        static bool[,] drawnCards = new bool[4, 13];
        static void Main(string[] args)
        {
            int cardCount = 0;
            string userInput = "";

            //opening messages and quit/clear functions
            do
            {
                Console.Clear();
                Console.WriteLine($"Press \"Q\" to quit." +
                    $"\nPress \"C\" to clear the board." +
                    $"\nCount will reset once board is filled." +
                    $"\nPress \"Enter\" to draw a card and start playing!");
                DrawCard();
                ShowDisplay();
                cardCount++;
                Console.WriteLine($"Cards drawn= \"{cardCount}\"");
                userInput = Console.ReadLine();
                if (userInput == "c" || userInput == "C")
                {
                    ShuffleDeck();
                    cardCount = 0;
                }
                else if (cardCount == 52)
                {
                    Console.WriteLine($"All Cards drawn" +
                                      $"\nShuffling Deck....");
                    Console.ReadLine();
                    ShuffleDeck();
                    cardCount = 0;
                }
            } while (userInput != "Q" && userInput != "q");
            Console.WriteLine("Thanks for playing!");
            Console.Read();
        }

        //Prints full array with what cards are drawn
        static void ShowDisplay()
        {
            int padding = 8;
            string faceCard = "";
            string placeHolder = "";
            string currentRow = "";
            string collumnSeparator = "|";
            string[] heading = { "Clubs", "Hearts", "Spades", "Diamonds"};
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + collumnSeparator);
            }
            Console.WriteLine();

            //Pring the rest of the rows
            for (int rank = 1; rank <= 13; rank++)
            {
                //assemble the row
                for (int suit = 0; suit < 4; suit++)
                {
                    if (drawnCards[suit, rank - 1])
                    {
                        if (drawnCards[suit, 12])
                        {
                            faceCard = "K";
                            currentRow += faceCard.ToString().PadLeft(padding) + collumnSeparator;
                        }
                        else
                        {
                            currentRow += rank.ToString().PadLeft(padding) + collumnSeparator;
                        }
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + collumnSeparator;

                    }
                }
                Console.WriteLine(currentRow);
                currentRow = ""; //reset the variable
            }
        }
        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);

        }
        static void DrawCard()
        {
            int letter = 0, number = 0;
            do
            {
                letter = RandomNumberZeroTo(3);
                number = RandomNumberZeroTo(12);

            } while (drawnCards[letter, number]);

            drawnCards[letter, number] = true;
        }
        static void ShuffleDeck()
        {
            drawnCards = new bool[4, 13];
        }
    }
}
