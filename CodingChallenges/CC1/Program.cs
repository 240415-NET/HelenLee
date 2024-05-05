namespace CC1;

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    public static int rockGame(int b, int s, int t)
    {
        //Initialize 2 list to keep track of the amount each player takes in a turn
        List<int> SteveList = new List<int>();
        List<int> TommyList = new List<int>();

        while (b > 0)
        {
            int steveTaken = Math.Min(s, b);

            SteveList.Add(steveTaken);

            b -= steveTaken;

            if (b == 0)
                break;

            int tomTaken = Math.Min(t, b);

            TommyList.Add(tomTaken);

            b -= tomTaken;
        }

        int steveSum = SteveList.Sum();
        int tomSum = TommyList.Sum();

        //string winner = (steveSum > tomSum) ? "Steve" : "Tom";
        //int winnerSum = (winner == "Steve") ? steveSum : tomSum;

        //return winnerSum;

        int winner = (steveSum > tomSum) ? steveSum : tomSum;
        return winner;

      
    }

    //DO NOT TOUCH THE CODE BELOW

    public static void Main()
    {
        Console.WriteLine("Enter your inputs: ");
        int b = int.Parse(Console.ReadLine());

        int s = int.Parse(Console.ReadLine());

        int t = int.Parse(Console.ReadLine());

        Console.WriteLine(rockGame(b, s, t));
    }
}
