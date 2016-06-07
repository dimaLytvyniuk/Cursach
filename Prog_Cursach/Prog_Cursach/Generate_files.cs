using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Prog_Cursach
{
    class Generate_files
    {
        private string nameFront = "",//вхідний файл для прямого злиття
            nameNature = "",//вхідний файл для природнього злиття
            nameMulti = "";//вхідний файл для збалансованого багатошляхового злиття

        private int count = 0,//к-ст елементів
            //діапазон
            max = 0,
            min = 0;

        bool fl = true,
            fl1 = true;

        Random random = new Random();

        public Generate_files(string nameF1, string nameF2, string nameF3,int n,int maxi,int min)//конструктор класу
        {
            nameFront = nameF1;
            nameNature = nameF2;
            nameMulti = nameF3;
            count = n;

            if (maxi > 0)
                max = maxi;
            else
            {
                fl = false;
                max = Math.Abs(maxi);
            }

            if (min < 0)
            {
                this.min = Math.Abs(min);
                fl1 = false;
            }
            else
                this.min = min;
        }

        public void Generate()//генерація файлів
        {

            using (FileStream writerFront = File.Create(nameFront))
            using (BinaryWriter wrotrFront = new BinaryWriter(writerFront))
            using (FileStream writerNature = File.Create(nameNature))
            using (BinaryWriter wrotrNature = new BinaryWriter(writerNature))
            using (FileStream writerMulti = File.Create(nameMulti))
            using (BinaryWriter wrotrMulti = new BinaryWriter(writerMulti))
            {
                int c = 0;
                for (int i = 0; i < count; i++)
                {

                    //генерація залежить від знаків max і min
                    if (fl && !fl1)
                        c = random.Next(max + 1) - random.Next(min + 1);
                    else
                    {
                        if(!fl && !fl1)
                        c = -(random.Next(max+1, min+1));
                        else
                        {
                            c = random.Next(min, max + 1);
                        }
                    }

                    wrotrFront.Write(c);
                    wrotrNature.Write(c);
                    wrotrMulti.Write(c);
                }
            }

        }
    }
}
