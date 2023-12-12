using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeerInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private TMP_Text descripcion;
    [SerializeField] private Image luz;
    [SerializeField] private GameObject btnAceptar;


    private void Awake()
    {
        luz.color = Color.red;
    }
    private void Update()
    {
        if(descripcion.text.Length < 299)
        {
            luz.color = Color.red;
            btnAceptar.SetActive(false);
        }
        if (descripcion.text.Length >= 20)
        {
            luz.color = Color.green;
            btnAceptar.SetActive(true);
        }

    }

    public void aceptar()
    {
        PlayerPrefs.SetString("descripcion1", inputText.text);
        SceneManager.LoadScene(0);
    }
}
