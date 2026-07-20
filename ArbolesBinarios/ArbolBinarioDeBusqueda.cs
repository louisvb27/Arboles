namespace ArbolesBinarios;

internal class ArbolBinarioDeBusqueda
{
    public Nodo? Raiz { get; private set; }
    public ArbolBinarioDeBusqueda(int raiz)
    {
        Raiz = new Nodo(raiz);
    }

}
