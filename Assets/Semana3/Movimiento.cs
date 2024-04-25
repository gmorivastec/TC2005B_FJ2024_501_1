// namespaces 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# 
// .NET
public class Movimiento : MonoBehaviour
{

    // cómo parametrizar atributos de la clase
    // debe ser un valor serializable
    [SerializeField]
    private float _velocidad = 5;

    // ciclo de vida
    // métodos que se invocan por parte del motor
    // en momentos específicos de la ejecución de un componente

    // se ejecuta una vez al inicio de la existencia
    // del componente
    // se ejecuta sin importar si el componente está habilitado
    void Awake()
    {
        print("AWAKE");
    }

    // una vez que awake fue invocado sigue start
    // también una sola vez
    // no corre si componente está deshabilitado
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
    }

    // Update is called once per frame
    // frame ?!
    // fps - frames per second
    // performance
    // 30 mínimo, 60+
    // intervalos irregulares
    void Update()
    {
        //print("UPDATE");
        // Update debe ser lo más magro posible
        // que SÍ ponemos en update
        // - input
        // - movimiento

        // input
        // 2 maneras tradicionalmente
        // - por eventos 
        // - polling (sondeo, poleo)


        // cómo podemos obtener input?
        // - polling de dispositivo específico
        // - polling de ejes 

        // 3 eventos 
        // 1ro - tecla estaba libre pero ahora está presionada
        if(Input.GetKeyDown(KeyCode.P))
        {
            print("KEY DOWN P");
        }

        // 2do - tecla estaba presionada y sigue presionada
        if(Input.GetKey(KeyCode.P))
        {
            print("KEY P");
        }

        // 3ro - tecla estaba presionada y ahora está libre
        if(Input.GetKeyUp(KeyCode.P))
        {
            print("KEY UP P");
        }

        if(Input.GetMouseButtonDown(0))
        {
            print("MOUSE BUTTON DOWN");
        }

        // problema de polling a dispositivo específico?
        // código está asociado a dispositivo específico
        // no es flexible 
        // no considera otras opciones
        
        // solución - ejes (axis, axes)
        // abstracción de entrada en software
        // el valor de un eje se representa con un float 
        // [-1, 1]
    
        // para sus variables usen nombres descriptivos
        float horizontal = Input.GetAxis("Horizontal");
        //print(horizontal);
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(
            _velocidad * horizontal * Time.deltaTime, 
            _velocidad * vertical * Time.deltaTime, 
            0,
            Space.World // la traslación puede ser con respecto al mundo o a si mismo
        );

        // cómo detectar un eje como botón
        if(Input.GetButtonDown("Jump"))
        {
            print("JUMP!");
        }
    }

    // se ejecuta en intervalos regulares
    // definidos en el motor
    void FixedUpdate()
    {
        //print("FIXED UPDATE");

    }

    void LateUpdate()
    {
        // corre una vez por frame
        // después de todos los updates
        //print("LATE UPDATE");
    }

    // COLISIONES
    // 2 o más geometrías se tocan

    // REQUISITOS PARA PODER DETECTAR COLISIONES
    // 1. 2 o más objetos
    // 2. todos los involucrados tienen un collider
    // 3. el objeto que se mueve tiene rigidbody

    void OnCollisionEnter(Collision c) 
    {
        // Collision es un objeto que tiene 
        // información relacionada a la colisión 
        // ejemplo:
        // - puntos de contacto
        // - fuerzas involucradas
        // - referencia al objeto colisionado
        print(
            "COLLISION ENTER " + 
            c.gameObject.layer + 
            " " + 
            c.transform.tag
        );
        
        if(c.gameObject.layer == 3)
        {
            print("LAYER MIA!");
        }
    }
    void OnCollisionStay(Collision c) 
    {
        Debug.Log("COLLISION STAY");
    }
    void OnCollisionExit(Collision c) 
    {
        print("COLLISION EXIT");
    }

    // Trigger - 
    // detectamos colisión PERO sin reacción física
    void OnTriggerEnter(Collider c)
    {
        print("TRIGGER ENTER");
    }

    void OnTriggerStay(Collider c)
    {
        print("TRIGGER STAY");
    }

    void OnTriggerExit(Collider c)
    {
        print("TRIGGER EXIT");
    }
}
