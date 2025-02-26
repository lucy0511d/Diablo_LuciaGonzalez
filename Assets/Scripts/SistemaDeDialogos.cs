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
    [SerializeField] private EventManagerSO eventManager;
   
    public static SistemaDeDialogos sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera;

    private bool escribiendo; //Determina si el sistema está escribiendo o no.
    private int indiceFraseActual; //Marca la frase por la que voy.

    private DialogoSO dialogoActual; // Para almacenar con qué dialogo estamos trabajando

   

    private void Awake()
    {
        // si el trono esta vacio...
        if (sistema == null)
        {
            //Reclamo el trono y me lo quedo
            sistema = this;
            // Y no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // solo puede haber un rey
            Destroy(this.gameObject);
        }
    }
    public void IniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation); // Para cambiarle a la camera la posicion y rotacion sin necesidad de dos lineas de codigo
        Time.timeScale = 0f; //Pausamos el juegaso.
        //El dialogo actual con el que trabajamos es el que me dan por parámetro de entrada.
        this.dialogoActual = dialogo;
        Debug.Log("LLego");
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());
    }
    //Que el texto aparezca letra por letra
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = "";
        //"Hola aventurero te esperan grandes aventuras"
        char[] fraseEnLetras= dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);

        }
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        Debug.Log("Pasamos a la siguiete frase");
        if (escribiendo) //Si estamos escribiendo una frase...
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;//Avanzo de indice de frase...
            //y si aun me quedan frases..
            if (indiceFraseActual <dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());// La escribo..
            }
            else
            {
                TerminarDialogo();//Si no  me quedan frases, termino y cierro dialogo
            }
            
        }
    }
    private void CompletarFrase()
    {
       StopAllCoroutines();
        //Pongo la frase de golpe.
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        escribiendo = false;
    }
    private void TerminarDialogo()
    {
        Time.timeScale = 1f;// Volvemos al tiempo original.
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0; //Para posteriores dialogos.
        escribiendo = false;
        if(dialogoActual.tieneMision)
        {
            //Comunico al eventManager que hay una mision en este dialogo 
            eventManager.NuevaMision(dialogoActual.mision);
        }
        dialogoActual = null; // Ya no tenemos ningun dialogo 
       
    }
    
}
