using System;
using System.Collections.Generic;
using System.Linq; // Necesario para ordenar y buscar valores fácilmente

class Program
{
    static void Main(string[] args)
    {
        // Crear la lista vacía para almacenar enteros
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNumber = -1;

        // 1. Capturar números en un bucle hasta que introduzca 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            // Regla crucial: NO agregar el número 0 a la lista
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Validar si la lista contiene elementos para evitar errores de división por cero
        if (numbers.Count > 0)
        {
            // 2. Operaciones Básicas
            int sum = 0;
            int largest = numbers[0];

            foreach (int num in numbers)
            {
                sum += num; // Sumatoria de elementos

                if (num > largest)
                {
                    largest = num; // Encontrar el máximo
                }
            }

            // Calcular el promedio usando float para no perder decimales
            float average = (float)sum / numbers.Count;

            // 3. RETO: Encontrar el número positivo más pequeño (cercano a cero)
            int smallestPositive = int.MaxValue; 
            foreach (int num in numbers)
            {
                if (num > 0 && num < smallestPositive)
                {
                    smallestPositive = num;
                }
            }

            // Impresión de resultados estadísticos en consola
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
            
            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // 4. RETO: Ordenar la lista y mostrarla
            numbers.Sort(); // Ordena los números de menor a mayor automáticamente

            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}