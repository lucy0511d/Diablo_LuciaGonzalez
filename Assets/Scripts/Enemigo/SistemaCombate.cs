using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    // Start is called before the first frame update
    void Start()
    {
        main.Combate = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
