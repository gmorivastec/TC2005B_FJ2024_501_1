using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITester : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // ejemplo de cómo acceder a una instancia de 
        // una clase singletoneada
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GUIManager.Instance.SetTextito("HOLA!");
            // ventaja 1 - complejidad baja (constante)

            // alternativas: 
            // GameObject.Find / FindByType 
            // requieren más proceso, son más lentas
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            GUIManager.Instance.SetTextito("ADIÓS");
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            GUIManager.Instance.SetTextito("HASTA PRONTO");
        }
    }
}
