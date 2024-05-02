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

    // Start is called before the first frame update
    void Start()
    {
        // verificar nulidad de objeto
        Assert.IsNotNull(_original, "ORIGINAL NO PUEDE SER NULO EN CANION");
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
            // disparar!
            // para crear copias de un game object usamos
            // instantiate
            // para poder usarlo necesitamos un original
        }
    }
}
