using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Event manager")]

public class EventManagerSO : ScriptableObject
{   
    public event Action<MisionSO> OnNuevaMision;//EVENTO
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
    public void NuevaMision(MisionSO mision)
    {
        //Aqu� lanzo la notificaci�n (el evento) por si a alguien le interesa
        //?.: Invocaci�n SEGURA. Se asegura de que haya suscriptores.
        OnNuevaMision?.Invoke(mision);
    }
    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }
    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }


}
