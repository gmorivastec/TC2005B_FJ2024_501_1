using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EjemploAgent : MonoBehaviour
{

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento con click
        if(Input.GetMouseButtonDown(0))
        {
            // obtener rayito
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);

            // out parameter 
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters#out-parameter-modifier
            RaycastHit hit;

            // raycast
            // ray - rayito 
            // cast - lanzado, proyección 
            if(Physics.Raycast(rayito, out hit))
            {
                print("RAYITO CHOCÓ CON: " + hit.transform.name);
                _agent.destination = hit.point;
            }
        }
    }

    // existen métodos que ya usan raycast y son convenientes para 
    // nuestro uso
    // OnMouseDown
    // OnMouseDrag
    // OnMouseEnter 
    // OnMouseExit
    // OnMouseOver
    // OnMouseUp
    // OnMouseUpAsButton
    // si los quieres usar asegúrate que tu gameobject tenga collider
    // y no esté en la layer de ignorar raycast 
}
