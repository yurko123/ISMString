using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleStrings2
{
    class Program
    {
        static void ConsoleConfig(string title)
        {
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(1251);// для українських букв
            Console.InputEncoding = Encoding.GetEncoding(1251); // для українських букв

        }
        static int CountPrGl(string text)
        {
            Regex regexp = new Regex(@"\b[a-zA-z_0-9а-яА-Я'ІЇЄіїє\-]+\b");
            Regex gol = new Regex(@"[аеиоуіяюєїыaeiouyАЕИОУІЯЮЄЇЫAEIOUY]");
            Regex pr = new Regex(@"[бвгджзйклмнпрстфхцшщbcdfghjjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦШЩBCDFGHJJKLMNPQRSTVWXZ]");
            Match match = regexp.Match(text);
            MatchCollection matchGol = gol.Matches(match.Value);
            MatchCollection matchPr = pr.Matches(match.Value);
            int l = 0;
            while (match.Length > 0)
            {

                matchGol = gol.Matches(match.Value);
                matchPr = pr.Matches(match.Value);
                if (matchGol.Count == matchPr.Count) l++;
                match = match.NextMatch();
            }
            return l;
        }
        static string toolongword (string text)
    {   
        Regex regexp = new Regex(@"\b[a-zA-z_0-9а-яА-Я'ІЇЄіїє\-]+\b");
        Match match = regexp.Match(text) ;
        string res = "";
        int max = 0;
        while (match.Length > 0) 
        {
            if (match.Length > max) { max = match.Length; res = match.Value; }
            match = match.NextMatch();
        }
        return res;

    }
        static string ReVerce(string str)
        {
            char tmp = ' ';
            StringBuilder a = new StringBuilder(str);
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                tmp = str[i];
                a[i] = a[j];
                a[j] = tmp;
            }
            return a.ToString();
        }
        static void reverce (string text)
        {
            Regex regexp = new Regex(@"\b[a-zA-z_0-9а-яА-Я'ІЇЄіїє\-]+\b");
            Match match = regexp.Match(text);
            while (match.Length > 0)
            {
                if (match.Value == ReVerce(match.Value)) Console.WriteLine("поліндром : " + match.Value);
                match = match.NextMatch();
            }
        }
        static void Main(string[] args)
        {
            ConsoleConfig("Регулярні вирази");
            string text = Console.ReadLine();
            text= text.ToLower();
            Console.WriteLine("кількість слів, які містять однакову кількість голосних і приголосних літер :" + CountPrGl(text));
            Console.WriteLine("найдовше слово: " + toolongword(text));
            reverce(text);
            Console.ReadKey();
        }
    }
}