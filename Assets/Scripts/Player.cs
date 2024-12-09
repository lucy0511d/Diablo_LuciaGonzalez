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
    private Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1) // si no estamos en pausa
        {
            Movimiento();
        }
        
        //Si existe un npc al cual clicke...
        if(ultimoClick && ultimoClick.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = distanciaInteraccion;
            //Comprobar si he llegado al NPC
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npc.Interactuar(transform);
                ultimoClick = null;
                
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
        
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); // te encuentra la posicion del boton en pantalla
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point); //hit.point el punto del impacto
                ultimoClick = hit.transform;
            }
        }
    }
}
