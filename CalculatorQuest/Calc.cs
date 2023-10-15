using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Avalonia.Controls;

namespace CalculatorQuest;

public class Calc
{

    // public Calc()
    // {
    //     
    // }
    int count = 0;
    int nbrpoint = 0;

    public static string Operator(string op)
    {
        if(op == null)
        {
            return "RightSomething";
        }
        
        if (op == "")
        {
            Console.WriteLine("Please enter an operation");
            return "Please enter an operation";
        }
        
        string[] args = { "", "" };
        string sign = "";
        string str = "";
        int count = 0;
        
        for (int i = 0; i < op.Length; i++)
        {
            if (VerifNumber(op[i]))
            {
                str += (op[i]);
                continue;
            }else if (VerifSign(op[i]))
            {
                if (count == 1)
                {
                    Console.WriteLine("Only one operation please");
                    return "Only one operation please";
                }
                sign = op[i].ToString();
                args[0] = str;
                str = "";
                count += 1;
                continue;
            }
            break;
        }
        args[1] = str;
        return Calcul(args, sign);
    }
    
        public static bool VerifSign(char op)
        {
            string[] _signs = {"+","-","x","/","%"};
            
            string str = op.ToString();
            
            for (int i = 0; i < _signs.Length; i++)
            {
                if (_signs[i] == str)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool VerifNumber(char number)
        {

            if (number <= 57 && number >= 48)
            {
                return true;
            }

            return false;
        }

        static string Calcul(string[] args, string sign)
        {
            int result;
            var arg1 = int.Parse(args[0]);
            var arg2 = int.Parse(args[1]);
            
            switch (sign)
            {
                case "+":
                    result = arg1 + arg2;
                    Console.WriteLine(result);
                    return result.ToString();

                case "-":
                    result = arg1 - arg2;
                    Console.WriteLine(result);
                    return result.ToString();

                case "x":
                    result = arg1 * arg2;
                    Console.WriteLine(result);
                    return result.ToString();
                
                case "/":
                    if (arg2 == 0)
                    {
                        Console.WriteLine("Division by 0 is IMPOSSIBLE");
                        return "Division by 0 is IMPOSSIBLE";
                    }
                    result = arg1 / arg2;
                    Console.WriteLine(result);
                    return result.ToString();
                
                case "%":
                    if (arg2 == 0)
                    {
                        Console.WriteLine("Modulo by 0 is IMPOSSIBLE");
                        return "Modulo by 0 is IMPOSSIBLE";
                    }
                    result = arg1 % arg2;
                    Console.WriteLine(result);
                    return result.ToString();
            }

            return "ERREUR";
        }

        public static string Del(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }

            return str;
        }
    
}