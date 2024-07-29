using Calculator.Operations;
using Calculator.Operations.Impl;

namespace Calculator
{
    class Program
    {

        private static readonly IOperation[] _OPERATIONS = [
            new Subtraction(),
            new Division(),
            new Multiplication(),
            new SquaredRoot(),
            new Addition(),
            new Sine(),
            new Cosine(),
            new Tangent()
        ];

        static void Main(string[] args)
        {
            var option = RequestOption();
            while (option != _OPERATIONS.Length)
            {
                var operation = _OPERATIONS[option];
                var arguments = RequestArgumentsFor(operation);
                var result = operation.Calculate(arguments);

                Console.Clear();
                Console.WriteLine($"O resultado da operação foi: {result}!");
                Console.WriteLine("Aperte qualquer tecla para ir para o menu.");

                Console.ReadKey();
                option = RequestOption();
            }
           
            Environment.Exit(0);
        }

        private static int RequestOption() { 

            int option = 0;
            
            var size = _OPERATIONS.Length;
            while (option <= 0 || option > size + 1) {
                Console.Clear();
                Console.WriteLine("Qual operação deseja realizar?");
                for (var i = 1; i <= size; i++) {
                    Console.WriteLine($"{i} - {_OPERATIONS[i - 1].Name}"); 
                }
                
                Console.WriteLine($"{size + 1} - Sair");
                Console.WriteLine("-------------------");

                Console.WriteLine("Selecione uma opção: ");
                _ = int.TryParse(Console.ReadLine(), out option);
            }

            return option - 1;
        }

        private static float[] RequestArgumentsFor(IOperation operation)
        {
            var max = operation.MaxParams;
            var min = operation.MinParams;

            List<float> values = [];

            Console.Clear();
            while (max == -1 || values.Count < max)
            {
                var size = values.Count;

                if (size == min) // Reached minimum, can be stopped anytime.
                {
                    Console.WriteLine("* Caso deseje, aperte ENTER sem preencher um valor para poder calcular os valores já preenchidos!");
                }

                var instructions = max == 1 ? "Digite o valor para calcular: " : $"Digite o {size + 1}º valor: ";
                Console.WriteLine(instructions);

                var success = float.TryParse(Console.ReadLine(), out float value);
                if (!success && size >= min)
                {
                    break;
                }

                if (!success)
                {
                    continue;
                }

                values.Add(value);
            }

            return [.. values];
        }
    }

}