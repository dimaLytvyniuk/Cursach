using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class DeBinaireFile//створення с бінарного файлу текстового
    {
        private string nameMain="",//ім'я вхідного файлу
            outName = "";//ім'я вихідного файлу

        public DeBinaireFile(string inName,string outputName)//конструктор класу
        {
            nameMain = inName;
            outName = outputName;
        }

        public void CreateTXT(bool top)//створення .txt , якщо параметр bool
        {
            using (StreamWriter writer = new StreamWriter(outName,false))
            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader reader = new BinaryReader(file))
            {
                int y = 0;
                bool fl = true;

                 while (fl)
                {
                    for (int i = 0; i < 92 && fl; i++)
                    {
                        try
                        {
                            y = reader.ReadInt32();
                            writer.Write(String.Format("{0,11}",y));
                        }
                        catch (EndOfStreamException e)
                        {
                            fl = false;
                        }
                    }
                    writer.WriteLine();
                }
            }

            if(top)
            File.Delete(nameMain);//видалення бінарного файлу
        }

        public void CreateTXT(int m)//створення .txt , якщо параметр int
        {
            using (StreamWriter writer = new StreamWriter(outName, false))
            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader reader = new BinaryReader(file))
            {
                int y = 0, i = 0;


                for (int j = 0; j < m; j++)
                {

                    i++;

                    try
                    {
                        y = reader.ReadInt32();
                        writer.Write(String.Format("{0,11}", y));
                    }
                    catch (EndOfStreamException e)
                    {

                    }

                    if (i == 91)
                    {
                        i = 0;
                        writer.WriteLine();
                    }
                }
            }

            File.Delete(nameMain);//видалення вхідного файлу
        }
        
    }
}
