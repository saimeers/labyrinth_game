using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour
{
    public GameObject UIPause;
    public GameObject UIMuerte;
    public GameObject minimapa;
    public GameObject Jugador;
    public GameObject btnPause;
    private bool juegoPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPause)
            {
                Reanudar();
            }
            else
            {
                Pause();
            }
        }
        Muerte();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        juegoPause = true;
        UIPause.SetActive(true);
        btnPause.SetActive(false);
        minimapa.SetActive(false);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        juegoPause = false;
        UIPause.SetActive(false);
        btnPause.SetActive(true);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    public void Muerte()
    {
        if(Jugador == null)
        {
            UIPause.SetActive(false);
            btnPause.SetActive(false);
            UIMuerte.SetActive(true);
            minimapa.SetActive(false);
        }
    }

    public void Nivel()
    {
        SceneManager.LoadScene(0);
    }
    

}
