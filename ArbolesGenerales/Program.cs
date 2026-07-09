namespace ArbolesGenerales
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Arbol arbol = new Arbol(raiz: "A");

            Console.WriteLine(arbol.Raiz);

            Nodo nodoB = arbol.Agregar(valor: "B", nodoPadre: arbol.Raiz);
            Nodo nodoE = arbol.Agregar(valor: "E", nodoPadre: nodoB);
            Nodo nodoF = arbol.Agregar(valor: "F", nodoPadre: nodoB);
            Nodo nodoK = arbol.Agregar(valor: "K", nodoPadre: nodoF);
            Nodo nodoJ = arbol.Agregar(valor: "J", nodoPadre: nodoF);
            Nodo nodoC = arbol.Agregar(valor: "C", nodoPadre: arbol.Raiz);
            Nodo nodoG = arbol.Agregar(valor: "G", nodoPadre: nodoC);
            Nodo nodoH = arbol.Agregar(valor: "H", nodoPadre: nodoC);
            Nodo nodoL = arbol.Agregar(valor: "L", nodoPadre: nodoH);
            Nodo nodoD = arbol.Agregar(valor: "D", nodoPadre: nodoB);
            Nodo nodoI = arbol.Agregar(valor: "I", nodoPadre: nodoD);

            string datosArbol = arbol.ObtenerDatos();
            Console.WriteLine(datosArbol);
        }
    }
}
