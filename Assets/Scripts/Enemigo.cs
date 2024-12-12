using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    private NavMeshAgent agent;

    List<Vector3> listadoPuntos = new List<Vector3>(); // hay que crear la lista si no el valor es nulo

    private Vector3 destinoActual; // Marca el destino al cual tenemos que ir
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        // Voy recorriendo todos los puntos que tiene mi ruta...
        foreach (Transform punto in ruta) // el foreach aparte de para arrays sirve para los hijos que tenga un objeto
        {
            // Y los añado en mi lista.
            listadoPuntos.Add(punto.position);

        }
        CalcularDestino();
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

   private IEnumerator PatrullarYEsperar()
   {
        agent.SetDestination(destinoActual);
        yield return null;

   }
    private void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
}
