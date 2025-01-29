using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;//"Recoge....
    public string ordenFinal;//"Vuelve a hablar con...

    public bool repetir;//si la mision tiene varios pasos. ej seta 1, seta 2, seta 3
    public int repeticionesTotales;

    [NonSerialized] public int estadoActual = 0; //Para que se pueda resetear la variable entre partidas


    public int indiceMision;//identificador unico de misiones.
}
