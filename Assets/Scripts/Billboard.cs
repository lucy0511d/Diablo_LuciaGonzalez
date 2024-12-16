using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Para que la barra pueda mirar a camara (s
        //olo funciona con camara ortográfica)
        transform.forward = -cam.transform.forward;
    }
}
