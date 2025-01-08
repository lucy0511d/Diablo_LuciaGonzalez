using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    // Start is called before the first frame update
    private void Awake()
    {
        main.Combate = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
