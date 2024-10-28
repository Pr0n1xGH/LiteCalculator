using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите первое число: ");
                if (!int.TryParse(Console.ReadLine(), out int firstNumber))
                {
                    throw new ArgumentException("Введено некорректное число");
                }

                Console.Write("Введите операцию (+, -, *, /): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!"+-*/".Contains(operation))
                {
                    throw new ArgumentException("Некорректная операция");
                }

                Console.Write("Введите второе число: ");
                if (!int.TryParse(Console.ReadLine(), out int secondNumber))
                {
                    throw new ArgumentException("Введено некорректное число");
                }

                if (operation == '/' && secondNumber == 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно");
                }

                int result = Calculate(firstNumber, secondNumber, operation);
                Console.WriteLine($"Результат: {firstNumber} {operation} {secondNumber} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }

        private static int Calculate(int a, int b, char operation)
        {
            return operation switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new ArgumentException("Неподдерживаемая операция")
            };
        }
    }
}
