using System;
using System.Text.RegularExpressions;

using (StreamReader sr = File.OpenText("input.txt"))
{
    Regex regNumbers = new Regex(@"(\d+)", RegexOptions.Singleline);
    Regex regSymbols = new Regex(@"([*])",RegexOptions.Singleline);// this was part 1's pattern. -> [^a-zA-Z0-9_.]

    List<Match> partNumbers = new List<Match>();
    List<Match> attachedNumbers = new List<Match>();
    List<int> gearRatios = new List<int>();
    MatchCollection numbers1, numbers2, numbers3, symbols1, symbols2;

    int counter = 0, attachedNumbersCount;
    string s1 = "", s2 = "", s3 = "";
    while((s3 = sr.ReadLine()) != null)
    {
        counter++;
        if(counter>=3)
        {
            numbers1 = regNumbers.Matches(s1);
            
            numbers2 = regNumbers.Matches(s2);
            symbols2 = regSymbols.Matches(s2);

            numbers3 = regNumbers.Matches(s3);
            
            if(counter==3)
            {
                symbols1 = regSymbols.Matches(s1);
                foreach(Match symbol in symbols1)
                {
                    attachedNumbersCount = 0;
                    foreach(Match number in numbers1)
                    {
                        if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
                        {
                            attachedNumbersCount++;
                            attachedNumbers.Add(number);
                            if(!partNumbers.Contains(number))partNumbers.Add(number);
                        }
                        if(number.Index>(symbol.Index + 1)) break;
                    }

                    foreach(Match number in numbers2)
                    {
                        if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
                        {
                            attachedNumbersCount++;
                            attachedNumbers.Add(number);
                            if(!partNumbers.Contains(number))partNumbers.Add(number);
                        }
                        if(number.Index>(symbol.Index + 1)) break;
                    }

                    if(attachedNumbersCount == 2)
                    {
                        gearRatios.Add(Convert.ToInt32(attachedNumbers.First().Value)
                                        * Convert.ToInt32(attachedNumbers.Last().Value));
                    }
                    attachedNumbers.Clear();
                }
            }

            foreach(Match symbol in symbols2)
            {
                attachedNumbersCount = 0;
                foreach(Match number in numbers1)
                {
                    if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
                    {
                        attachedNumbersCount++;
                        attachedNumbers.Add(number);
                        if(!partNumbers.Contains(number))partNumbers.Add(number);
                    }
                    if(number.Index>(symbol.Index + 1)) break;
                }

                foreach(Match number in numbers2)
                {
                    if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
                    {
                        attachedNumbersCount++;
                        attachedNumbers.Add(number);
                        if(!partNumbers.Contains(number))partNumbers.Add(number);
                    }
                    if(number.Index>(symbol.Index + 1)) break;
                }

                foreach(Match number in numbers3)
                {
                    if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
                    {
                        attachedNumbersCount++;
                        attachedNumbers.Add(number);
                        if(!partNumbers.Contains(number))partNumbers.Add(number);
                    }
                    if(number.Index>(symbol.Index + 1)) break;
                }
                if(attachedNumbersCount == 2)
                {
                    gearRatios.Add(Convert.ToInt32(attachedNumbers.First().Value)
                                    * Convert.ToInt32(attachedNumbers.Last().Value));
                }
                attachedNumbers.Clear();
            }
            //
        }

        s1=s2;
        s2=s3;
    }

    numbers1 = regNumbers.Matches(s1);
            
    numbers2 = regNumbers.Matches(s2);
    symbols2 = regSymbols.Matches(s2);
            
    foreach(Match symbol in symbols2)
    {
        attachedNumbersCount = 0;
        foreach(Match number in numbers1)
        {
            if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
            {
                attachedNumbersCount++;
                attachedNumbers.Add(number);
                if(!partNumbers.Contains(number))partNumbers.Add(number);
            }
            if(number.Index>(symbol.Index + 1)) break;
        }

        foreach(Match number in numbers2)
        {
            if(number.Index>=(symbol.Index - number.Length) && number.Index<=(symbol.Index + 1))
            {
                attachedNumbersCount++;
                attachedNumbers.Add(number);
                if(!partNumbers.Contains(number))partNumbers.Add(number);
            }
            if(number.Index>(symbol.Index + 1)) break;
        }
        if(attachedNumbersCount == 2)
        {
            gearRatios.Add(Convert.ToInt32(attachedNumbers.First().Value)
                            * Convert.ToInt32(attachedNumbers.Last().Value));
        }
        attachedNumbers.Clear();
    }

    counter = 0;

    /*
    foreach(Match number in partNumbers)
    {
        counter += Convert.ToInt32(number.Value);
    }
    */

    foreach(int number in gearRatios)
    {
        counter += number;
    }

    Console.WriteLine(counter);
}