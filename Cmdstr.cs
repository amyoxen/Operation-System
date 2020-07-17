using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel
{
    public class Cmdstr
    {
        public static String f1 =

"SET V1 1;" +
"SET V2 99;" +
"SET V3 0;" +
"SET V4 0;" +
"SET V5 0;" +
"SET V6 0";

        public static String f2 =
"DIV V5 V1 V6;" +
"ADD V1 V2 V3;" +
"ADD V1 1 V4;" +
"ADD V4 0 V1;" +
"SUB V2 1 V4;" +
"ADD V4 0 V2;" +
"ADD V5 0 V4;" +
"ADD V3 V4 V5;" +
"MUL V1 V2 V4;" +
"ECHO V1;" +
"ECHO V2;" +
"ECHO V3;" +
"ECHO V4;" +
"ECHO V5;" +
"ECHO V6";

        public static String f3 =
"RUN FILE1.BAT;" +
"RUN FILE2.BAT;" +
"RUN FILE2.BAT;" +
"RUN FILE2.BAT;" +
"RUN FILE2.BAT;" +
"RUN FILE2.BAT";

        //RUN FILE3.BAT

        //RUN FILE1.BAT

        //RUNALL FILE2.BAT FILE2.BAT FILE2.BAT FILE2.BAT FILE2.BAT

    }
}
