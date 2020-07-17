using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel
{
    public class Batch : SFile
    {
        int line { get; set; }

        public Batch(string name, int id) : base(name, id) {
            line = 0;
        }

        public override void saveLine(String input)
        {
            data.Add(input);
            size += input.Length;
            line++;
        }

        //Run the current instruction of the batch file.
        //the pc add one at a line of run.
        public void runInstruction(int pc)
        {
            CMDhandler.interprete(this.data[pc]);
        }

        //If the pointer greater than the lines in the batch file, return
        //false to indication the end of the file.
        public bool batchEnds(int pc)
        {
            if (pc < line) return false;
            else return true;
        }
    }
}
