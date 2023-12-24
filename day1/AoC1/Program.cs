using System.Text.RegularExpressions;
using (StreamReader sr = File.OpenText("input.txt"))
{
    string s, pattern = "(zer(?=o)|on(?=e)|tw(?=o)|thre(?=e)|four|fiv(?=e)|six|seve(?=n)|eigh(?=t)|nin(?=e)|0|1|2|3|4|5|6|7|8|9)";
    int first = 0, last = 0, TotalSum = 0; /* character */
    //bool flag = false;
    Regex keywords = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    MatchCollection mc;
    Dictionary<string, int> numbers = new Dictionary<string, int>
    {{"zer",0},{"on",1},{"tw",2},{"thre",3},{"four",4},
    {"fiv",5},{"six",6},{"seve",7},{"eigh",8},{"nin",9}};

    while ((s = sr.ReadLine()) != null)
    {
        /*for (int i = 0; i < s.Length; i++)
        {
            character = System.Convert.ToInt32(
                System.Char.GetNumericValue(s[i]));
 
            if (character != -1)
            {
                if (!flag) //first hasnt been found yet
                {
                    first = character;
                    last = first;
                    flag = true;
                }
 
                //first has already been found
                last = character;
            }
        }
        */
        
        mc = keywords.Matches(s);

        if(mc.Count != 0)
        {        

            if(mc.First().Value.Length != 1)
            {
                first = numbers[mc.First().Value];
            }
            else
            {
                first = System.Convert.ToInt32(mc.First().Value);
            }

            if(mc.Last().Value.Length != 1)
            {
                last = numbers[mc.Last().Value];
            }
            else
            {
                last = System.Convert.ToInt32(mc.Last().Value);
            }
            System.Console.Write(first);
            System.Console.WriteLine(last);
            TotalSum += (first * 10) + last;
        }
        //flag = false;
    }
    System.Console.WriteLine(TotalSum);
}