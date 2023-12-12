using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private float tiempoMax;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderObj;
    [SerializeField] private GameObject mini_mapa;
    private float tiempoActual;
    private bool tiempoActivado = false;

    private void Update()
    {
        if(tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if(tiempoActual <= 0) 
        {
            Debug.Log("Puedes activar con M el mini mapa");
            sliderObj.SetActive(false);
            mini_mapa.SetActive(true);
            CambiarTemporizador(false);
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;

    }
    public void ActivarTemporizador()
    {
        slider.maxValue = tiempoMax;
        tiempoActual = tiempoMax;
        CambiarTemporizador(true);
    }
    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

}
