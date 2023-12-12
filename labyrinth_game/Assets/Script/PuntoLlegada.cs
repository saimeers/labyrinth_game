using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoLlegada : MonoBehaviour
{

    [SerializeField] private Temporizador temporizador;
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private GameObject minimapa;
    [SerializeField] private GameObject slider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            temporizador.DesactivarTemporizador();
            panelVictoria.SetActive(true);
            slider.SetActive(false);
            minimapa.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
