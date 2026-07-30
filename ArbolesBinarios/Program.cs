namespace ArbolesBinarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioDeBusqueda arbol = new ArbolBinarioDeBusqueda(raiz: 10);
            //string datos = arbol.ObtenerDatos();
            //Console.WriteLine(datos);

            arbol.Insertar([5, 10, 3, 9, 15, 27, 12, 23]);
            //Console.WriteLine(arbol.ObtenerDatos());
            Console.WriteLine(arbol.ObtenerDatos(ArbolBinarioDeBusqueda.Recorrido.PreOrden));
            Console.WriteLine(arbol.ObtenerDatos(ArbolBinarioDeBusqueda.Recorrido.InOrden));
            Console.WriteLine(arbol.ObtenerDatos(ArbolBinarioDeBusqueda.Recorrido.PostOrden));
        }
    }
}
