using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Move : Mechanic
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2d;
    private Animator animator;
    private float movimientoX;
    private float movimientoY;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Behaviour();
    }
    private void FixedUpdate()
    {
        Position();
    }
    public override void Behaviour()
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
    }
    public override void Position()
    {
        rb2d.MovePosition(rb2d.position + direccion * velocidadMovimiento * UnityEngine.Time.fixedDeltaTime);
    }
   
   
}
