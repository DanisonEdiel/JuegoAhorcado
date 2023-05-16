using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] palabras = { "perro", "gato", "elefante", "jirafa", "mono" };
        Random random = new Random();
        string palabraSeleccionada = palabras[random.Next(palabras.Length)];
        List<char> letrasAdivinadas = new List<char>();
        int intentos = 6;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Juego del Ahorcado");
            Console.WriteLine("------------------");

            // Mostrar letras adivinadas y guiones para las no adivinadas
            for (int i = 0; i < palabraSeleccionada.Length; i++)
            {
                if (letrasAdivinadas.Contains(palabraSeleccionada[i]))
                {
                    Console.Write(palabraSeleccionada[i] + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Intentos restantes: " + intentos);
            Console.Write("Ingresa una letra: ");
            char letra = Console.ReadLine()[0];

            if (letrasAdivinadas.Contains(letra))
            {
                Console.WriteLine("Ya has ingresado esa letra. Presiona Enter para continuar.");
                Console.ReadLine();
                continue;
            }

            letrasAdivinadas.Add(letra);

            if (!palabraSeleccionada.Contains(letra))
            {
                intentos--;
                Console.WriteLine("La letra no está en la palabra. Presiona Enter para continuar.");
                Console.ReadLine();
            }

            if (intentos == 0)
            {
                Console.WriteLine("¡Perdiste! La palabra era: " + palabraSeleccionada);
                break;
            }

            bool palabraCompletada = true;
            foreach (char c in palabraSeleccionada)
            {
                if (!letrasAdivinadas.Contains(c))
                {
                    palabraCompletada = false;
                    break;
                }
            }

            if (palabraCompletada)
            {
                Console.WriteLine("¡Felicidades! Has adivinado la palabra.");
                break;
            }
        }

        Console.WriteLine("Presiona Enter para salir.");
        Console.ReadLine();
    }
}