﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ejercicio6Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre = "hola";
            string rutaArchivo = "C:\\Users\\Profesor\\source\\repos\\ejercicio6Ficheros\\" + nombre + ".txt";

            Console.WriteLine("Introduce Nombre");
            string nombreA=Console.ReadLine();
            Console.WriteLine("Introduce Apellidos");
            string apellidosA=Console.ReadLine();
            Console.WriteLine("Introduce edad");
            int edad = Convert.ToInt32(Console.ReadLine());

            string contenidoFichero = generarContenido(nombreA, apellidosA, edad);

            int opcion;
            bool cerrarMenu = false;
            while (!cerrarMenu)
            {

                opcion = mostrarMenu();
                switch(opcion)
                {
                    case 0:
                        Console.WriteLine("CERRAR");
                 cerrarMenu = true;
                        break;
                    case 1:
                        Console.WriteLine("Escribir en el archivo");
                        escribirTexto();
                        break;
                    case 2:
                        Console.WriteLine("Leer contenido del archivo");
                        leerTexto();
                        break;
                    case 3:
                        Console.WriteLine("Añadir contenido al archivo");
                        aniadirTexto();
                        break;
                    case 4:
                        Console.WriteLine("Seleccionar linea y modificarla");
                        seleccionLinea();
                        break;
                    case 5:
                        Console.WriteLine("Insertar texto en una posicion especifica");
                        posicionEspecifica();
                            break;
                    default: Console.WriteLine("Introduzca opcion");
                        break;
                }
            }

            
            void escribirTexto()
            {
                using (StreamWriter sw = new StreamWriter(rutaArchivo))
                {
                    Console.WriteLine("Añada contenido al archivo");
                    string contenido = Console.ReadLine();
                }
                
            }

            void leerTexto()
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string contenido = sr.ReadToEnd();
                    Console.WriteLine("Contenido del archivo:\n" + contenido);
                }

                Console.ReadLine();
            }


            void aniadirTexto()
            {
                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    Console.WriteLine("Introduzca nuevo cotenido");
                    string masContenido = Console.ReadLine();
                }
               

                Console.WriteLine("Se ha añadido más contenido al archivo.");
            }
            
             int mostrarMenu()
            {
                int opcionIntroducida;

                Console.WriteLine("##########################");
                Console.WriteLine("0. Cerra aplicacion");
                Console.WriteLine("1. Escribir contenido inicial del archivo");
                Console.WriteLine("2. Leer contenido del archivo");
                Console.WriteLine("3. Añadir contenido del archivo");
                Console.WriteLine("4. Seleccionar linea y modificarla");
                Console.WriteLine("5. Insertar texto en una posicion especifica");
                Console.WriteLine("6. Guardar contenido modificado");
                Console.WriteLine("Selecciona una opcion: ");

                opcionIntroducida = Console.ReadKey(true).KeyChar - ('0');

                return opcionIntroducida;


             }
            

            void seleccionLinea()
            {
                Console.WriteLine("Introduce el numero de la linea en la que deseas añadir el texto");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce el texto que deseas añadir");
                string textoNuevo = Console.ReadLine();

                try
                {
                    // Leer todas las líneas del archivo
                    string[] lineas = File.ReadAllLines(

                    rutaArchivo);

                    // Verificar si el número de línea deseado está dentro del rango del archivo
                    if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                    {
                        // Reemplazar el contenido de la línea específica
                        lineas[numeroLinea - 1] = textoNuevo;

                        // Sobrescribir el archivo con las líneas actualizadas
                        File.WriteAllLines(

                     rutaArchivo, lineas);

                        Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
                    }
                    else
                    {
                        Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
                }
            }
            void posicionEspecifica()
            {

            }

        }
        
    }
}
