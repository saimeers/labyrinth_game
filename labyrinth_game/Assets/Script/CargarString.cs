using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CargarString : MonoBehaviour
{

    [SerializeField] private GameObject descripcion1;
    private void Start()
    {
        descripcion1 = GameObject.FindGameObjectWithTag("texto");
        descripcion1.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("descripcion1");
    }
}
