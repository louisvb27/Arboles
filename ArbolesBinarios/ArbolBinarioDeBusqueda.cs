namespace ArbolesBinarios;

internal class ArbolBinarioDeBusqueda
{
    public Nodo? Raiz { get; private set; }

    public ArbolBinarioDeBusqueda(int raiz)
    {
        Raiz = new Nodo(raiz);
    }

    public enum Recorrido
    {
        PreOrden,
        InOrden,
        PostOrden
    }

    public void Insertar(int valor, Nodo? nodo = null)
    {
        if (nodo == null)
        {
            nodo = Raiz;
        }

        if (valor > nodo!.Valor)
        {
            if (nodo.Derecho == null)
            {
                nodo.Derecho = new Nodo(valor);
            }

            else
            {
                Insertar(valor, nodo.Derecho);
            }

        }

        else if (valor < nodo.Valor)
        {
            if (nodo.Izquierdo == null)
            {
                nodo.Izquierdo = new Nodo(valor);
            }
            else
            {
                Insertar(valor, nodo.Izquierdo);
            }
        }
    }

    private void Recorrer(Nodo? nodo, ref string datos)
    {
        if (nodo == null)
        {
            return;
        }

        string raiz = (datos == string.Empty) ? "Raiz" : string.Empty;
        datos += $"{raiz} {nodo.Valor} {Environment.NewLine}";

        if (nodo.Izquierdo != null)
        {
            datos += $"{nodo.Izquierdo.Valor,-5} <-";
            Recorrer(nodo.Izquierdo, ref datos);
        }

        if (nodo.Derecho != null)
        {
            datos += $" {nodo.Derecho.Valor,-5} ->";
            Recorrer(nodo.Derecho, ref datos);
        }
    }
}
