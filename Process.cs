using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel
{
    public class Process
    {
        public Batch pBatch { get; set; }
        public int pc { get; set; }

        public Process(Batch aBatch)
        {
            pBatch = aBatch;
            pc = 0;
        }
    }
}
