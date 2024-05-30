using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
public class GUIManager : MonoBehaviour
{

    // SINGLETONS 
    // patrón de diseño en donde se limita la creación de 
    // más de 1 de instancia de 1 tipo 
    // alternativa a utilizar miembros estáticos 
    // cuándo usar singleton?
    // cuando necesitamos que exista un objeto por diferentes razones
    // - facilidad para debuggear
    // - poder agregarlo a un game object
    // - poder serializarlo / utilizarlo de argumento

    // https://en.wikipedia.org/wiki/Singleton_pattern
    // tradicionalmente el singleton restringe la creación de nuevos objetos
    // en este contexto no se puede hacer así así que hay que hacerlo correctivo

    // hagamos una propiedad!
    // propiedad - mecanismo de C# (existe en otros lenguajes)
    // que restringe quién lee y quién escribe un valor
    // el valor puede ser declarado explícitamente o ser anónimo
    public static GUIManager Instance 
    {
        private set;
        get;
    }

    // por qué usar un manager de GUI / HUD?
    // para no tener referencias a los widgets dispersas en toda la escena
    [SerializeField]
    private TMP_Text _textito;

    void Awake()
    {
        // mecanismo para asegurar que exista sólo 1
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            // si ya hubiera alguno asignado
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_textito, "TEXTITO NO PUEDE SER NULO EN GUI MANAGER");
    }

    public void SetTextito(string mensaje)
    {
        _textito.text = mensaje;
    }
}
