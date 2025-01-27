using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject toggleMision;
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;//te suscribes

    }

    private void ActivarToggleMision()
    {
        toggleMision.SetActive(true);
    }
}
