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

        private int por = 0,
                pere = 0;

        public Int64 Por { get { return por; } }
        public Int64 Pere { get { return pere; } }

        int n = 0,
           m = 0;

        string nameMain = "",
            nameOut = "";

        string[] namesA,
            namesB;


        public Multi_Sorting_2(string name, int count,string nameOut)
        {
            nameMain = name;
            this.nameOut = nameOut;
            n = count;

            if (n < 50000)
                m = 2;
            else
            {
                if (n < 2500000)
                    m = n / 25000;
                else
                    m = 100;
            }

            if (m % 2 == 1)
                m--;

            namesA = new string[m];
            namesB = new string[m];
        }

        Random random = new Random();

        private bool AnyTrue(bool[] gap,int c)
        {
            bool res = false;

            for (int i = 0; i < c; i++)
            {
                if (gap[i] == true)
                {
                    res = true;
                    break;
                }
                
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
            bool fl = true;
            bool[] fl1 = new bool[m];

            for (int i = 0; i < m; i++)
            {
                fl1[i] = true;

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
                    por++;

                    if (a1 < a2)
                    {
                        currentFile.Write(a2);
                    }
                    else
                    {
                        currentFile.Write(marker);

                            l++;
                            if (l >= m)
                                l = 0;

                                currentFile = writers[l];
                                currentFile.Write(a2);
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

                    currentFile.Write(marker);

                for(int i=0;i< m;i++)
                {
                    writers[i].Close();
                }
            }
        }

        public void SortFiles()
        {
            bool mark = false;

            int k = 0, min = 0, l = 0, count = m, tmp = 0;

            FileStream[] filesRead = new FileStream[m],
                         files = new FileStream[m];
            BinaryReader[] readers = new BinaryReader[m];
            BinaryWriter[] writers = new BinaryWriter[m];
            BinaryWriter currentFile;

            bool[] fl = new bool[m],
                flOpen = new bool[m],
                opening = new bool[m];
            int[] last = new int[m];

            while(k!=1)
            {
                l = 0;
                tmp = -1;
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
                    opening[i] = false;
                }

                if (mark)
                    mark = false;
                else
                    mark = true;

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

                while (AnyTrue(fl,count))
                {
                    tmp++;
                    

                    if (tmp == m)
                        tmp = 0;

                    currentFile = writers[tmp];

                    if (!opening[tmp])
                    {
                        k++;
                        opening[tmp] = true;
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
                                por++;
                                if (min > last[i])
                                {
                                    min = last[i];
                                    l = i;
                                }
                            }
                        }

                        if (tmp !=l)
                        pere++;

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
                }

                for (int i=0;i<count;i++)
                {
                    readers[i].Close();

                    writers[i].Close();
                }

                count = k;
            }

            string s = "";

            if (mark)
                s = namesB[0];
            else
                s = namesA[0];

            DeBinaireFile outFile = new DeBinaireFile(s, nameOut);
            outFile.CreateTXT(n);
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

        internal DeBinaireFile DeBinaireFile
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
