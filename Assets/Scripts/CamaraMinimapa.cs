using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector3 distanciaAPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //Mido la distancia original que se tiene en escena.
        distanciaAPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() // se ejuta despues de todos los demas update
    {
        //Mi posicion en todos los frames es la del player MAS cierta distancia
        transform.position = player.transform.position + distanciaAPlayer;
    }

}
