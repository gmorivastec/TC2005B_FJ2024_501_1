
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Proyectil : MonoBehaviour
{

    // para poder afectar con física un objeto utilizamos su rigidbody
    // rigidbody es un componente aparte de mi script
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _fuerza = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        // cómo obtener referencia a otro componente
        // OJO AQUÍ: PUEDE REGRESAR NULL
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(
            transform.up * _fuerza, // transform.right, transform.front
            ForceMode.Impulse
        );
    }
}
