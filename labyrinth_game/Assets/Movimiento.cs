using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2d;
    private float movimientoX; 
    private float movimientoY;
    private Animator animator;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
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

       
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
