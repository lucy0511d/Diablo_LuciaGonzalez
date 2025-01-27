using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField] private TMP_Text textoMision;//recipiente donde meter los textos de cada mision
    private Toggle toggle;//la cajita con el check

    public Toggle Toggle { get => toggle;  }
    public TMP_Text TextoMision { get => textoMision;  }
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
}
