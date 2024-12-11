using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    private void Awake()
    {
        //Referencio a mi animator
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Velocidad maxima = agent.speed
        //Velocidad actual = agent.velocity
    }

    // Update is called once per frame
    void Update()
    {
        //Todos los frames voy actualizando mi velocity en funcion de mi velocidad actual
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
