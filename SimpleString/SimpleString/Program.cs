using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleString
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
     
        static int gol(string str)
        {
            int l = 0;
            char[] golosni = { 'а', 'е', 'и', 'о', 'у', 'і','я','ю','є','ї','ы','a','e','i','o','u','y' };
            for (int i = 0; i < golosni.Length; i++)
            {
                if (str.Contains(golosni[i])) l++;
            }
            return l;
        }// рахує голосні
               static int pr(string str)
        {
            int l = 0;
            char[] pri = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ш', 'щ','b','c','d','f','g','h','j','j','k','l','m','n','p','q','r','s','t','v','w','x','z'};
            for (int i = 0; i < pri.Length; i++)
            {
                if (str.Contains(pri[i])) l++;
            }
            return l;
        }// рахує приголосні
        static int compare(string[] text)
        { int l=0;
            for (int j=0; j<text.Length;j++)
                if (gol(text[j])== pr(text[j]) && text[j]!="") l++; 
           return l;
        } // рахує кількість слів з рівною кількістю голосних та приголосних 
        static void write(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }// виводить масив
        static string MaxLenghtOfWord(string[] text)
        {
            int max = text[0].Length, it = 0;

            for (int i = 1; i < text.Length; i++)
                if (text[i].Length > max) { max = text[i].Length; it = i; }
            return text[it];
        } // рахує максимальну довжину слова 
        static string ReVerce(string str)
        {  char tmp=' ';
           StringBuilder a=new StringBuilder(str);
        for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
        {
            tmp = str[i];
            a[i] = a[j];
            a[j] = tmp;
        }
            return a.ToString();
        }// робить слово в зворотньому порядку 
        static StringBuilder WriteWithoutReverce(string[] text,StringBuilder str)
        {
            string x = "";
            for (int i = 0; i < text.Length; i++)
             if (text[i]==ReVerce(text[i])&& text[i]!="" ) str.Replace(text[i],x);
            return str;
        }// виводить відформатовану строку за критерієм - крім слів паліндромів 
   


      
        static void Main(string[] args)
        {
            ConsoleConfig("Рядки");
             Console.WriteLine("Введіть текст який потрібно опрацювати : ");
          string str= Console.ReadLine();
          string[] a = str.Split(',', ' ','"','-','.','!','?',':',';','(',')','/'); // робить масив підстрок 
          //write(a); // для отладки 
          StringBuilder st = new StringBuilder(str);
            
            Console.WriteLine("\tКількість слів, які містять однакову кількість голосних і приголосних літер :"+compare(a));
            Console.WriteLine("\tВиводить на екран найдовше слово :" + MaxLenghtOfWord(a));
            Console.WriteLine("\tЗ видаленими з тексту всіх слів-паліндромів :" + WriteWithoutReverce(a, st));
          Console.ReadKey();
        }
    }
}
