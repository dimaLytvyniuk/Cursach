using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class Multi_Sorting
    {
        static int n = 0,
            lim = 0,
            m = 0;

        string nameMain ="";

        string[] names;

        public Multi_Sorting(string name,int count)
        {
            nameMain = name;
            n = count;
            m = (int)(Math.Round(Math.Sqrt(n)));

            names = new string[m];
        }

        Random random = new Random();

        private void CreateToCompare()
        {
            double r = Math.Sqrt(n);

            if (m > r)
                lim = m;
            else
                lim = m + 1;
        }

        private bool AnyTrue(bool[] gap)
        {
            bool res = false;

            for (int i = 0; i < m; i++)
            {
                if (gap[i] == true)
                    res = true;
                break;
            }

            return res;
        }

        /*private void CreateFiles()
        {
            using (StreamWriter start = new StreamWriter(@"D:\files\start2.txt"))
            using (FileStream writer = File.Create(nameMain))
            using (BinaryWriter wrotr = new BinaryWriter(writer))
            {
                for (int i = 0; i < n; i++)
                {
                    int a = random.Next(40) - 20;
                    wrotr.Write(a);
                    start.Write(a);
                    start.Write(" ");
                }
            }
        }
        */

        private void CreateNames()
        {
            for (int i = 0; i < m; i++)
            {
                names[i] = "prom#" + i + ".txt";
            }
        }

        private void DivideFiles()
        {
            FileStream[] files = new FileStream[m];
            BinaryWriter[] writers = new BinaryWriter[m];
            BinaryWriter currentFile;
            int a1 = 0,
                a2 = 0,
                l = 0;
            bool fl = true, fl2 = false;
            bool[] fl1 = new bool[m];
            int[] length = new int[m];

            CreateToCompare();

            for(int i=0;i< m;i++)
            {
                fl1[i] = true;
                length[i] = 0;

                files[i] = File.OpenWrite(names[i]);
                writers[i] = new BinaryWriter(files[i]);
            }

            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader f = new BinaryReader(file))
            {

                try
                {
                    a1 = f.ReadInt32();
                }
                catch (EndOfStreamException e)
                {
                    fl = false;
                }

                currentFile = writers[l];
                currentFile.Write(a1);
                length[l]++;


                try
                {
                    a2 = f.ReadInt32();
                }
                catch (EndOfStreamException e)
                {
                    fl = false;
                }


                while (fl == true)
                {
                    if ((a1 < a2) && fl1[l] == true)
                    {
                        currentFile.Write(a2);
                        length[l]++;
                    }
                    else
                    {

                        while (fl2==false)
                        {
                            l++;
                            if (l >= m)
                                l = 0;

                            if (fl1[l] == true)
                            {
                                currentFile = writers[l];
                                currentFile.Write(a2);
                                length[l]++;

                                break;
                            }
                        }
                        
                    }

                    if (length[l] ==lim)
                        fl1[l] = false;

                    a1 = a2;

                    try
                    {
                        a2 = f.ReadInt32();
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }
                }

            }

            for (int i = 0; i < m; i++)
            {
                writers[i].Close();
                files[i].Close();
            }
        }

        private void SortFile(string name)
        {
            bool fl = true,
                fl1 = true,
                emp = true,
                emp1 = true;

            int a1 = 0, a2 = 0, mark;
            string nameF1 = @"fNature1.txt",
                nameF2 = @"fNature2.txt";

            while (emp == true && emp1 == true)
            {
                mark = 1;
                fl = true;
                fl1 = true;
                emp = false;
                emp1 = false;

                using (FileStream file = File.OpenRead(name))
                using (FileStream file1 = File.Create(nameF1))
                using (FileStream file2 = File.Create(nameF2))
                using (BinaryReader f = new BinaryReader(file))
                using (BinaryWriter f1 = new BinaryWriter(file1))
                using (BinaryWriter f2 = new BinaryWriter(file2))
                {
                    try
                    {
                        a1 = f.ReadInt32();
                        f1.Write(a1);
                        emp = true;
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }

                    try
                    {
                        a2 = f.ReadInt32();
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }

                    while (fl == true)
                    {
                        if (a2 < a1)
                        {
                            if (mark == 1)
                            {
                                f1.Write(Int32.MaxValue);
                                mark = 2;
                            }
                            else
                            {
                                f2.Write(Int32.MaxValue);
                                mark = 1;
                            }
                        }

                        if (mark == 1)
                        {
                            f1.Write(a2);
                        }
                        else
                        {
                            f2.Write(a2);
                            emp1 = true;
                        }

                        a1 = a2;

                        try
                        {
                            a2 = f.ReadInt32();
                        }
                        catch (EndOfStreamException e)
                        {
                            fl = false;
                        }
                    }

                    if (emp == true && mark == 1)
                    {
                        f1.Write(Int32.MaxValue);
                    }

                    if (emp1 == true && mark == 2)
                    {
                        f2.Write(Int32.MaxValue);
                    }


                }

                fl = true;
                fl1 = true;

                using (FileStream file = File.Create(name))
                using (FileStream file1 = File.OpenRead(nameF1))
                using (FileStream file2 = File.OpenRead(nameF2))
                using (BinaryWriter f = new BinaryWriter(file))
                using (BinaryReader f1 = new BinaryReader(file1))
                using (BinaryReader f2 = new BinaryReader(file2))
                {
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

                        while (a1 != Int32.MaxValue && a2 != Int32.MaxValue)
                        {
                            if (a1 <= a2)
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
                            else
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

                        while (a1 != Int32.MaxValue)
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

                        while (a2 != Int32.MaxValue)
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

                    }



                    while (fl == true && a1 != Int32.MaxValue)
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

                    while (fl1 == true && a2 != Int32.MaxValue)
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
            }

        }

        private void SortFiles()
        {
            for(int i=0;i< m;i++)
            {
                SortFile(names[i]);
            }
        }

        private void CreateNewFile()
        {
            bool[] fl = new bool[m];
            int[] last = new int[m];
            FileStream[] filesRead = new FileStream[m];
            BinaryReader[] readers = new BinaryReader[m];
            int min = 0, l = 0;

            for (int i=0;i< m;i++)
            {
                fl[i] = true;

                filesRead[i] = File.OpenRead(names[i]);
                readers[i] = new BinaryReader(filesRead[i]);
            }

            for (int i = 0; i < m; i++)
            {
                if (fl[i])
                {
                    try
                    {
                        last[i] = readers[i].ReadInt32();
                    }
                    catch (EndOfStreamException e)
                    {
                        fl[i] = false;
                    }
                }
            }

            using (FileStream file = File.Create(nameMain))
            using (BinaryWriter f = new BinaryWriter(file))
            {
                while(AnyTrue(fl))
                {

                    for (int i = 0; i < m; i++)
                    {
                        if (fl[i])
                        {
                            min = last[i];
                            l = i;
                            break;
                        }
                    }

                    for (int i = 0; i < m; i++)
                    {
                        if (fl[i])
                        {
                            if (min > last[i])
                            {
                                min = last[i];
                                l = i;
                            }
                        }
                    }


                    f.Write(last[l]);

                            try
                            {
                                last[l] = readers[l].ReadInt32();
                            }
                            catch (EndOfStreamException e)
                            {
                                fl[l] = false;
                            }
                }
            }

            for(int i=0;i< m;i++)
            {
                readers[i].Close();
                File.Delete(names[i]);
            }
        }

       

        public void MakeSort()
        {
            CreateNames();
            DivideFiles();
            SortFiles();
            CreateNewFile();

            DeBinaireFile outFile = new DeBinaireFile(nameMain, "resMulti.txt");
            outFile.CreateTXT();

        }
    }
}
