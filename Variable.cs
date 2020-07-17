using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel
{
    class Variable
    {
        public string name { get; set; }
        public int value { get; set; }

        public Variable(String n)
        {
            name = n;
            value = 0;
        }
    }
}