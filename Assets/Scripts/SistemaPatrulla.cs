using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    [SerializeField] private NavMeshAgent agent;
    

    List<Vector3> listadoPuntos = new List<Vector3>(); // hay que crear la lista si no el valor es nulo

    private Vector3 destinoActual; // Marca el destino al cual tenemos que ir
    private int indiceRutaActual = -1; //Marca el indice del nuevo punto al cual patrullar
    private void Awake()
    {
        
        // Voy recorriendo todos los puntos que tiene mi ruta...
        foreach (Transform punto in ruta) // el foreach aparte de para arrays sirve para los hijos que tenga un objeto
        {
            // Y los a�ado en mi lista.
            listadoPuntos.Add(punto.position);

        }
        
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while(true) //Por siempre..
        {
            CalcularDestino();//1. Calculas un nuevo destino
            agent.SetDestination(destinoActual); //". Se te marca dicho destino
            //3. Esperas a llegar a dicho destino y repites
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= 0.2f); //Espera hasta que llegues a ese punto.
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
        
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;
        //Count para las listas es lo mismo que Length en los arrays
        if(indiceRutaActual >= listadoPuntos.Count)
        {
            //Si no me quedan puntos, volver� al punto 0
            indiceRutaActual = 0;
        }
        destinoActual = listadoPuntos[indiceRutaActual];
    }
}