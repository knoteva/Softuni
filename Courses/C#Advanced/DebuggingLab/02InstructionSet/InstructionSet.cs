using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class InstructionSet
{
    static void Main()
    {

        string opCode = Console.ReadLine();
        //
        while (opCode != "END")
        {
            string[] codeArgs = opCode.Split(' ');

            long result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        //
                        result = (long)operandOne + 1;
                        break;
                    }
                case "DEC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        //
                        result = (long)operandOne - 1;
                        break;
                    }
                case "ADD":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        //
                        result = (long)operandOne + (long)operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        //
                        result = (long)operandOne * (long)operandTwo;
                        break;
                    }
            }

            Console.WriteLine(result);
            //
            opCode = Console.ReadLine();
        }
    }
}

