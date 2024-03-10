using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earthquake : Event
{
    [Header("Temporizador")]
    [SerializeField] private float timeMax;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderObj;
    [SerializeField] private GameObject maps;
    [SerializeField] private GameObject cartel;
    [SerializeField] private bool abierto = false;
    [SerializeField] private bool fullTime = false;
    [SerializeField] private int countMap;
    [SerializeField] private Thing puntaje;
    private float timeNow;
    private bool timeActive = false;


    private void Update()
    {
        if(timeActive )
        {
            Count();
        }
        ControlleMap();
        Login.singleton.stats.penalizacion = countMap;
        PlayerPrefs.SetString("countMiniMap", countMap.ToString());
    }

    private void Count()
    {
        timeNow -= UnityEngine.Time.deltaTime;

        if(timeNow >= 0)
        {
            slider.value = timeNow;
        }
        if (timeNow <= 0)
        {
            Debug.Log("Puedes activar con M el mini mapa");
            Destroy(sliderObj);
            CountTime(false);
            cartel.SetActive(true);
            fullTime = true;
        }

        }
    public void ControlleMap()
    {
        if (fullTime == true)
        {
            if (abierto == false && Input.GetKeyDown(KeyCode.M))
            {
                maps.SetActive(true);
                cartel.SetActive(false);
                abierto = true;
                puntaje.SumarPuntos(-30);
                countMap++;
            }
            else if (abierto == true && Input.GetKeyDown(KeyCode.M))
            {
                maps.SetActive(false);
                cartel.SetActive(true);
                abierto = false;
            }
        }
    }
    private void CountTime(bool estado)
    {
        timeActive = estado;

    }
    public override void start_()
    {
        slider.maxValue = timeMax;
        timeNow = timeMax;
        CountTime(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mini_mapa")
        {
            Destroy(cartel);
            Destroy(maps);
        }
    }
    public override void end()
    {
        CountTime(false);
    }


}
