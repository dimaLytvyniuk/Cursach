using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFomFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

          using(StreamWriter writer=new StreamWriter("start.txt",false))
            {
                int c = 0;
                for (int i = 0; i < 4; i++)
                {
                    c = random.Next(100 + 1);

                    writer.Write(c + " ");
                }
            }
          
            using (StreamReader reader = new StreamReader("start.txt"))
            using (StreamWriter writer = new StreamWriter("finish.txt", false))
            {
                bool fl = true;

                string s;
                char ch='\0';

                while(ch!='\uffff')
                {
                    s = "";

                        ch = (char)reader.Read();

                    while (ch!= '\uffff' && ch !=' ')
                    {
                        s += ch;
                        ch = (char)reader.Read();
                    }

                    if (s != " ") 
                    writer.Write(s + " ");
                }
            }
        }
    }
}
