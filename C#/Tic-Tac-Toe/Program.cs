using System.ComponentModel.Design;

string[] board = {  "\n\n   a     b     c  ",
                    "      |     |     ",
                    "1  -  |  -  |  -  ",
                    " _____|_____|_____",
                    "      |     |     ",
                    "2  -  |  -  |  -  ",
                    " _____|_____|_____",
                    "      |     |     ",
                    "3  -  |  -  |  -  ",
                    "      |     |     "};

void BoardReset(int pos1, int pos2)
    {
        string mid = board[pos1];

        mid = mid.Remove(pos2,1).Insert(pos2, "-");

        board[pos1] = mid;
    }

void FullBoardReset()
    {
        BoardReset(2, 3);
        BoardReset(2, 9);
        BoardReset(2, 15);
        BoardReset(5, 3);
        BoardReset(5, 9);
        BoardReset(5, 15);
        BoardReset(8, 3);
        BoardReset(8, 9);
        BoardReset(8, 15);
    }

void Main()
    {
        FullBoardReset();
        PrintBoard();
        Choice();
    }

void PlaceX(int x, int y, string pos)
    {
        string mid = board[x];

        mid = mid.Remove(y,1).Insert(y, pos);

        board[x] = mid;

        PrintBoard();
    }

void PrintBoard() 
    {
        Console.ForegroundColor = ConsoleColor.Black;
                            
        foreach (string line in board)
            {
                Console.WriteLine(line);
            }

        Console.ResetColor();
    }

void CheckWin(int pos1, int pos11, int pos2, int pos22, int pos3, int pos33)
    {
        string one = board[pos1];
        string two = board[pos2];
        string three = board[pos3];
        if (one[pos11].ToString() == "x" && two[pos22].ToString() == "x" && three[pos33].ToString() == "x")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Win!!!");
                Console.ResetColor();
                MainMenu();
            }
        else if (one[pos11].ToString() == "o" && two[pos22].ToString() == "o" && three[pos33].ToString() == "o")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lose!!!");
                Console.ResetColor();
                MainMenu();
            }
    }

void CheckAll()
    {
        CheckWin(2, 3, 2, 9, 2, 15);
        CheckWin(5, 3, 5, 9, 5, 15);
        CheckWin(8, 3, 8, 9, 8, 15);
        CheckWin(2, 3, 5, 3, 8, 3);
        CheckWin(2, 9, 5, 9, 8, 9);
        CheckWin(2, 15, 5, 15, 8, 15);
        CheckWin(2, 3, 5, 9, 8, 15);
        CheckWin(2, 15, 5, 9, 8, 3);
        string one1 = board[2];
        string two2 = board[5];
        string three3 = board[8];
        if (one1[3].ToString() != "-" && one1[9].ToString() != "-" && one1[15].ToString() != "-" && two2[3].ToString() != "-" && two2[9].ToString() != "-" && two2[15].ToString() != "-" && three3[3].ToString() != "-" && three3[9].ToString() != "-" && three3[15].ToString() != "-")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It's a tie, UwU");
                Console.ResetColor();
                MainMenu();
            }
    }

void PlaceCheck(int x, int y, string symbol)
    {
        string mid = board[x];

        if (mid[y].ToString() == "-") 
            {
                PlaceX(x, y, symbol);
            }
        else if (mid[y].ToString() == "x" || mid[y].ToString() == "o")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nSomeone Already Played that square");
                Console.ResetColor();
                Choice();
            }
    }

void PlaceCheckAi(int x, int y, string symbol)
    {
        string mid = board[x];

        if (mid[y].ToString() == "-") 
            {
                PlaceX(x, y, symbol);
            }
        else if (mid[y].ToString() == "x" || mid[y].ToString() == "o")
            {
                Ai();
            }
    }

void Choice()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n\nWhere do you want to play?");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string userChoice = Console.ReadLine();
        Console.ResetColor();
        

        if (userChoice.ToString().ToLower() == "a1" || userChoice.ToString().ToLower() == "1a")
            {
                PlaceCheck(2, 3, "x");
            }
        else if (userChoice.ToString().ToLower() == "b1" || userChoice.ToString().ToLower() == "1b")
            {
                PlaceCheck(2, 9, "x");
            }
        else if (userChoice.ToString().ToLower() == "c1" || userChoice.ToString().ToLower() == "1c")
            {
                PlaceCheck(2, 15, "x");
            }
        else if (userChoice.ToString().ToLower() == "a2" || userChoice.ToString().ToLower() == "2a")
            {
                PlaceCheck(5, 3, "x");
            }
        else if (userChoice.ToString().ToLower() == "b2" || userChoice.ToString().ToLower() == "2b")
            {
                PlaceCheck(5, 9, "x");
            }
        else if (userChoice.ToString().ToLower() == "c2" || userChoice.ToString().ToLower() == "2c")
            {
                PlaceCheck(5, 15, "x");
            }
        else if (userChoice.ToString().ToLower() == "a3" || userChoice.ToString().ToLower() == "3a")
            {
                PlaceCheck(8, 3, "x");
            }
        else if (userChoice.ToString().ToLower() == "b3" || userChoice.ToString().ToLower() == "3b")
            {
                PlaceCheck(8, 9, "x");
            }
        else if (userChoice.ToString().ToLower() == "c3" || userChoice.ToString().ToLower() == "3c")
            {
                PlaceCheck(8, 15, "x");
            }
        else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nInvalid Response");
                Console.ResetColor();
                Choice();
            };
        CheckAll();
        Ai();
    }

void Ai()
    {
        Random rndspot = new Random();
        int spot = rndspot.Next(1, 10);
        if (spot == 1)
            {
                PlaceCheckAi(2, 3, "o");
            }
        else if (spot == 2)
            {
                PlaceCheckAi(2, 9, "o");
            }
        else if (spot == 3)
            {
                PlaceCheckAi(2, 15, "o");
            }
        else if (spot == 4)
            {
                PlaceCheckAi(5, 3, "o");
            }
         else if (spot == 5)
            {
                PlaceCheckAi(5, 9, "o");
            }
         else if (spot == 6)
            {
                PlaceCheckAi(5, 15, "o");
            }
         else if (spot == 7)
            {
                PlaceCheckAi(8, 3, "o");
            }
        else if (spot == 8)
            {
                PlaceCheckAi(8, 9, "o");
            }
        else if (spot == 9)
            {
                PlaceCheckAi(8, 15, "o");
            }
        else
            {
                Console.WriteLine("There was an error");
            }   
        CheckAll();
        Choice();
            }

void MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n\nMenu:\n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Start");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Quit\n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string menu = Console.ReadLine();
        Console.ResetColor();
        if (menu.ToLower() == "start")
            {
                Main();
            }
        else if (menu.ToLower() == "quit")
            {
                Environment.Exit(1);
            }
    }

MainMenu();