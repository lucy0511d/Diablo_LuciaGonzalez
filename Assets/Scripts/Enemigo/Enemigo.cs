using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;
    
    private Transform mainTarget;
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget; }

    private void Start()
    {
        //Empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }
    public void ActivaCombate(Transform target)
    {
        //Ahora tenemos un target al cual perseguir
        mainTarget = target;
        //Nos dicen de activar el combate
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }
}
