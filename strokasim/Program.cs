using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strokasim
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            string kalash = null;
            for (int j = 0; j < 10000; j++)
            {
                Random r = new Random();
                int i = r.Next(chars.Length);
                kalash += Char.ToString(chars[i]);                
            }
            
            DateTime Start; // Время запуска
            DateTime Stoped; //Время окончания
            TimeSpan Elapsed = new TimeSpan(); // Разница
            Start = DateTime.Now; // Старт (Записываем время)
            
            string[] stringname = new string[kalash.Length];
            int[] intcount = new int[kalash.Length];
            for (int i=0; i<stringname.Length; i++)
            {
                bool exist = false;
                int RememberEmptySlot = -1;
                int RememberFullSlot = -1;
                for( int j=0; j<stringname.Length; j++)
                {
                    if(kalash.Substring(i,1)==stringname[j])
                    {
                        exist = true;
                        RememberFullSlot = j;
                    }
                    else if(stringname[j]==null && RememberEmptySlot==-1)
                    {
                        RememberEmptySlot = j;
                    }                    
                }
                if(exist==false)
                {
                    stringname[RememberEmptySlot] = kalash.Substring(i, 1);
                    intcount[RememberEmptySlot] += 1;
                }
                else
                {
                    intcount[RememberFullSlot] += 1;
                }
                exist = false;
                RememberEmptySlot = -1;
            }
            int max = 0;
            int index = -1;
            for(int i=0; i<intcount.Length;i++)
            {
                if(max<intcount[i])
                {
                    max = intcount[i];
                    index = i;
                }
            }
            Stoped = DateTime.Now; // Стоп (Записываем время)
            Elapsed = Stoped.Subtract(Start); // Вычитаем из Stoped (когда код выполнился) время Start (когда код запустили на выполнение)
            Console.Write("MAX="+ intcount[index].ToString() + " Char is " + stringname[index]+" ms "+ Convert.ToString(Elapsed.TotalMilliseconds));

            Console.Read();
        }


        





    }
}
