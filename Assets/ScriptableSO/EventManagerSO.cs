using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Event manager")]

public class EventManagerSO : ScriptableObject
{   // Start is called before the first frame update
    public event Action OnNuevaMision;//EVENTO
    public void NuevaMision(MisionSO mision)
    {
        //Aqu� lanzo la notificaci�n (el evento) por si a alguien le interesa
        OnNuevaMision.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
