namespace ArbolesBinarios;

/// <summary>
/// Representa un árbol binario de búsqueda (Binary Search Tree, BST).
/// En este tipo de árbol:
/// <list type="bullet">
/// <item>
/// <description>Los valores menores que un nodo se almacenan en el subárbol izquierdo.</description>
/// </item>
/// <item>
/// <description>Los valores mayores que un nodo se almacenan en el subárbol derecho.</description>
/// </item>
/// </list>
/// Para simplificar la implementación, los valores duplicados no se insertan.
/// </summary>
internal class ArbolBinarioDeBusqueda
{
    /// <summary>
    /// Obtiene la raíz del árbol.
    /// Solo puede modificarse desde la propia clase.
    /// </summary>
    public Nodo? Raiz { get; private set; }

    /// <summary>
    /// Inicializa un árbol con un valor raíz.
    /// </summary>
    /// <param name="raiz">Valor del nodo raíz.</param>
    public ArbolBinarioDeBusqueda(int raiz)
    {
        Raiz = new Nodo(raiz);
    }

    /// <summary>
    /// Define los diferentes tipos de recorrido del árbol.
    /// </summary>
    public enum Recorrido
    {
        /// <summary>
        /// Nodo - Izquierdo - Derecho
        /// </summary>
        PreOrden,

        /// <summary>
        /// Izquierdo - Nodo - Derecho
        /// </summary>
        InOrden,

        /// <summary>
        /// Izquierdo - Derecho - Nodo
        /// </summary>
        PostOrden
    }

    /// <summary>
    /// Inserta un nuevo valor en el árbol.
    /// </summary>
    /// <param name="valor">Valor que se desea insertar.</param>
    public void Insertar(int valor)
    {
        Insertar(valor, Raiz);
    }

    /// <summary>
    /// Inserta una colección de valores en el árbol.
    /// </summary>
    /// <param name="valores">Valores que se desean insertar.</param>
    public void Insertar(int[] valores)
    {
        foreach (int valor in valores)
        {
            Insertar(valor, Raiz);
        }
    }

    /// <summary>
    /// Inserta recursivamente un valor en la posición que le corresponde.
    /// </summary>
    /// <param name="valor">Valor a insertar.</param>
    /// <param name="nodo">Nodo actual durante la búsqueda de la posición.</param>
    private void Insertar(int valor, Nodo? nodo)
    {
        // Si el valor es mayor, pertenece al subárbol derecho.
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

        // Si el valor es menor, pertenece al subárbol izquierdo.
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

        // Si el valor es igual, no se inserta.
    }

    /// <summary>
    /// Recorre el árbol mostrando la relación entre los nodos.
    /// Este recorrido no corresponde a un recorrido clásico
    /// (preorden, inorden o postorden); únicamente genera una
    /// representación textual de la estructura del árbol.
    /// </summary>
    /// <param name="nodo">Nodo actual.</param>
    /// <param name="datos">Cadena donde se construye la representación.</param>
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

    /// <summary>
    /// Devuelve una representación textual de la estructura del árbol.
    /// </summary>
    /// <returns>Cadena con los nodos y sus relaciones.</returns>
    public string ObtenerDatos()
    {
        string datos = string.Empty;
        Recorrer(Raiz, ref datos);
        return datos;
    }

    /// <summary>
    /// Agrega el valor de un nodo a la cadena de salida,
    /// separando los elementos por comas.
    /// </summary>
    /// <param name="nodo">Nodo que será agregado.</param>
    /// <param name="datos">Cadena donde se construye el recorrido.</param>
    private void Seleccionar(Nodo nodo, ref string datos)
    {
        string coma = (datos == string.Empty) ? string.Empty : ",";
        datos += $"{coma}{nodo.Valor}";
    }

    /// <summary>
    /// Recorre el árbol en Inorden.
    /// Orden del recorrido:
    /// Izquierdo → Nodo → Derecho.
    /// </summary>
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

    /// <summary>
    /// Recorre el árbol en Preorden.
    /// Orden del recorrido:
    /// Nodo → Izquierdo → Derecho.
    /// </summary>
    private void RecorridoPreorden(Nodo? nodo, ref string datos)
    {
        if (nodo != null)
        {
            Seleccionar(nodo, ref datos);

            if (nodo.Izquierdo != null)
            {
                RecorridoPreorden(nodo.Izquierdo, ref datos);
            }

            if (nodo.Derecho != null)
            {
                RecorridoPreorden(nodo.Derecho, ref datos);
            }
        }
    }

    /// <summary>
    /// Recorre el árbol en Postorden.
    /// Orden del recorrido:
    /// Izquierdo → Derecho → Nodo.
    /// </summary>
    private void RecorridoPosorden(Nodo? nodo, ref string datos)
    {
        if (nodo != null)
        {
            if (nodo.Izquierdo != null)
            {
                RecorridoPosorden(nodo.Izquierdo, ref datos);
            }

            if (nodo.Derecho != null)
            {
                RecorridoPosorden(nodo.Derecho, ref datos);
            }

            Seleccionar(nodo, ref datos);
        }
    }

    /// <summary>
    /// Obtiene los valores del árbol según el tipo de recorrido indicado.
    /// </summary>
    /// <param name="recorrido">Tipo de recorrido a realizar.</param>
    /// <returns>
    /// Una cadena con el nombre del recorrido y los valores obtenidos.
    /// </returns>
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