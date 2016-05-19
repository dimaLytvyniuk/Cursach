using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Cursach
{
    class Main_Sort
    {
        int n, max, min, rozriads;

        string nameFront = "fileFront.txt",
           nameNature = "fileNature.txt",
           nameMulti = "fileMulti.txt",
            OutMerge = "resMerge.txt",
            OutNature = "resNature.txt",
            OutMulti = "resMulti.txt";

        public Main_Sort()
        {
            n = 10;
            max = 20;
            min = -20;
        }

        public Main_Sort(int n,int max,int min)
        {
            this.n = n;
            this.max = max;
            this.min = min;
            rozriads = Rozriads();

        }
        
        private int Rozriads()
        {
            int rozr = 0,
                val = max,
                rozrMin = 0;
            
            while(val!=0)
            {
                val=val/10;
                rozr++;
            }

            val = Math.Abs(min);

            while (val != 0)
            {
                val = val / 10;
                rozrMin++;
            }

            if (rozr >= rozrMin)
                return rozr;
            else
                return rozrMin;
        }

        public void GenerateFiles()
        {
            Generate_files generation = new Generate_files(nameFront, nameNature, nameMulti, n, max,min);
            generation.Generate();
        }

        public void Create_Merge()
        {
            Merge_Sort sortMerge = new Merge_Sort(nameFront, n,OutMerge,rozriads);
            sortMerge.MakeSort();
        }
        

        public void CreateNature()
        {
            Nature_Sorting sortNature = new Nature_Sorting(nameNature,OutNature,rozriads);
            sortNature.MakeSort();
        }
        
        public void CreateMulti()
        {
            Multi_Sorting_2 sortMulti = new Multi_Sorting_2(nameMulti, n,OutMulti,rozriads);
            sortMulti.MakeSort();
        }


    }
}
