using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion = 2f;
    [SerializeField] private float attackingDistance = 2f;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private Animator anim;

    private NavMeshAgent agent;
    private Camera cam;
    private PlayerAnimations playerAnimations;
    //Guardo la informacion del NPC actual con el que voy a hablar
    private Transform ultimoClick;

    public PlayerAnimations PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }

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
        if(ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;
            //Comprobar si he llegado al NPC
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //transform.DOLookAt(npc.transform.position, tiempoRotacion, AxisConstraint.Y).OnComplete( () => LanzarInteraccion(npc));  // Para que el player mire al NPC mientras habla
                LanzarInteraccion(interactuable);

            }
        }
        else if(ultimoClick && ultimoClick.TryGetComponent(out Enemigo enemigo))
        {
            //LO MISMO QUE EN INTERACTION
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
        
    }
    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
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

    internal void HacerDanho(float danhoAtaque)
    {
        
    }
}
