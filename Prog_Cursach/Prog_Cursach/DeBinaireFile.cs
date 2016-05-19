using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog_Cursach
{
    class DeBinaireFile
    {
        private string nameMain="",
            outName = "";

        int max, min, rozryads;

        public DeBinaireFile(string inName,string outputName,int rozryads)
        {
            nameMain = inName;
            outName = outputName;
            this.rozryads = rozryads;
        }

        public void CreateTXT()
        {
            using (StreamWriter writer = new StreamWriter(outName,false))
            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader reader = new BinaryReader(file))
            {
                int y = 0;
                bool fl = true;
                int h = rozryads + 1;

                 while (fl)
                {
                    for (int i = 0; i < 92 && fl; i++)
                    {
                        try
                        {
                            y = reader.ReadInt32();
                            writer.Write(String.Format("{0,11}",y));
                        }
                        catch (EndOfStreamException e)
                        {
                            fl = false;
                        }
                    }
                    writer.WriteLine();
                }
            }

            File.Delete(nameMain);
        }

    }
}
