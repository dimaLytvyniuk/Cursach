using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Prog_Cursach
{
    class Main_Sort
    {
        int n, max, min;

        public Int64 PereMulti { get; private set; }//  кількість перестановок у Збалансованому багатошляховому злитті
        public Int64 PorMulti { get; private set; }// кількість порівнянь у Збалансованому багатошляховому злитті
        public Int64 PereNature { get; private set; }//  кількість перестановок у природньому злитті
        public Int64 PorNature { get; private set; }// кількість порівнянь у природньому злитті
        public Int64 PereMerge { get; private set; }//  кількість перестановок у прямому злитті
        public Int64 PorMerge { get; private set; }// кількість порівнянь у прямому злитті

        string nameFront = "fileFront.txt",//вхідний файл для прямого злиття
           nameNature = "fileNature.txt",//вхідний файл для природнього злиття
           nameMulti = "fileMulti.txt",//вхідний файл для збалансованого багатошляхового злиття
            OutMerge = "resMerge.txt",//вихідний файл для прямого злиття
            OutNature = "resNature.txt",//вихідний файл для природнього злиття
            OutMulti = "resMulti.txt",//вихідний файл для збалансованого багатошляхового злиття
            nameStart = "start.txt";//початковий файл у текстовому форматі

        public Main_Sort()
        {
            n = 10;
            max = 20;
            min = -20;
        }

        public Main_Sort(int n, int max, int min)// конструктор класу n-кількість елемнтів max-максимальне min- мінімальне
        {
            this.n = n;
            this.max = max;
            this.min = min;
        }


        public void GenerateFiles()// метод для генерації вхідного файлу
        {
            Generate_files generation = new Generate_files(nameFront, nameNature, nameMulti, n, max, min);
            generation.Generate();//генерація файлу

            DeBinaireFile start = new DeBinaireFile(nameFront, nameStart); 
            start.CreateTXT(false);//створення с бінарного файлу текстовий
        }

        public void Create_Merge()//пряме злиття
        {
            Merge_Sort sortMerge = new Merge_Sort(nameFront, n, OutMerge);
            sortMerge.MakeSort();//виконання сортування
            PereMerge = sortMerge.Pere;//статистика
            PorMerge = sortMerge.Por;
        }


        public void CreateNature()//природнє злиття
        {
            Nature_Sorting sortNature = new Nature_Sorting(nameNature, OutNature);
            sortNature.MakeSort();//сортування
            PereNature = sortNature.Pere;//статистика
            PorNature = sortNature.Por;
        }

        public void CreateMulti()//збалансоване багатошляхове злиття
        {
            Multi_Sorting_2 sortMulti = new Multi_Sorting_2(nameMulti, n, OutMulti);
            sortMulti.MakeSort();//сортування
            PereMulti = sortMulti.Pere;//статистика
            PorMulti = sortMulti.Por;
        }

        public void ShowMulti()//відкриває відсортований збалансованим багатошляховим злиттям текстовий файл
        {
            Process.Start(OutMulti);
        }

        public void ShowNature()//відкриває відсортований природнім злиттям текстовий файл
        {
            Process.Start(OutNature);
        }

        public void ShowMerge()//відкриває відсортований прямим злиттям текстовий файл
        {
            Process.Start(OutMerge);
        }

        public void ShowStart()//відкриває відсортований збалансованим багатошляховим злиттям текстовий файл
        {
            Process.Start(nameStart);
        }

        internal Merge_Sort Merge_Sort
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Multi_Sorting_2 Multi_Sorting_2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Nature_Sorting Nature_Sorting
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Generate_files Generate_files
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
