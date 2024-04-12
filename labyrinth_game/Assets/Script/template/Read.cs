using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Read : Mechanic
{
    [Header("Texto")]
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private TMP_Text descripcion;
    [SerializeField] private Image luz;
    [SerializeField] private GameObject btnAceptar;

    private void Awake()
    {
        Position();
    }
    private void Update()
    {
        Behaviour();
    }
    public void aceptar()
    {
        Login.singleton.stats.descripcion = inputText.text;
        Login.singleton.RegistrarEstadisticas();
        SceneManager.LoadScene(2);
    }

    public override void Behaviour()
    {
        if (descripcion.text.Length < 100)
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

    public override void Position()
    {
        luz.color = Color.red;
    }
}
