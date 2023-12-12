using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{

    [Header("Movimineto")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2d;
    private float movimientoX;
    private float movimientoY;
    private Animator animator;


    [Header("Vida")]
    [SerializeField] private Image Corazon;
    [SerializeField] private int CantCorazon;
    [SerializeField] private RectTransform PosicionCorazon;
    [SerializeField] private Canvas MyCanvas;
    [SerializeField] private int OffSet;


    [Header("Control ventanas")]
    [SerializeField] private GameObject panelMuerte;
    [SerializeField] private GameObject reloj;
    [SerializeField] private GameObject crz;

    [Header("Mapa")]
    [SerializeField] private GameObject cartel;
    [SerializeField] private GameObject mapa;
    [SerializeField] private GameObject mini_mapa;
    [SerializeField] private GameObject btn_pause;
    [SerializeField] private GameObject corazon;
    [SerializeField] private bool abierto = false;





    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Transform PosCorazon = PosicionCorazon;
        for (int i = 0; i < CantCorazon; i++)
        {
            Image NewCorazon = Instantiate(Corazon,
                PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new
                Vector2(PosCorazon.position.x + OffSet,
                PosCorazon.position.y);
        }

    }
    private void Update()
    {
        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);

        if (movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimaX", movimientoX);
            animator.SetFloat("UltimaY", movimientoY);
        }

        direccion = new Vector2(movimientoX, movimientoY).normalized;
        if (abierto == false && Input.GetKeyDown(KeyCode.M))
        {
            mapa.SetActive(true);
            cartel.SetActive(false);
            btn_pause.SetActive(false);
            corazon.SetActive(false);
            abierto = true;
        } 
        else if(abierto == true && Input.GetKeyDown(KeyCode.M))
        {
            mapa.SetActive(false);
            cartel.SetActive(true);
            btn_pause.SetActive(true);
            corazon.SetActive(true);
            abierto = false;
        }
        if (CantCorazon <= 0)
        {
            panelMuerte.SetActive(true);
            Destroy(reloj);
            Destroy(crz);
            Destroy(gameObject);
        }
       

    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dano")
        {
            Destroy(MyCanvas.transform.GetChild(CantCorazon + 1).gameObject);
            CantCorazon -= 1;
        }
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(mapa);
            Destroy(cartel);
        }
        if(collision.gameObject.tag == "mini_mapa")
        {
            Destroy(mini_mapa);
        }
    }

    public void cerrar()
    {
        mapa.SetActive(false);
        cartel.SetActive(true);
        btn_pause.SetActive(true);
        corazon.SetActive(true);
    }
}
