using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Avoid : Mechanic
{
    [SerializeField] private Transform controlador;
    [SerializeField] private float count = 0;
    [SerializeField] private Image zona;
    [SerializeField] private float radio;
    [SerializeField] private GameObject dinamiteUI;
    [SerializeField] private GameObject texto;
    [SerializeField] private GameObject cartel;
    [SerializeField] private bool activo = false;
    [SerializeField] private AudioSource audioSourd;
    [SerializeField] private AudioClip boom;
    [SerializeField] private AudioClip tnt;

    private void Start()
    {
        audioSourd = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        zona.color = Color.red;
    }
    private void Update()
    {
        Behaviour();
        if (Input.GetKey(KeyCode.C))
        {
           Position();
        }
        Login.singleton.stats.evasion = ((int)count);
    }
    public override void Behaviour()
    {
        texto.GetComponent<TMP_Text>().text = count.ToString();

        Collider2D[] obj = Physics2D.OverlapCircleAll(controlador.position, radio);
        foreach (Collider2D col in obj)
        {
            
            if (col.CompareTag("dinamite"))
            {
                activo = true;
                dinamiteUI.SetActive(true);
                audioSourd.PlayOneShot(tnt);
                 Invoke("DestruirObjeto", 0.1f);
                Destroy(col.gameObject);
            }
        }
    }
    private void DestruirObjeto(GameObject obj)
    {
        Debug.Log("esperando");
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
                count = count + 1;
                audioSourd.PlayOneShot(boom);
                MovimientoCamara.Intance.MoverCamara(3, 2, 0.5f);
                Invoke("DestruirObjeto", 0.1f);
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
