namespace ArbolesGenerales
{
    internal class Nodo
    {
        public string Valor { get; set; }
        public Nodo? Hijo { get; set; }
        public Nodo? Hermano { get; set; }

        public Nodo(string valor = "", Nodo? hijo = null, Nodo? hermano = null)
        {
            Valor = valor;
            Hijo = hijo;
            Hermano = hermano;
        }
    }
}
