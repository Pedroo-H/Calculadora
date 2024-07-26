using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new Operation 
            {
                Name = "Soma",
                Apply = (n1, n2) => n1 + n2
            };

            var multiply = new Operation 
            {
                Name = "Multiplicação",
                Apply = (n1, n2) => n1 * n2
            };

            var subtraction = new Operation 
            {
                Name = "Subtraction",
                Apply = (n1, n2) => n1 - n2
            };

            var division = new Operation {
                Name = "Division",
                Apply = (n1, n2) => 
                {
                    if (n2 == 0) 
                    {
                        throw new DivideByZeroException("Não é possível fazer a divisão quando o divisor é 0!");
                    }

                    return n1/n2;
                }
            };

            Operation[] operations = [sum, multiply, subtraction, division];
            ShowOptions(operations);
        }

        private static void ShowOptions(Operation[] operations) { 

            string input = "";
            do 
            {
                Console.Clear();
                var size = operations.Length;

                Console.WriteLine("Qual operação deseja realizar?");
                for (var i = 1; i <= size; i++) {
                    Console.WriteLine($"{i} - {operations[i - 1].Name}"); 
                }

                Console.WriteLine("-------------------");
                Console.WriteLine("Selecione uma opção: ");
                input = Console.ReadLine() ?? "";
            } while (!isOptionValid(input, operations.Length));

            int option = int.Parse(input) - 1;

            do 
            {
                Console.WriteLine("Digite o primeiro valor:");
                input = Console.ReadLine() ?? "";
            } while (!isValueValid(input));

            int value1 = int.Parse(input);

            do 
            {
                Console.WriteLine("Digite o segundo valor:");
                input = Console.ReadLine() ?? "";
            } while (!isValueValid(input));

            int value2 = int.Parse(input);

            var result = operations[option].Apply(value1, value2);
            Console.WriteLine($"O seu resultado é: {result}");

            Console.ReadKey();
            ShowOptions(operations);
        }

        private static bool isOptionValid(string? input, int size) 
        {
            if (input == null)
                return false;

            try {
                var option = int.Parse(input);
                return option >= 1 && option <= size;
            } catch (Exception ignored) {
                return false;
            }
        }

        private static bool isValueValid(string? input) 
        {
            if (input == null)
                return false;

            try {
                float.Parse(input);
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }

    class Operation
    {
        public required string Name { get; set;}

        public required Func<float, float, float> Apply { get; set; }
    }
}