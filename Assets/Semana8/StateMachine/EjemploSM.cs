using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EjemploSM : MonoBehaviour
{

    // QUÉ USAR EN ORDEN DE COMPLEJIDAD
    // - if
    // - muchos ifs - maquina de estado
    // - demasiados estados - árbol de comportamiento (https://www.gamedeveloper.com/programming/behavior-trees-for-ai-how-they-work)
    // estados
    private Estado _feliz, _triste, _comiendo;

    // simbolos
    private Simbolo _acariciar, _reganar, _comer;

    // estado inicial / actual
    private Estado _actual; 

    private Component _behaviourActual;

    // lógica para detonar una aplicación de acariciar
    [SerializeField]
    private Transform _objetivo;

    [SerializeField]
    private float _distanciaConObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_objetivo, "Objetivo no puede ser nulo en state machine");
        StartCoroutine(VerificarDistancia());

        // inicializar simbolos
        _acariciar = new Simbolo("Acariciar");
        _reganar = new  Simbolo("Regañar");
        _comer = new Simbolo("Alimentar"); 

        // inicializar estados
        _feliz = new Estado("Feliz", typeof(FelizBehaviour));
        _triste = new Estado("Triste", typeof(TristeBehaviour));
        _comiendo = new Estado("Comiendo", typeof(ComiendoBehaviour));

        // función de transferencia
        _feliz.AgregarTransicion(_reganar, _triste);
        _feliz.AgregarTransicion(_comer, _comiendo);

        _triste.AgregarTransicion(_comer, _comiendo);

        _comiendo.AgregarTransicion(_acariciar, _feliz);

        // estado inicial
        _actual = _feliz;
        
        // agregar componente programáticamente
        _behaviourActual = gameObject.AddComponent(_actual.Behaviour); 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.A))
           AplicarSimbolo(_acariciar);
*/
        if(Input.GetKeyDown(KeyCode.R))
            AplicarSimbolo(_reganar);

        if(Input.GetKeyDown(KeyCode.C))
            AplicarSimbolo(_comer);
    }

    public void AplicarSimbolo(Simbolo simbolo)
    {
        Estado temp = _actual.AplicarSimbolo(simbolo);

        if(temp == _actual)
            return;

        // si hubo un cambio de estado actualizo referencia
        _actual = temp;

        // remuevo comportamiento del estado anterior
        Destroy(_behaviourActual);

        // agrego comportamiento de estado nuevo
        _behaviourActual = gameObject.AddComponent(_actual.Behaviour);
    }

    IEnumerator VerificarDistancia()
    {
        while(true)
        {
            if(Vector3.Distance(transform.position, _objetivo.position) < _distanciaConObjetivo)
            {
                AplicarSimbolo(_acariciar);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
