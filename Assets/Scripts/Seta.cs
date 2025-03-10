using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seta : MonoBehaviour, IInteractuable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO misionAsociada;
    
    private Outline outline;

    public void Interactuar(Transform interactuador)
    {
        misionAsociada.estadoActual++;//Estamos a un paso mas de completar la mision
        if (misionAsociada.estadoActual < misionAsociada.repeticionesTotales)
        {
            eventManager.ActualizarMision(misionAsociada);
        }
        else
        {
            eventManager.TerminarMision(misionAsociada);
            SceneManager.LoadScene(2);
        }
        eventManager.ActualizarMision(misionAsociada);
        Destroy(gameObject);
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit() 
    { 
      outline.enabled = false;
    }
}
