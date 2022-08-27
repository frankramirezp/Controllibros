using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Biblioteca
{

    public class Registradora
    {
        string ruta = @"C:\Users\f_ram\Documents\Proyecto Final\Sistema de control y venta de libros\Controllibros\Listado de libros.txt";
        StreamWriter escribir;
        
        
        public List<Libro> Libros { get; set; }
        public double Pago { get; set; }

        public Registradora()
        {
            this.Libros = new List<Libro>();

            Libro maria = new Libro();
            maria.Codigo = "01";
            maria.Nombre = "Maria";
            maria.Autor = "Jorge Isaac";
            maria.Tipo = "Novela";
            maria.Cantidad = 5;
            maria.Precio = 500;
            maria.Ubicacion = "A1";

            Libro elalquimista = new Libro();
            elalquimista.Codigo = "02";
            elalquimista.Nombre = "El Alquimista";
            elalquimista.Autor = "Paulo Coelho";
            elalquimista.Tipo = "Novela";
            maria.Cantidad = 2;
            elalquimista.Precio = 1500;
            elalquimista.Ubicacion = "A2";

            this.Libros.Add(maria);
            this.Libros.Add(elalquimista);
        }

        public int validaLibro(string codigo)
        {
            int encontro = -1;

            for (int i = 0; i < this.Libros.Count; i++)
            {
                if (this.Libros[i].Codigo == codigo)
                {
                    encontro = i;
                }
            }
            return encontro;
        }

        public bool agregarLibro(Libro libro)
        {
            int enc = this.validaLibro(libro.Codigo);
            if (enc >= 0)
            {
                this.Libros[enc].sumarCantidad(libro.Cantidad);
            }
            else
            {
                this.Libros.Add(libro);
            }

            return true;
        }

        

        public Libro vender(string codigo)
        {
            int enc = this.validaLibro(codigo);

            if (enc >= 0)
            {
                if (this.Libros[enc].validarCantidad())
                {
                    if (this.Libros[enc].validarPrecio(Pago))
                    {
                        this.Libros[enc].restarLibro();
                        return this.Libros[enc];
                    }
                    
                }
            }

            return null;
        }

        public string listarLibro()
        {
            escribir = File.AppendText(ruta);
            string lista = "";
            foreach (Libro item in this.Libros)
            {
                lista += " Código: " + item.Codigo + " Nombre: " + item.Nombre + " Tipo: " + item.Tipo + " Autor: " + item.Autor + " Cantidad: " + item.Cantidad + " Precio: " + item.Precio + " Ubicación: " + item.Ubicacion + "\n";
                escribir.WriteLine(lista);
                
            }
            escribir.Flush();
            escribir.Close();
            return lista;
        }

        public string listarAutores()
        {
            string lista = "";
            foreach (Libro item in this.Libros)
            {
                lista += " Autor: " + item.Autor + "\n";

            }
            return lista;
        }
    }
}
