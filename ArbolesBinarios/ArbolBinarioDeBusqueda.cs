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
    public string ObtenerDatos()
    {
        string datos = string.Empty;
        Recorrer(Raiz, ref datos);
        return datos;
    }

    private void Seleccionar(Nodo nodo, ref string datos) 
    {
        string coma = (datos == string.Empty) ? string.Empty : ",";
        datos += $"{coma}{nodo.Valor}";

    }

    private void RecorridoInorden(Nodo? nodo, ref string datos)
    {
        if (nodo != null)
        {
            if (nodo.Izquierdo != null)
            {
                RecorridoInorden(nodo.Izquierdo, ref datos);
            }

            Seleccionar(nodo, ref datos);

            if (nodo.Derecho != null)
            {
                RecorridoInorden(nodo.Derecho, ref datos);
            }

        }
        
    }

    private void RecorridoPreorden(Nodo? nodo, ref string datos)
    {
        if (nodo != null)
        {
            Seleccionar(nodo, ref datos);

            if (nodo.Izquierdo != null)
            {
                RecorridoInorden(nodo.Izquierdo, ref datos);
            }


            if (nodo.Derecho != null)
            {
                RecorridoInorden(nodo.Derecho, ref datos);
            }

        }

    }

    private void RecorridoPosorden(Nodo? nodo, ref string datos)
    {
        if (nodo != null)
        {
            if (nodo.Izquierdo != null)
            {
                RecorridoInorden(nodo.Izquierdo, ref datos);
            }


            if (nodo.Derecho != null)
            {
                RecorridoInorden(nodo.Derecho, ref datos);
            }
            
            Seleccionar(nodo, ref datos);

        }

    }

    public string ObtenerDatos(Recorrido recorrido)
    {
        string datos = string.Empty;
        switch (recorrido)
        {
            case Recorrido.PreOrden:
                RecorridoPreorden(Raiz, ref datos);
                break;
            case Recorrido.InOrden:
                RecorridoInorden(Raiz, ref datos);
                break;
            case Recorrido.PostOrden:
                RecorridoPosorden(Raiz, ref datos);
                break;
        }
        return $"{recorrido}: {datos}";
    }
}
