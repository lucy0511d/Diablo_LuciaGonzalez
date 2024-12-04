using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;

    private NavMeshAgent agent;
    private Camera cam;
    //Guardo la informacion del NPC actual con el que voy a hablar
    private NPC npcActual;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        Movimiento();
        //Si existe un npc al cual clicke...
        if(npcActual)
        {
            //Comprobar si he llegado al NPC
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(transform);
                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
        }
        
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); // te encuentra la posicion del boton en pantalla
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Mirar si el punto donde he impactado tiene el script "NPC"
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    //Y en ese caso, ese npc es el actual
                    npcActual = npc;
                    // Ahora mi distancia de parada es la de interaccion (pararme a X metros del NPC)
                    agent.stoppingDistance = distanciaInteraccion;
                }

                agent.SetDestination(hit.point); //hit.point el punto del impacto
            }
        }
    }
}
