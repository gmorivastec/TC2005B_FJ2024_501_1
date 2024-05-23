using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIEventManager : MonoBehaviour
{
    // para escuchar eventos utilizamos un patrón de diseño
    // que se llama Observer 
    // https://en.wikipedia.org/wiki/Observer_pattern

    // en C# puedes usar delegates
    public void BotonPresionado()
    {
        print("BOTON PRESIONADO");

        // carga síncrona de escenas 
        // SceneManager.LoadScene(1);
        SceneManager.LoadScene("Semana5");
    }

    public void SliderMovido(float valorSlider)
    {
        print("SLIDER: " + valorSlider);
    }

    public void Evento1(string valor)
    {
        print("EVENTO: " + valor);
    }

    public void Evento2(string s, float f)
    {
        print("EVENTO: " + s + " " + f);
    }
}
