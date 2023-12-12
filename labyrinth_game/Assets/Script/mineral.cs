using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineral : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos); 
            Destroy(gameObject);
        }
    }
}
