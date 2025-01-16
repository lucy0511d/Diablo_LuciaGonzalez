using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

//Una interfaz es un listado de metodos que cumple todo aquello que (en este caso) sea INTERACTUABLE.
public interface IInteractuable
{
    // Con este script das una cualidad a un objeto
    //se Identifica con capaz de

    public void Interactuar(Transform interactuador);


}

