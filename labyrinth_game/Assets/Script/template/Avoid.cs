using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Avoid : Mechanic
{
    [SerializeField] private Transform controlador;
    private float count = 0;
    [SerializeField] private Image zona;
    [SerializeField] private float radio;
    [SerializeField] private GameObject dinamiteUI;
    [SerializeField] private GameObject texto;
    [SerializeField] private GameObject cartel;
    [SerializeField] private bool activo = false;

    private void Awake()
    {
        zona.color = Color.red;
        PlayerPrefs.SetFloat("Obstaculo", 0);
    }
    private void Update()
    {
        Behaviour();
        if (Input.GetKey(KeyCode.C))
        {
           Position();
        }
        Login.singleton.stats.evasion = ((int)count);
        PlayerPrefs.SetFloat("Obstaculo", count);
    }
    public override void Behaviour()
    {
        texto.GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("Obstaculo").ToString();

        Collider2D[] obj = Physics2D.OverlapCircleAll(controlador.position, radio);
        foreach (Collider2D col in obj)
        {
            
            if (col.CompareTag("dinamite"))
            {
                activo = true;
                dinamiteUI.SetActive(true);
                Destroy(col.gameObject);
            }
        }
    }

    public override void Position()
    {
        Collider2D[] obj = Physics2D.OverlapCircleAll(controlador.position, radio);
        foreach (Collider2D col in obj)
        {
            if (col.CompareTag("obstaculo") && activo == true)
            {
                activo = false;
                zona.color = Color.red;
                dinamiteUI.SetActive(false);
                cartel.SetActive(false);
                count++;
                Destroy(col.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("obstaculo") && activo == true)
        {
            zona.color = Color.green;
            cartel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("obstaculo"))
        {
            zona.color = Color.red;
            cartel.SetActive(false);
        }
    }
}
