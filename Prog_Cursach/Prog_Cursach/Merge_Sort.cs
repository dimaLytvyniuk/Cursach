using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class Merge_Sort
    {
        string nameMain="",
             nameF1 = "f1.txt",
                nameF2 = "f2.txt";
        int count = 0;

        public Merge_Sort(string name,int n)
        {
            nameMain = name;
            count = n;
        }

        public void MakeSort()
        {
            int a1 = 0, a2 = 0, k = 1;
            bool fl = true,
                fl1 = true;


            while (k < count)
            {
                using (FileStream file = File.OpenRead(nameMain))
                using (BinaryReader f = new BinaryReader(file))
                using (FileStream file1 = File.Create(nameF1))
                using (FileStream file2 = File.Create(nameF2))
                using (BinaryWriter f1 = new BinaryWriter(file1))
                using (BinaryWriter f2 = new BinaryWriter(file2))
                {
                    a1 = f.ReadInt32();

                    fl = true;
                    fl = true;

                    while (fl == true)
                    {

                        for (int i = 0; i < k && fl == true; i++)
                        {
                            try
                            {
                                f1.Write(a1);
                                a1 = f.ReadInt32();
                            }
                            catch (EndOfStreamException e)
                            {
                                fl = false;
                            }
                        }

                        for (int j = 0; j < k && (fl == true); j++)
                        {
                            try
                            {
                                f2.Write(a1);
                                a1 = f.ReadInt32();
                            }
                            catch (EndOfStreamException e)
                            {
                                fl = false;
                            }
                        }
                    }

                }

                using (FileStream file1 = File.OpenRead(nameF1))
                using (FileStream file = File.Create(nameMain))
                using (BinaryWriter f = new BinaryWriter(file))
                using (FileStream file2 = File.OpenRead(nameF2))
                using (BinaryReader f1 = new BinaryReader(file1))
                using (BinaryReader f2 = new BinaryReader(file2))
                {
                    fl = true;
                    fl1 = true;

                    try
                    {
                        a1 = f1.ReadInt32();
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }

                    try
                    {
                        a2 = f2.ReadInt32();
                    }
                    catch (EndOfStreamException e)
                    {
                        fl1 = false;
                    }

                    while (fl == true && fl1 == true)
                    {
                        int i = 0;
                        int j = 0;

                        while (i < k && j < k && (fl == true) && (fl1 == true))
                        {
                            if (a1 < a2)
                            {
                                f.Write(a1);
                                try
                                {
                                    a1 = f1.ReadInt32();
                                    i++;
                                }
                                catch (EndOfStreamException e)
                                {
                                    fl = false;
                                }
                            }
                            else
                            {

                                f.Write(a2);
                                try
                                {
                                    a2 = f2.ReadInt32();
                                    j++;
                                }
                                catch (EndOfStreamException e)
                                {
                                    fl1 = false;
                                }
                            }
                        }

                        while (i < k && (fl))
                        {

                            f.Write(a1);
                            try
                            {
                                a1 = f1.ReadInt32();
                                i++;
                            }
                            catch (EndOfStreamException e)
                            {
                                fl = false;
                            }
                        }

                        while (j < k && (fl1))
                        {

                            f.Write(a2);
                            try
                            {
                                a2 = f2.ReadInt32();
                                j++;
                            }
                            catch (EndOfStreamException e)
                            {
                                fl1 = false;
                            }
                        }
                    }

                    while (fl)
                    {

                        f.Write(a1);
                        try
                        {
                            a1 = f1.ReadInt32();
                        }
                        catch (EndOfStreamException e)
                        {
                            fl = false;
                        }
                    }

                    while (fl1)
                    {

                        f.Write(a2);
                        try
                        {
                            a2 = f2.ReadInt32();
                        }
                        catch (EndOfStreamException e)
                        {
                            fl1 = false;
                        }
                    }

                }

                k *= 2;
            }

            File.Delete(nameF1);
            File.Delete(nameF2);

            DeBinaireFile outFile = new DeBinaireFile(nameMain, "resMerge.txt");
            outFile.CreateTXT();
        }
        
    }
}
