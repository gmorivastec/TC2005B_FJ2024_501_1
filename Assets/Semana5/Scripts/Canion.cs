using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// OJO PARA DEFINICIÓN DE CLASES
// NO pensar en entidades sino en funcionalidades
// aquí ponemos funcionalidad de movimiento y de disparo por cuestiones prácticas
public class Canion : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private GameObject _original;

    [SerializeField]
    private Transform _referencia;

    private IEnumerator _corutinaE;
    private Coroutine _corutinaC;

    // Start is called before the first frame update
    void Start()
    {
        // verificar nulidad de objeto
        Assert.IsNotNull(_original, "ORIGINAL NO PUEDE SER NULO EN CANION");
        Assert.IsNotNull(_referencia, "REFERENCIA NO PUEDE SER NULO EN CANION");
    
        // StartCoroutine("Temporizador");
        StartCoroutine(Temporizador());
        StartCoroutine(Recurrente());
        _corutinaE = Disparo();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(
            horizontal * Time.deltaTime * _speed,
            0,
            0
        );

        if(Input.GetButtonDown("Jump"))
        {
            _corutinaC = StartCoroutine(_corutinaE);
        }

        if(Input.GetButtonUp("Jump"))
        {
            // modo 1 
            // StopAllCoroutines();

            // si usas string
            // StopCoroutine("Disparo");

            // con referencia al IEnumerator
            // StopCoroutine(_corutinaE);

            // con referencia a Coroutine
            StopCoroutine(_corutinaC);
        }   
    }

    // CORRUTINAS 
    // mecanismo para ejecución de código de manera
    // pseudoconcurrente
    // concurrencia?

    // casos de uso común:
    // - lógica que requiera una espera / tiempo
    // - lógica que sea recurrente PERO no en update
    // - para manejo de lógica asíncrona 

    // corrutinas vs hilo
    // - corrutina depende del componente 
    // - corrutina no es realmente concurrente

    // ejemplo de corrutina
    IEnumerator Temporizador()
    {
        // este código es non-blocking
        yield return new WaitForSeconds(2);
        print("CORRUTINA DE TIEMPO");
    }

    IEnumerator Recurrente()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            print("CORRUTINA RECURRENTE");
        }
    }

    IEnumerator Disparo()
    {
        while(true)
        {
            // disparar!
            // para crear copias de un game object usamos
            // instantiate
            // para poder usarlo necesitamos un original
            Instantiate(
                _original,
                _referencia.position,
                _referencia.rotation
            );
            yield return new WaitForSeconds(1);
        }
    }
}
