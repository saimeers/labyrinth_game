using System.Collections.Generic;
using UnityEngine;

public class Mineral : Element
{
    [Header("Puntos")]
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Thing puntaje;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos); 
            Destroy(gameObject);
        }
    }
    public override void addAction(List<Mechanic> mechanics)
    {
        throw new System.NotImplementedException();
    }

    public override void collide(List<Element> elements)
    {
        throw new System.NotImplementedException();
    }
}
