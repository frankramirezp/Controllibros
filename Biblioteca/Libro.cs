namespace Biblioteca
{
    public class Libro
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Autor { get; set; }
        public string? Tipo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string? Ubicacion { get; set; }
        public double Cambio { get; set; }

        public void sumarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;
        }

        public bool validarCantidad()
        {
            if(this.Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool validarPrecio(double precio)
        {
            if(this.Precio <= precio)
            {
                this.Cambio = precio - this.Precio;
                return true;
            }
            return false;
        }

        public void restarLibro()
        {
            this.Cantidad--;
        }

    }
}