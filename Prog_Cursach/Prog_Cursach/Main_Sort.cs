using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Cursach
{
    class Main_Sort
    {
        int n, max, min;

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
        }
        

        public void GenerateFiles()
        {
            Generate_files generation = new Generate_files(nameFront, nameNature, nameMulti, n, max,min);
            generation.Generate();
        }

        public void Create_Merge()
        {
            Merge_Sort sortMerge = new Merge_Sort(nameFront, n,OutMerge);
            sortMerge.MakeSort();
        }
        

        public void CreateNature()
        {
            Nature_Sorting sortNature = new Nature_Sorting(nameNature,OutNature);
            sortNature.MakeSort();
        }
        
        public void CreateMulti()
        {
            Multi_Sorting_2 sortMulti = new Multi_Sorting_2(nameMulti, n,OutMulti);
            sortMulti.MakeSort();
        }


    }
}
