using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int flag = 0;

    //Plansza
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Gracz 1: X i Gracz 2: O");
            Console.WriteLine("\n");
            if (player % 2 == 0)
            {
                Console.WriteLine("Teraz tura Gracza 2");
            }
            else
            {
                Console.WriteLine("Teraz tura Gracza 1");
            }
            Console.WriteLine("\n");
            Board();

            // Sprawdź, czy pole jest dostępne
            if (int.TryParse(Console.ReadLine(), out choice) && choice < 10 && choice > 0 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
            {
                if (player % 2 == 0)
                {
                    board[choice - 1] = 'O';
                    player++;
                }
                else
                {
                    board[choice - 1] = 'X';
                    player++;
                }
            }
            else
            {
                Console.WriteLine("Błąd! Wybierz poprawne pole.");
                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
            }
            flag = CheckWin();
        }
        while (flag != 1 && flag != -1);

        Console.Clear();
        Board();
        if (flag == 1)
        {
            Console.WriteLine("Gracz {0} wygrał!", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Remis!");
        }
        Console.ReadLine();
    }

    // Tablica
    private static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
        Console.WriteLine("     |     |      ");
    }

    // Metoda do sprawdzania warunków zwycięstwa
    private static int CheckWin()
    {
        #region Horzontal Winning Condtion
        // Winning Condition For First Row
        if (board[0] == board[1] && board[1] == board[2])
        {
            return 1;
        }
        // Winning Condition For Second Row
        else if (board[3] == board[4] && board[4] == board[5])
        {
            return 1;
        }
        // Winning Condition For Third Row
        else if (board[6] == board[7] && board[7] == board[8])
        {
            return 1;
        }
        #endregion

        #region Vertical Winning Condtion
        // Winning Condition For First Column
        else if (board[0] == board[3] && board[3] == board[6])
        {
            return 1;
        }
        // Winning Condition For Second Column
        else if (board[1] == board[4] && board[4] == board[7])
        {
            return 1;
        }
        // Winning Condition For Third Column
        else if (board[2] == board[5] && board[5] == board[8])
        {
            return 1;
        }
        #endregion

        #region Diagonal Winning Condition
        else if (board[0] == board[4] && board[4] == board[8])
        {
            return 1;
        }
        else if (board[2] == board[4] && board[4] == board[6])
        {
            return 1;
        }
        #endregion

        #region Checking For Draw
        // If all cells or values filled with X or O
        else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
        {
            return -1;
        }
        #endregion

        else
        {
            return 0;
        }
    }
}
