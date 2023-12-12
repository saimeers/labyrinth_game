using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTemporizador : MonoBehaviour
{
    [SerializeField] private Temporizador temporizador;
    [SerializeField] private GameObject slider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            slider.SetActive(true);
            temporizador.ActivarTemporizador();
            Destroy(gameObject);
        }
    }
}
