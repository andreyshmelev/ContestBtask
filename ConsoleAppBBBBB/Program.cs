using System;
using System.Data;
using System.Diagnostics;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (StreamReader file = new StreamReader("C:\\work\\B\\tests\\10"))
            {
                var datasetsCount = int.Parse(file.ReadLine());
                

                for (var j = 0; j < datasetsCount; j++)
                {

                    while (!string.IsNullOrEmpty(file.ReadLine()))
                    {
                        ;
                    }

                    {

                        var inputStr = file.ReadLine().Split(" ");
                        var row_count = int.Parse(inputStr[0]);
                        var col_count = int.Parse(inputStr[1]);


                        int[,] gameAray = new int[row_count, col_count];

                        int[,] newgameAray = new int[row_count, col_count];



                        for (var row = 0; row < row_count; row++)
                        {

                            var inputsrt = file.ReadLine().Split(" ");
                            for (var col = 0; col < col_count; col++)
                            {
                                var inputchar = int.Parse(inputsrt[col]);
                                gameAray[row, col] = inputchar;
                                newgameAray[row, col] = inputchar;
                            }
                        }


                        var inputStr1 = file.ReadLine().Split(" ");
                        var numberClick = int.Parse(inputStr1[0]);
                  
                        var inputClick = file.ReadLine().Split(" "); ;
                        int[] clickersInt = new int[numberClick];

                        for (var click = 0; click < numberClick; click++)
                        {
                            int.TryParse(inputClick[click], out clickersInt[click]);

                        
                            int[] sortedColumn = new int[row_count];
                            int[] sortedindexes= new int[row_count];


                            for (var row = 0; row < row_count; row++)
                            {
                                sortedColumn[row] = gameAray[row, clickersInt[click] - 1];
                                sortedindexes[row] = row;
                            }

                            Array.Sort(sortedColumn,sortedindexes);



                            for (var row = 0; row < row_count; row++)
                            {

                                for (var col = 0; col < col_count; col++)
                                {
                                    newgameAray[row, col] = gameAray[sortedindexes[row], col];
                                }
                            }

                            for (var row = 0; row < row_count; row++)
                            {

                                for (var col = 0; col < col_count; col++)
                                {
                                    gameAray[row, col] = newgameAray[row, col];
                                }
                            }
                        }


                        for (var row = 0; row < row_count; row++)
                        {

                            for (var col = 0; col < col_count; col++)
                            {
                                Console.Write(newgameAray[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    Console.WriteLine();

                    }


                }

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }
        }
    }
}