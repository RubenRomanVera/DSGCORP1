using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Caracteres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Se escribe los caracteres
            Console.WriteLine("Ingrese los caracteres: ");
            string cadena = Console.ReadLine();

            var regexItem = new Regex("[!@#$%^&*(),.?\":{}|<>]"); //se utiliza un regex de solo caracteres especiales

            //Se inicializan las variables numericas
            int cantidadMayusculas = 0;
            int NumeroMinuscula = 0;
            int NumeroDecimal = 0;
            int numerocaracterespecial = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                if (char.IsUpper(cadena[i]))
                {
                    cantidadMayusculas++;
                }
                if (char.IsLower(cadena[i]))
                {
                    NumeroMinuscula++;
                }
                if (char.IsDigit(cadena[i]))
                {
                    NumeroDecimal++;
                }
                if (regexItem.IsMatch(cadena[i].ToString()))
                {
                    numerocaracterespecial++;
                }
            }
            Console.WriteLine("Cadena original: " + cadena);
            Console.WriteLine("Mayusculas: " + cantidadMayusculas);
            Console.WriteLine("Minusculas: " + NumeroMinuscula);
            Console.WriteLine("Digitos: " + NumeroDecimal);
            Console.WriteLine("Caracteres especiales: " + numerocaracterespecial);
            Console.ReadKey();
        }
    }
}
