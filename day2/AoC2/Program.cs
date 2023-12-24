using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using (StreamReader sr = File.OpenText("input.txt"))
{
    string s, pattern = @"(((?<=game\s)\d+)|(\d+\sr)|(\d+\sg)|(\d+\sb))";

    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    MatchCollection matches;

    int minRed = 0, minGreen = 0, minBlue = 0;
    //int currentGame, refRed = 12, refGreen = 13, refBlue = 14;
    int gamePower = 0;

    string[] substrings;
    
    List<int> possibleGames = new List<int>();


    while((s = sr.ReadLine()) != null)
    {
        matches = reg.Matches(s);

        //currentGame = System.Convert.ToInt32(matches.First().Value);
        
        for (int i=1; i < matches.Count; i++)
        {
            substrings = matches[i].Value.Split();
            if(substrings[1] == "r" && System.Convert.ToInt32(substrings[0]) > minRed)
            {
                minRed = System.Convert.ToInt32(substrings[0]);
            }
            if(substrings[1] == "g" && System.Convert.ToInt32(substrings[0]) > minGreen)
            {
                minGreen = System.Convert.ToInt32(substrings[0]);
            }
            if(substrings[1] == "b" && System.Convert.ToInt32(substrings[0]) > minBlue)
            {
                minBlue = System.Convert.ToInt32(substrings[0]);
            }
        }

        /*
        if(minRed <= refRed && minGreen <= refGreen && minBlue <= refBlue)
        {
            possibleGames.Add(currentGame);
        }
        */

        gamePower = minRed*minGreen*minBlue;

        possibleGames.Add(gamePower);

        minRed = minGreen = minBlue = 0;
    }
    
    int sumOfPossibleGameNumbers = 0;

    foreach(int game in possibleGames)
    {
        sumOfPossibleGameNumbers += game;
    }

    System.Console.WriteLine(sumOfPossibleGameNumbers);
}