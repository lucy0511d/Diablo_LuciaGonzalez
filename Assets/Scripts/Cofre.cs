using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable // es necesario meterle el mismo metodo en este script que hay en ese
{
    private Outline outline;
    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;

    public void Interactuar(Transform interactuador)
    {
        
    }

    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
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
