using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Juan", 3, 16);

        Scripture scripture = new Scripture(
            reference,
            "Porque de tal manera amo Dios al mundo que ha dado a su Hijo unigénito para que todo aquel que en el cree no se pierda mas tenga vida eterna."
        );

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Presione Enter para continuar o escriba 'salir': ");

            string respuesta = Console.ReadLine();

            if (respuesta.ToLower() == "salir")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Programa finalizado.");
    }
}