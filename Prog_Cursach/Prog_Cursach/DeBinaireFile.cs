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

        public DeBinaireFile(string inName,string outputName)
        {
            nameMain = inName;
            outName = outputName;
        }

        public void CreateTXT()
        {
            using (StreamWriter writer = new StreamWriter(outName,false))
            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader reader = new BinaryReader(file))
            {
                int y = 0;
                bool fl = true;

                while (fl == true)
                {
                    try
                    {
                        y = reader.ReadInt32();
                        writer.Write(y + " ");
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }

                }
            }

            File.Delete(nameMain);
        }

        public void CreateTXT(int n)
        {

            using (StreamWriter writer = new StreamWriter(outName, false))
            using (FileStream file = File.OpenRead(nameMain))
            using (BinaryReader reader = new BinaryReader(file))
            {
                int y = 0,
                    count = 0;
                bool fl = true;

                while (count < n)
                {
                    count++;
                    try
                    {
                        y = reader.ReadInt32();
                        writer.Write(y + " ");
                    }
                    catch (EndOfStreamException e)
                    {
                        fl = false;
                    }

                }
            }
        }
    }
}
