namespace ArbolesGenerales
{
    internal class Arbol
    {
        public Nodo Raiz { get; }
        public Arbol(string raiz)
        {
            Raiz = new Nodo(raiz);
        }

        public Nodo Agregar(string valor, Nodo nodoPadre)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new Exception("el valor es un dato requerido");
            }

            if (nodoPadre == null)
            {
                throw new Exception("el nodo padre es un dato requerido");
            }

            if (nodoPadre.Hijo == null)
            {
                nodoPadre.Hijo = new Nodo(valor);
                return nodoPadre.Hijo;
            }
            else
            {
                Nodo nodoActual = nodoPadre.Hijo;
                while (nodoActual.Hermano != null)
                {
                    nodoActual = nodoActual.Hermano;
                }
                nodoActual.Hermano = new Nodo(valor);
                return nodoActual.Hermano;
            }
        }
    }
}
