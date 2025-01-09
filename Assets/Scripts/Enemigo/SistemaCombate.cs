using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
   
    //Awake vs OnEnable vs Start
    private void Awake()
    {
        main.Combate = this;
    }
    //OnEnable: se ejecuta cada vez que se habilita el script
    private void OnEnable()//El combate ha sido habilitado
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // si existe un  maintarget y ese target es alcanzable...
        if(main.MainTarget != null && agent.CalculatePath(main.MainTarget.position, new NavMeshPath())) //calculatepath: mira si hay o no camino hacia el jugador (calcula este recorrido a traves de este path)
        {
            //3.Marca como destino constantemente (Update()) al target (Definido en main)
            EnfocarObjetivo();
            agent.SetDestination(main.MainTarget.position);
            if (agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("attacking", true);
            }
            
        }
        else //Si no es alcanzable
        {
            main.ActivarPatrulla();
        }
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0; //para que no se tumbe si el player salta
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }
    //1. hacer un evento de animacion en el momento en el que el enemigo ataca
    //2. Hacer script EnemyVisual y añadirlo a enemyvisual
    //3. En ese script añasr
}
