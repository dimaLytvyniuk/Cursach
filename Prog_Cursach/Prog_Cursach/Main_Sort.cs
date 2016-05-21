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

        public int PereMulti { get; private set; }
        public int PorMulti { get; private set; }
        public int PereNature { get; private set; }
        public int PorNature { get; private set; }
        public int PereMerge { get; private set; }
        public int PorMerge { get; private set; }

        string nameFront = "fileFront.txt",
           nameNature = "fileNature.txt",
           nameMulti = "fileMulti.txt",
            OutMerge = "resMerge.txt",
            OutNature = "resNature.txt",
            OutMulti = "resMulti.txt",
            nameStart = "start.txt";

        public Main_Sort()
        {
            n = 10;
            max = 20;
            min = -20;
        }

        public Main_Sort(int n, int max, int min)
        {
            this.n = n;
            this.max = max;
            this.min = min;
        }


        public void GenerateFiles()
        {
            Generate_files generation = new Generate_files(nameFront, nameNature, nameMulti, n, max, min);
            generation.Generate();

            DeBinaireFile start = new DeBinaireFile(nameFront, nameStart);
            start.CreateTXT(false);
        }

        public void Create_Merge()
        {
            Merge_Sort sortMerge = new Merge_Sort(nameFront, n, OutMerge);
            sortMerge.MakeSort();
            PereMerge = sortMerge.Pere;
            PorMerge = sortMerge.Por;
        }


        public void CreateNature()
        {
            Nature_Sorting sortNature = new Nature_Sorting(nameNature, OutNature);
            sortNature.MakeSort();
            PereNature = sortNature.Pere;
            PorNature = sortNature.Por;
        }

        public void CreateMulti()
        {
            Multi_Sorting_2 sortMulti = new Multi_Sorting_2(nameMulti, n, OutMulti);
            sortMulti.MakeSort();
            PereMulti = sortMulti.Pere;
            PorMulti = sortMulti.Por;
        }

        public void ShowMulti()
        {
            Process.Start(OutMulti);
        }

        public void ShowNature()
        {
            Process.Start(OutNature);
        }

        public void ShowMerge()
        {
            Process.Start(OutMerge);
        }

        public void ShowStart()
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
