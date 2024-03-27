using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    [Header("Control")]
    [SerializeField] private Rockslide temporizador;
    [SerializeField] private GameObject slider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && temporizador.temporizadorActivado == true)
        {
            slider.SetActive(true);
            temporizador.start_();
            Destroy(gameObject);
        }
    }
}
