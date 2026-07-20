using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolesBinarios;

internal class Nodo
{
    public int Valor { get; set; }
    public Nodo? Izquierdo { get; set; }
    public Nodo? Derecho { get; set; }

    public Nodo(int valor, Nodo? izquierdo = null, Nodo? derecho = null)
    {
        Valor = valor;
        Izquierdo = izquierdo;
        Derecho = derecho;
    }
}
