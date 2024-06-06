using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Estado
{
    public string Nombre
    {
        get;
        private set;
    }

    public Type Behaviour
    {
        get;
        private set;
    }

    private Dictionary<Simbolo, Estado> _transferencia;

    public Estado(string nombre, Type behaviour)
    {
        this.Nombre = nombre;
        this.Behaviour = behaviour;
        _transferencia = new Dictionary<Simbolo, Estado>();
    }

    public void AgregarTransicion(Simbolo simbolo, Estado estado)
    {
        _transferencia.Add(simbolo, estado);
    }

    public Estado AplicarSimbolo(Simbolo simbolo)
    {
        if(!_transferencia.ContainsKey(simbolo))
            return this;
        
        return _transferencia[simbolo];
    }
}
