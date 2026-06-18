namespace ArbolesGenerales
{
    internal class Arbol
    {
        public Nodo Raiz { get; }
        public Arbol(string raiz)
        {
            Raiz = new Nodo(raiz);
        }
    }
}
