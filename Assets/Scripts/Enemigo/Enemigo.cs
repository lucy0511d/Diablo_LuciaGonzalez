using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    private void Start()
    {
        //Empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }
    public void ActivaCombate()
    {
        //Nos dicen que activemos el combate
        combate.enabled = true;
    }
}
