/* Ashton Tolman
 * Spring 2026
 * ShuffleTheDeck
 * https://github.com/Ashton-Tolman/ShuffleTheDeck.git
 */
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                //Clears if user presses C or if count reaches 52
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
                //Quits only when user presses q
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

            //prints header suits
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + collumnSeparator);
            }

            //Line break before table display
            Console.WriteLine();
            Console.WriteLine((new string('-', 36)));

            //Pring the rest of the rows
            for (int rank = 1; rank <= 13; rank++)
            {
                //assemble the row
                for (int suit = 0; suit < 4; suit++)
                {
                    //code prints nothing if the card hasnt been drawn
                    if (drawnCards[suit, rank - 1])
                    {
                        //code to check if rank is a face card
                        if (drawnCards[suit, rank - 1])
                        {
                            switch (rank)
                            {
                                case 1:
                                    faceCard = "Ace";
                                    break;
                                case 11:
                                    faceCard = "Jack";
                                    break;
                                case 12:
                                    faceCard = "Queen";
                                    break;
                                case 13:
                                    faceCard = "King";
                                    break;
                                default:
                                    faceCard = rank.ToString();
                                    break;
                            }
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

        //self explanitory 
        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);

        }

        //drawns two random numbers for rank and suit
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

        //deletes old array and prints a copy without any cards drawn
        static void ShuffleDeck()
        {
            drawnCards = new bool[4, 13];
        }
    }
}
