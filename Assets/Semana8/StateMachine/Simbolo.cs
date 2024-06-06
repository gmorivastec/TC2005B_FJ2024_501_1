using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simbolo
{
    // propiedad - mecanismo que divide quién lee y quién escribe un valor
    // puede tener una variable declarada de manera explícita
    // o uan variable anónima
    public string Nombre
    {
        get;
        private set;
    }

    public Simbolo(string nombre)
    {
        this.Nombre = nombre;
    }
}
