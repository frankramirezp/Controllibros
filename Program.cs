using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;
using System.IO;

namespace Controllibros
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Users\f_ram\Documents\Proyecto Final\Sistema de control y venta de libros\Controllibros\Factura de libros.txt";
            StreamWriter escribir;

            Registradora  registrar = new Registradora();

            while (true)
            {
                Console.WriteLine("************************Control de Libros************************");
                Console.WriteLine("\n");

                Console.WriteLine("*************************Menu Principal**************************");
                Console.WriteLine("\n");
                Console.WriteLine("1.[Agregar libro]    |   3.[Vender Libros]");
                Console.WriteLine("2.[Modificar Libros] |   4.[Lista de Libros]");
                Console.WriteLine("0.[Salir]            |   5.[Listado de Autores]");
                Console.WriteLine("\n");
                Console.WriteLine("Selecciones una opción");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("************************Crear Libros************************");
                        Console.WriteLine("\n");

                        Libro libro = new Libro();
                        Console.Write("Ingrese el Código del Libro :");
                        libro.Codigo = Console.ReadLine();

                        Console.Write("Ingrese el Nombre del Libro :");
                        libro.Nombre = Console.ReadLine();

                        Console.Write("Ingrese el Tipo de libro :");
                        libro.Tipo = Console.ReadLine();

                        Console.Write("Ingrese el Autor del libro :");
                        libro.Autor = Console.ReadLine();

                        Console.Write("Ingrese la Cantidad de libros :");
                        libro.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ingrese el Precio :");
                        libro.Precio = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ingrese la ubicación :");
                        libro.Ubicacion = Console.ReadLine();

                        registrar.agregarLibro(libro);

                        Console.Write("\n");
                        Console.WriteLine("Guardado correctamente");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Código de libro");
                        string codigo_venta = Console.ReadLine();

                        escribir = File.AppendText(ruta);

                        Console.WriteLine("Indique con cuanto pagará");
                        registrar.Pago = Convert.ToDouble(Console.ReadLine());
                        registrar.vender(codigo_venta);

                        Libro lcomprado = registrar.vender(codigo_venta);

                        if (lcomprado == null)
                        {
                            Console.WriteLine("Este producto no se puede vender");
                        }
                        else
                        {
                            Console.WriteLine("Su producto es {0} y la devuelta es {1}", " Código: " + lcomprado.Codigo + " Nombre: " + lcomprado.Nombre + " Tipo: " + lcomprado.Tipo + " Autor; " + lcomprado.Autor + " Precio " + lcomprado.Precio + "\n", lcomprado.Cambio);
                            escribir.WriteLine("Su producto es {0} y la devuelta es {1}", " Código: " + lcomprado.Codigo + " Nombre: " + lcomprado.Nombre + " Tipo: " + lcomprado.Tipo + " Autor; " + lcomprado.Autor + " Precio " + lcomprado.Precio + "\n", lcomprado.Cambio);
                        }
                        Console.ReadKey();
                        escribir.Flush();
                        escribir.Close();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("************************Listado de Libros************************");
                        Console.WriteLine(registrar.listarLibro());
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("************************Listado de Autores************************");
                        Console.WriteLine(registrar.listarAutores());
                        break;
                    case "r":
                        Console.Clear();
                        Console.ReadKey();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Selección invalida");
                        break;
                }
                Console.WriteLine("Desea continual si/no ");

                if (Console.ReadLine() == "no")
                {
                    break;
                }
            }
            
        }
    }
}