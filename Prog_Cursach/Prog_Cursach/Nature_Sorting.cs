using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class Nature_Sorting//природнє злиття 
    {
        string nameMain = "",//вхідний файл
            nameF1 = @"fNature1.txt",//проміжний файл №1
            nameF2 = @"fNature2.txt",//проміжний файл №2
            nameOut = "";// вихідний файл
        const int marker = Int32.MaxValue;//маркер кінця серії

        private int por = 0,//кількість порівннянь
               pere = 0;//кількіість перестановок

        public Int64 Por { get { return por; } }
        public Int64 Pere { get { return pere; } }

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

        public Nature_Sorting(string name,string nameOut)//конструктор класу
        {
            nameMain = name;
            this.nameOut = nameOut;
        }

        public void MakeSort()//виконання сортування
        {
            int a1 = 0, a2 = 0, mark;

            bool fl = true,
               fl1 = true,
               emp = true,
               emp1 = true;

            while (emp == true && emp1 == true)// цикл у якому відбувається сортування
            {
                mark = 1;
                fl = true;
                fl1 = true;
                emp = false;
                emp1 = false;

                using (FileStream file = File.OpenRead(nameMain))
                using (FileStream file1 = File.Create(nameF1))
                using (FileStream file2 = File.Create(nameF2))
                using (BinaryReader f = new BinaryReader(file))
                using (BinaryWriter f1 = new BinaryWriter(file1))
                using (BinaryWriter f2 = new BinaryWriter(file2))
                {
                    try
                    {
                        a1 = f.ReadInt32();//зчитування з початкового
                        f1.Write(a1);//запис у проміжний файл №1
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

                    while (fl == true)//цикл, де визначаються серії і розподіляються по файлам
                    {
                        por++;
                        if (a2 < a1)//зміна файлу для запису
                        {
                            if (mark == 1)
                            {
                                f1.Write(marker);
                                mark = 2;
                            }
                            else
                            {
                                f2.Write(marker);
                                mark = 1;
                            }
                        }

                        //запис у поточний файл
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

                    //додавання до поточного файлу маркеру кінця серії, після закінчення зчитування с вхідного файлу
                    if (emp == true && mark == 1)
                    {
                        f1.Write(marker);
                    }

                    if (emp1 == true && mark == 2)
                    {
                        f2.Write(marker);
                    }


                }

                fl = true;
                fl1 = true;

                using (FileStream file = File.Create(nameMain))
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

                    while (fl == true && fl1 == true)//упорядкування серій
                    {

                        while (a1 != marker && a2 != marker)
                        {
                            por++;
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
                                pere++;
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

                        while (a1 != Int32.MaxValue)//дозапис серії з першого файлу
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

                        while (a2 != marker)//дозапис серії с другого файлу
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



                    while (fl == true && a1 != marker)//дозапис з першого файлу
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

                    while (fl1 == true && a2 != marker)//дозапис з другого файлу
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

            //видалення проміжних файлів
            File.Delete(nameF1);
            File.Delete(nameF2);

            DeBinaireFile outFile = new DeBinaireFile(nameMain, nameOut);
            outFile.CreateTXT(true);//запис відсортованого файлу з бінарного файла у текстовий 
        }

    }
}
