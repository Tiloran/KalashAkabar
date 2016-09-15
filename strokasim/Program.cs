using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strokasim
{
    class Program
    {
        static void Main(string[] args)
        {
            string kalash = "АллахАкбарКалаш";
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
            Console.Write("MAX="+ intcount[index].ToString() + " Char is " + stringname[index]);
            Console.Read();
        }



        

    }
}
