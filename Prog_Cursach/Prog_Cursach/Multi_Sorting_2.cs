using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class Multi_Sorting_2
    {
        const int marker = Int32.MaxValue;

        static int n = 0,
           lim = 0,
           m = 0;

        string nameMain = "";

        string[] namesA,
            namesB;


        public Multi_Sorting_2(string name, int count)
        {
            nameMain = name;
            n = count;
            m = (int)(Math.Round(Math.Sqrt(n)));

            namesA = new string[m];
            namesB = new string[m];
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

        private bool AnyTrue(bool[] gap,int c)
        {
            bool res = false;

            for (int i = 0; i < c; i++)
            {
                if (gap[i] == true)
                    res = true;
                break;
            }

            return res;
        }

        private bool AnyTrue(int[] gap, int c)
        {
            bool res = false;

            for (int i = 0; i < c; i++)
            {
                if (gap[i] != marker)
                    res = true;
                break;
            }

            return res;
        }

        private void CreateNames()
        {
            for (int i = 0; i < m; i++)
            {
                namesA[i] = "promA#" + i + ".txt";
                namesB[i]= "promB#" + i + ".txt";
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

            for (int i = 0; i < m; i++)
            {
                fl1[i] = true;
                length[i] = 0;

                files[i] = File.OpenWrite(namesA[i]);
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
                        currentFile.Write(marker);

                        while (fl2 == false)
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

                    if (length[l] == lim)
                    {
                        fl1[l] = false;
                        currentFile.Write(marker);
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

                if (length[l] != lim)
                    currentFile.Write(marker);

            }

            for (int i = 0; i < m; i++)
            {
                writers[i].Close();
                files[i].Close();
            }
        }

        public void SortFiles()
        {
            bool mark = false;

            int k = 0, min = 0, l = 0, count = m,tmp=0;

            FileStream[] filesRead = new FileStream[m],
                         files = new FileStream[m];
            BinaryReader[] readers = new BinaryReader[m];
            BinaryWriter[] writers = new BinaryWriter[m];
            BinaryWriter currentFile;

            bool[] fl = new bool[m],
                flOpen = new bool[m];
            int[] last = new int[m],
                length = new int[m];

            while(k!=1)
            {
                l = 0;
                tmp = 0;
                k = 0;

                for (int i = 0; i < count; i++)
                {
                    fl[i] = true;
                    flOpen[i] = true;

                    if (!mark)
                    {
                        filesRead[i] = File.OpenRead(namesA[i]);
                        files[i] = File.Create(namesB[i]);
                    }
                    else
                    {
                        filesRead[i] = File.OpenRead(namesB[i]);                       
                        files[i] = File.Create(namesA[i]);
                        
                    }

                    writers[i] = new BinaryWriter(files[i]);
                    readers[i] = new BinaryReader(filesRead[i]);
                }

                if (mark)
                    mark = false;
                else
                    mark = true;

                

                while(AnyTrue(fl,count))
                {
                    currentFile = writers[k];
                    k++;

                    for (int i = 0; i < count; i++)
                    {
                            try
                            {
                                last[i] = readers[i].ReadInt32();
                            }
                            catch (EndOfStreamException e)
                            {
                                fl[i] = false;
                            }
                        if (fl[i])
                            flOpen[i] = true;
                        else
                            flOpen[i] = false;
                    }

                    while (AnyTrue(flOpen,count))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (fl[i] && flOpen[i])
                            {
                                min = last[i];
                                l = i;
                                break;
                            }
                        }

                        for (int i = 0; i < count; i++)
                        {
                            if (fl[i] && flOpen[i])
                            {
                                if (min > last[i])
                                {
                                    min = last[i];
                                    l = i;
                                }
                            }
                        }

                            currentFile.Write(last[l]);

                        try
                        {
                            last[l] = readers[l].ReadInt32();
                        }
                        catch (EndOfStreamException e)
                        {
                            fl[l] = false;
                        }

                        if(last[l]==marker)
                        {
                            flOpen[l] = false;
                        }
                    }

                    currentFile.Write(marker);
                }

                for(int i=0;i<count;i++)
                {
                    readers[i].Close();
                    writers[i].Close();
                }

                count = k;
            }

            string s = "";

            if (mark)
                s = namesA[0];
            else
                s = namesB[0];

            DeBinaireFile outFile = new DeBinaireFile(s, "resMulti.txt");
            outFile.CreateTXT();


        }

        private void DeleteFiles()
        {
            for(int i=0;i< m;i++)
            {
                File.Delete(namesA[i]);
                File.Delete(namesB[i]);
            }
        }

        public void MakeSort()
        {
            CreateNames();
            DivideFiles();
            SortFiles();
            DeleteFiles();
        }
    }
}
