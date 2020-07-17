using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Hardware;
using Sys = Cosmos.System;

namespace Hardware
{
    public class Button
    {
        public String label { get; set; }
        public bool actvated { get; set; }
        public int background_clr {get; set;}
        public int  edge_clr { get; set; }
        public uint X0, X1;
        public uint Y0, Y1;

        public Button (uint x0, uint y0, uint x1, uint y1, String l, int b_c, int e_c )
        {
            X0 = x0;
            Y0 = y0;
            X1 = x1;
            Y1 = y1;
            label = l;
            background_clr = b_c;
            edge_clr = e_c;
            actvated = false;
        }

    }
}
