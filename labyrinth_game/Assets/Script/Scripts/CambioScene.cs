using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    public void scene(int number)
    {
        UnityEngine.Time.timeScale = 1f;
        SceneManager.LoadScene(number);
    }
    public void scene()
    {
        UnityEngine.Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        Login.singleton.EndGame();
    }
}
