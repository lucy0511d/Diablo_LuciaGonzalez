using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionSO misionAsociada;

    private Outline outline;
    [SerializeField] private DialogoSO dialogo1;
    [SerializeField] private DialogoSO dialogo2;
    private DialogoSO dialogoActual;

    [SerializeField] private float tiempoRotacion;
    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    [SerializeField] private Transform cameraPoint;
    
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
        dialogoActual = dialogo1;
    }
    private void OnEnable()
    {
        //me suscribo al evento para estar atento de cuando cambiar de dialogo
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;
        }
    }

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDeDialogos.sistema.IniciarDialogo(dialogoActual, cameraPoint));

        //OnComplete -> pones dentro lo que quieres hacer
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto); //Vector2.zero = (0,0)
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
    
}

