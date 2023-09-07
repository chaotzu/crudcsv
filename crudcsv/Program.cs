using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static string archivoNotas = "notas.csv";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Elije una opción:");
            Console.WriteLine("1. Listar notas");
            Console.WriteLine("2. Agregar nota");
            Console.WriteLine("3. Actualizar nota");
            Console.WriteLine("4. Borrar nota");
            Console.WriteLine("5. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ListarNotas();
                    break;
                case 2:
                    AgregarNota();
                    break;
                case 3:
                    ActualizarNota();
                    break;
                case 4:
                    BorrarNota();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }

    static void ListarNotas()
    {
        if (File.Exists(archivoNotas))
        {
            List<string> lineas = File.ReadAllLines(archivoNotas).ToList();

            if (lineas.Count == 0)
            {
                Console.WriteLine("No hay notas.");
            }
            else
            {
                Console.WriteLine("Notas:");
                for (int i = 0; i < lineas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {lineas[i]}");
                }
            }
        }
        else
        {
            Console.WriteLine("No hay notas.");
        }
    }

    static void AgregarNota()
    {
        Console.WriteLine("Escribe la nueva nota:");
        string nuevaNota = Console.ReadLine();
        File.AppendAllText(archivoNotas, nuevaNota + Environment.NewLine);
        Console.WriteLine("Nota agregada.");
    }

    static void ActualizarNota()
    {
        ListarNotas();
        Console.WriteLine("Escribe el número de la nota que quieres actualizar:");
        int numeroNota = int.Parse(Console.ReadLine()) - 1;

        if (File.Exists(archivoNotas))
        {
            List<string> lineas = File.ReadAllLines(archivoNotas).ToList();

            if (numeroNota >= 0 && numeroNota < lineas.Count)
            {
                Console.WriteLine("Escribe la nueva versión de la nota:");
                string nuevaVersion = Console.ReadLine();
                lineas[numeroNota] = nuevaVersion;
                File.WriteAllLines(archivoNotas, lineas);
                Console.WriteLine("Nota actualizada.");
            }
            else
            {
                Console.WriteLine("Número de nota inválido.");
            }
        }
    }

    static void BorrarNota()
    {
        ListarNotas();
        Console.WriteLine("Escribe el número de la nota que quieres borrar:");
        int numeroNota = int.Parse(Console.ReadLine()) - 1;

        if (File.Exists(archivoNotas))
        {
            List<string> lineas = File.ReadAllLines(archivoNotas).ToList();

            if (numeroNota >= 0 && numeroNota < lineas.Count)
            {
                lineas.RemoveAt(numeroNota);
                File.WriteAllLines(archivoNotas, lineas);
                Console.WriteLine("Nota borrada.");
            }
            else
            {
                Console.WriteLine("Número de nota inválido.");
            }
        }
    }
}
