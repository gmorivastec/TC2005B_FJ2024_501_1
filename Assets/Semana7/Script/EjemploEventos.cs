using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EventoArgs1 : UnityEvent<string>{}

[Serializable]
public class EventoArgs2 : UnityEvent<string, float>{}


public class EjemploEventos : MonoBehaviour
{

    

    // ¿por qué usar eventos?
    // desacoplar código 
    // NO necesito conocer al oyente / observador
    // se vuelve mucho más reutilizable

    // ¿cómo saber que necesito un evento?
    // si espero un componente desde el exterior
    [SerializeField]
    private UnityEvent _evento0;

    [SerializeField]
    private EventoArgs1 _evento1;

    [SerializeField]
    private EventoArgs2 _evento2;

    // Start is called before the first frame update
    void Start()
    {
        // a un evento nos podemos suscribir programáticamente
        // o por medio del editor
        _evento0.AddListener(PruebaEvento);
    }

    void PruebaEvento()
    {
        print("EVENTO DETONADO!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // así se detona un evento
            _evento0.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            _evento1.Invoke("EVENTO 1 INVOCADO!");
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            _evento2.Invoke("EVENTO 2 INVOCADO!", 2);
        }
    }
}
