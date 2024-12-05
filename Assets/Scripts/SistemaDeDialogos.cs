using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDeDialogos : MonoBehaviour
{
    //Patrón SINGLETON
    //Asegurarte de que esta sea la UNICA INSTANCIA de "SistemaDeDialogo"
    //Asegura que esa instancia SEA ACCESIBLE desde cualquier punto del programa

    //
    public static SistemaDeDialogos sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo; //Determina si el sistema está escribiendo o no.
    private int indiceFraseActual; //Marca la frase por la que voy.

    private void Awake()
    {
        // si el trono esta vacio...
        if (sistema = null)
        {
            //Reclamo el trono y me lo quedo
            sistema = this;
            // Y no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // solo puede haber un rey
            Destroy(gameObject);
        }
    }
    public void IniciarDialogo(DialogoSO dialogo)
    {
        marcos.SetActive(true);
    }
    //Que el texto aparezca letra por letra
    private void EscribirFrase()
    {

    }
    private void SiguienteFrase()
    {

    }
    private void TerminarDialogo()
    {

    }
    
}
