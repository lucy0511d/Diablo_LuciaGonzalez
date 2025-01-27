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

    public int estadoActual;

    public int indiceMision;//identificador unico de misiones.
}
