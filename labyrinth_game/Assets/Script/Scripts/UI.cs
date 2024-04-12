using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Header("Pause")]
    public GameObject UIPause;
    public GameObject UIMuerte;
    public GameObject minimapa;
    public GameObject Player;
    public GameObject btnPause;
    [SerializeField] public GameObject capsula;
    [SerializeField] public GameObject informacion;
    [SerializeField] public GameObject cartel;
    [SerializeField] public GameObject caja;
    private bool gamePause = false;
    [Header("Victoria")]
    [SerializeField] private Rockslide temporizador;
    [SerializeField] private GameObject vida;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePause)
            {
                play();
            }
            else
            {
                pause();
            }
        }
        dead();
    }
    public void scene(int number)
    {
        UnityEngine.Time.timeScale = 1f;
        SceneManager.LoadScene(number);
    }
    public void pause()
    {
        UnityEngine.Time.timeScale = 0f;
        gamePause = true;
        UIPause.SetActive(true);
        btnPause.SetActive(false);
        informacion.SetActive(false);
        cartel.SetActive(false);
        caja.SetActive(false);
        minimapa.SetActive(false);
        capsula.SetActive(false);
    }
    public void play()
    {
        UnityEngine.Time.timeScale = 1f;
        gamePause = false;
        UIPause.SetActive(false);
        caja.SetActive(true);
        btnPause.SetActive(true);
        capsula.SetActive(true);
        if (informacion == true)
        {
            informacion.SetActive(true);
            cartel.SetActive(true);
        }
        

    }
    public void dead()
    {
        if (Player == null)
        {
            UIPause.SetActive(false);
            btnPause.SetActive(false);
            UIMuerte.SetActive(true);
            minimapa.SetActive(false);
            capsula.SetActive(false);
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            temporizador.end();
            minimapa.SetActive(false);
            scene(5);
        }
    }


}
