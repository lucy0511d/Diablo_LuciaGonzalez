using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogo")] 
public class DialogoSO : ScriptableObject
{
    [TextArea(5,10)]
    public string[] frases;
    public float tiempoentreletras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
