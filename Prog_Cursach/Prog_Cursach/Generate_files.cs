﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Prog_Cursach
{
    class Generate_files
    {
        private string nameFront = "",
            nameNature = "",
            nameMulti = "";
        private int count = 0,
            max = 0;

        Random random = new Random();

        public Generate_files(string nameF1, string nameF2, string nameF3,int n,int maxi)
        {
            nameFront = nameF1;
            nameNature = nameF2;
            nameMulti = nameF3;
            count = n;
            max = maxi;
        }

        public void Generate()
        {
            using (StreamWriter start = new StreamWriter(@"start.txt"))
            using (FileStream writerFront = File.Create(nameFront))
            using (BinaryWriter wrotrFront = new BinaryWriter(writerFront))
            using (FileStream writerNature = File.Create(nameNature))
            using (BinaryWriter wrotrNature = new BinaryWriter(writerNature))
            using (FileStream writerMulti = File.Create(nameMulti))
            using (BinaryWriter wrotrMulti = new BinaryWriter(writerMulti))
            {
                for (int i = 0; i < count; i++)
                {
                    int a = random.Next(2*max) - max;
                    wrotrFront.Write(a);
                    start.Write(a + " ");
                    wrotrNature.Write(a);
                    wrotrMulti.Write(a);
                }
            }
        }
    }
}
