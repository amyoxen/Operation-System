using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware;

namespace CosmosKernel
{
    public class SFile
    {
        public String filename { get; set; }
        public int fileID { get; set; }
        public int size { get; set; }
        public String createdTime { get; set; }
        public List<String> data { get; set; }

        public SFile(String name, int id)
        {
            CosmosTime d = new CosmosTime();
            filename = name;
            fileID = id;
            size = 0;
            createdTime = d.toString();
            data = new List<String>();
        }

        public virtual void saveLine(String input)
        {
            data.Add(input);
            size += input.Length;
        }

        public void close()
        {
            CosmosTime d = new CosmosTime();
            createdTime = d.toString();
        }

        public override String ToString()
        {
            String f_content = "";
            f_content = fileID + "\t\t" + filename + "\t\t" + size + "\t\t" + createdTime;
            return f_content;
        }
    }
}
