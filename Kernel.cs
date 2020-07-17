using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Hardware;
using Sys = Cosmos.System;

namespace CosmosKernel
{
    public class Kernel : Sys.Kernel
    {

        private static List<Variable> variables;
        private static List<SFile> directory;
        private static Queue<Process> ProcessManager;
        private Batch file1;
        private Batch file2;
        private Batch file3;

        private static CosmosTime timer;
        protected static DisplayDriver display;
        protected static Mouse mouse;
        protected static Button clear;
        protected static Button quit;

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully.");
            timer = new CosmosTime();

            variables = new List<Variable>();
            directory = new List<SFile>();
            ProcessManager = new Queue<Process>();

            file1 = new Batch("FILE1.BAT",1);
            file2 = new Batch("FILE2.BAT", 2);
            file3 = new Batch("FILE3.BAT", 3);

            directory.Add(file1);
            directory.Add(file2);
            directory.Add(file3);

            load_batch(file1, Cmdstr.f1);
            load_batch(file2, Cmdstr.f2);
            load_batch(file3, Cmdstr.f3);
        }

        protected override void Run()
        {
            Console.Write("$");
            String input = Console.ReadLine();
            CMDhandler.interprete(input);
        }

        private void load_batch (Batch bch, String str)
        {
            String[] instructions = str.Split(';');
            for (int i = 0; i < instructions.Length; i++)
            {
                bch.saveLine(instructions[i]);
            }
        }

        public static void RunBatch(String input)
        {
            String batchName = input.Substring(4, input.Length - 4);
            if (batchName.Split('.')[1].ToLower() != "bat")
            {
                Console.WriteLine("Not a batch file name.");
                return;
            }

            int index = searchFile(batchName);
            if (index >= 0)
            {
                Batch bchfile = (Batch)directory[index];
                int pc = 0;
                while (!bchfile.batchEnds(pc))
                {
                    bchfile.runInstruction(pc);
                    pc++;
                }
            } else Console.WriteLine("The Batch File does not exist.");
        }

        public static void runAll(String input)
        {
            String batchName = input.Substring(7, input.Length - 7);
            String[] filenames = batchName.Split(' ');
            for (int i=0; i<filenames.Length; i++)
            {
                int index = searchFile(filenames[i]);
                if (index < 0)
                {
                    Console.WriteLine(filenames[i] + " does not exist.");
                    return;
                }

                Batch insertFile = (Batch) directory[index];
                
                Process process= new Process(insertFile);
                ProcessManager.Enqueue(process);
            }
            rb_process();
        }

        public static void rb_process()
        {
            while (ProcessManager.Count!=0)
            {
                while (timer.timerTick())
                {
                    Process exeProcess = ProcessManager.Dequeue();
                    Batch exeBatch = exeProcess.pBatch;
                    exeBatch.runInstruction(exeProcess.pc);
                    exeProcess.pc++;
                    if (!exeBatch.batchEnds(exeProcess.pc))
                    {
                        ProcessManager.Enqueue(exeProcess);
                    }
                }  
            }
        }

        public static void listFiles()
        {
            Console.WriteLine("id\t\t Name\t\t Size\t\t Created Date");
            for (int i = 0; i < directory.Count; i++)
            {
                Console.WriteLine(directory[i]);
            }
        }

        public static void handleOperation(String input, String Operation)
        {
            if (input.Split(' ').Length != 4)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            String varName_1 = input.Split(' ')[1];
            String varName_2 = input.Split(' ')[2];
            String toVar = input.Split(' ')[3];

            int operand_1 = 0;
            int operand_2 = 0;
            int resultValue = 0;

            try
            {
                operand_1 = Int32.Parse(varName_1);
            }
            catch (Exception e)
            {
                int indexofTarget1 = searchVariable(varName_1);
                if (indexofTarget1 < 0)
                {
                    Console.WriteLine("The frist variable is not a number or pre-defined.");
                    return;
                }
                operand_1 = variables[indexofTarget1].value;
            }

            try
            {
                operand_2 = Int32.Parse(varName_2);
            }
            catch (Exception e)
            {
                int indexofTarget2 = searchVariable(varName_2);
                if (indexofTarget2 < 0)
                {
                    Console.WriteLine("The second variable is not a number or pre-defined.");
                    return;
                }
                operand_2 = variables[indexofTarget2].value;
            }


            //look for the varName to see if it exists in the list.
            int indexofAssign = searchVariable(toVar);
            if (indexofAssign < 0)
            {
                indexofAssign = variables.Count;
                variables.Add(new Variable(toVar));
            }

            switch (Operation)
            {
                case "add": resultValue = operand_1 + operand_2; break;
                case "sub": resultValue = operand_1 - operand_2; break;
                case "mul": resultValue = operand_1 * operand_2; break;
                case "div":
                    {
                        if (operand_2 == 0)
                        {
                            Console.WriteLine("Divided by Zero.");
                            return;
                        }
                        resultValue = operand_1 / operand_2; break;
                    }
                        
                default: break;
            }

            variables[indexofAssign].value = resultValue;

        }

        public static void handleEcho(String input)
        {
            String echoString = input.Substring(5, input.Length - 5);
            int varIndex = searchVariable(echoString);
            if (varIndex < 0)
            {
                Console.WriteLine(echoString);
            } else
            {
                Console.WriteLine(variables[varIndex].value);
            }
        }

        public static void handleSet(String input)
        {
            if (input.Split(' ').Length != 3)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            String varName = input.Split(' ')[1];
            String targetVar = input.Split(' ')[2];

            int newValue = 0;

            try
            {
                newValue = Int32.Parse(targetVar);
            } catch (Exception e)
            {
                int indexofTarget = searchVariable(targetVar);
                if (indexofTarget < 0)
                {
                    Console.WriteLine("Target variable is not a number or pre-defined.");
                    return;
                }
                newValue = variables[indexofTarget].value;
            }

            //look for the varName to see if it exists in the list.
            int indexofAssign = searchVariable(varName);
            if (indexofAssign < 0)
            {
                indexofAssign = variables.Count;
                variables.Add(new Variable(varName));
            }

            variables[indexofAssign].value = newValue;

        }

        public static int searchVariable(String name)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void printVariables()
        {
            for (int i = 0; i < variables.Count; i++)
            {
                Console.WriteLine(variables[i].name + " = " + variables[i].value);
            }
        }

        public static void handleCreate(String input)
        {
            String filename = input.Split(' ')[1];
            int index = directory.Count;
            SFile file = new SFile(filename, index+1);
            String fileInput = Console.ReadLine();

            while (fileInput.ToLower() != "save")
            {
                file.saveLine(fileInput);
                fileInput = Console.ReadLine();
            }

            file.close();
            directory.Add(file);
        }


        public static int searchFile(String name)
        {
            for (int i = 0; i < directory.Count; i++)
            {
                if (directory[i].filename == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void printFile(String input)
        {
            String filename = input.Substring(7, input.Length-7);
            int index = searchFile(filename);
            if (index >= 0)
            {
                SFile afile = directory[index];
                for(int i=0; i<afile.data.Count; i++)
                {
                    Console.WriteLine(afile.data[i]);
                }
            } else
            {
                Console.WriteLine(filename + " does not exist.");
            }
        }


        public static void runGUI()
        {
            display = new DisplayDriver();
            display.init();
            mouse = new Mouse();
            clear = new Button((uint)0, (uint)0, (uint)110, (uint)30, "CLEAR", 11, 40);
            quit = new Button((uint)0, (uint)170, (uint)110, (uint)200, "QUIT", 12, 40);

            display.drawButton(clear);
            display.drawButton(quit);
            while (true)
            {
                mouse.drawMouse(display);

                if (mouse.click() && mouse.X < (int)quit.X1 && mouse.Y > (int)quit.Y0)
                {
                    Cosmos.System.Power.Reboot();
                }

                if (mouse.click() && mouse.X < (int)clear.X1 && mouse.Y < (int)clear.Y1
                    && mouse.X > (int)clear.X0 && mouse.Y > (int)clear.Y0)
                {
                    display.init();
                    display.drawButton(clear);
                    display.drawButton(quit);
                }

                if (mouse.click() && mouse.Y > 30 && mouse.Y < 170)
                {
                        display.drawHappyFace((uint)mouse.X, (uint)mouse.Y, 18, 20);
                        mouse.refreshPixel(display);     
                }
            }

        }

    }
}