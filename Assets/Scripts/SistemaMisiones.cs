using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private ToggleMision[] toggleMision;
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;//te suscribes
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += CerrarToggle;
    }

  

    private void ActivarToggleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if(mision.repetir)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
        }
        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO mision)
    {
        //actualizar el texto de la mision correspondiente
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
    }
    private void CerrarToggle(MisionSO mision)
    {
        //marcar el toggle como true
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;
    }
}
