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

        private void Recorrer(Nodo nodo, ref int posicion, ref string datos)
        {
            if (nodo != null)
            {
                string dato = nodo.Valor;
                int cantidadGuiones = dato.Length + posicion;
                string datoConguiones = dato.PadLeft(cantidadGuiones, '-');
                datos += datoConguiones + Environment.NewLine;

                if (nodo.Hijo != null)
                {
                    posicion++;
                    Recorrer(nodo.Hijo, ref posicion, ref datos);
                    posicion--;
                }

                if (nodo.Hermano != null && posicion != 0)
                {
                    Recorrer(nodo.Hermano, ref posicion, ref datos);
                }
            }
        }

        public string ObtenerDatos()
        {
            int posicion = 0;
            string datos = string.Empty;
            Recorrer(Raiz, ref posicion, ref datos);
            return datos;
        }
    }
}
