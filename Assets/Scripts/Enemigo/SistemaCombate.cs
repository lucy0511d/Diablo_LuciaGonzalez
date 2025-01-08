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
        
        //3.Marca como destino constantemente (Update()) al target (Definido en main)
        agent.SetDestination(main.MainTarget.position);
    }
}
