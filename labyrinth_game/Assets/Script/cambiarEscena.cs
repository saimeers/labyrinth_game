using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{
   public void escena_nivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void escena_start()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void escena_descripcion()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
   
    public void Quitar()
    {
        Application.Quit();
    }
}
