using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel
{
    class CMDhandler
    {
        public static void interprete (String input)
        {
            Console.WriteLine("Executing Command: " + input);
            switch (input.Split(' ')[0].ToLower())
            {   
                case "clr": Console.Clear(); break;
                case "echo": Kernel.handleEcho(input); break; 
                case "create": Kernel.handleCreate(input); break;
                case "add": Kernel.handleOperation(input, "add"); break;
                case "sub": Kernel.handleOperation(input, "sub"); break;
                case "mul": Kernel.handleOperation(input, "mul"); break;
                case "div": Kernel.handleOperation(input, "div"); break;
                case "set": Kernel.handleSet(input); break;
                case "dir": Kernel.listFiles(); break;
                case "run": Kernel.RunBatch(input); break;
                case "printf": Kernel.printFile(input); break;
                case "runall": Kernel.runAll(input); break;
                case "printvar": Kernel.printVariables(); break;
                case "reboot": Cosmos.System.Power.Reboot(); break;
                case "gui": Kernel.runGUI(); break;
                default: if (input == "") break; else Console.WriteLine("Command Does not Exist."); break;
            }
        }
    }
}
