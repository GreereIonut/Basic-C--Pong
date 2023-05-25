
internal class Program
{

    private static void Main(string[] args)
    {
        const int fieldLength = 50;
        const int fieldWidth = 15;
        const char fieldTile = '#';

        int leftracketHeight = 0;
        int rightracketHeight = 0;

        const int racketLength = fieldWidth / 4;
        const char racketTile = '|';

        int ballX = fieldLength / 2;
        int ballY = fieldWidth / 2;
        const char ballTile = 'O';

        bool isGoingDown = true;
        bool isGoingRight = true;

        int leftPlayerPoints = 0;
        int rightPlayerPoints = 0;

        int scoreBoardX = 55;
        int scoreBoardY = 7;


        string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

        Console.SetCursorPosition(scoreBoardX, scoreBoardY);
        Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");


        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(line);

            Console.SetCursorPosition(0, fieldWidth);
            Console.WriteLine(line);



            for (int i = 0; i < racketLength; i++)
            {

                if (leftracketHeight >= fieldWidth - 3 || rightracketHeight >= fieldWidth - 3)
                    continue;
                Console.SetCursorPosition(0, i + 1 + leftracketHeight);
                Console.WriteLine(racketTile);


            }

            for (int i = 0; i < racketLength; i++)
            {


                Console.SetCursorPosition(0, i + 1 + leftracketHeight);
                Console.WriteLine(racketTile);

                Console.SetCursorPosition(fieldLength - 1, i + 1 + rightracketHeight);
                Console.WriteLine(racketTile);
            }

            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition(ballX, ballY);
                System.Console.WriteLine(ballTile);
                Thread.Sleep(50);

                Console.SetCursorPosition(ballX, ballY);
                System.Console.WriteLine(" ");

                if (isGoingDown)
                {
                    ballY++;
                }
                else
                    ballY--;

                if (isGoingRight)
                {
                    ballX++;
                }
                else
                    ballX--;

                if (ballY == 1 || ballY == fieldWidth - 1)
                {
                    isGoingDown = !isGoingDown;
                }

                if (ballX == 1)
                {
                    if (ballY >= leftracketHeight + 1 && ballY <= leftracketHeight + racketLength)
                    {
                        isGoingRight = !isGoingRight;
                    }

                    else
                    {
                        rightPlayerPoints++;
                        ballY = fieldWidth / 2;
                        ballX = fieldLength / 2;
                        Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                        Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");


                    }

                }

                if (leftPlayerPoints == 10)
                {
                    goto outer;
                }
                if (ballX == fieldLength - 2)
                {
                    if (ballY >= rightracketHeight + 1 && ballY <= rightracketHeight + racketLength)
                    {
                        isGoingRight = !isGoingRight;
                    }
                    else
                    {
                        leftPlayerPoints++;
                        ballY = fieldWidth / 2;
                        ballX = fieldLength / 2;
                        Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                        Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");

                    }
                }

                if (rightPlayerPoints == 10)
                {
                    goto outer;
                }



            }

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (rightracketHeight > 0)
                    {
                        rightracketHeight--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (rightracketHeight < fieldWidth - racketLength - 1)
                    {
                        rightracketHeight++;
                    }
                    break;
                case ConsoleKey.W:
                    if (leftracketHeight > 0)
                    {
                        leftracketHeight--;
                    }
                    break;
                case ConsoleKey.S:
                    if (leftracketHeight < fieldWidth - racketLength - 1)
                    {
                        leftracketHeight++;
                    }
                    break;
            }



            for (int i = 1; i < fieldWidth; i++)
            {


                Console.SetCursorPosition(fieldLength - 1, i);
                Console.WriteLine(" ");
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ");

            }


       










        }

         outer:;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            if (leftPlayerPoints == 10)
            {
                System.Console.WriteLine("Left Player won!!!");
            }
            else
            {
                System.Console.WriteLine("Right Player won!!!");
            }

            Console.ReadLine();
            


    }


}