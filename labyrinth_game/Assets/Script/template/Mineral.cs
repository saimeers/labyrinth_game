using System.Collections.Generic;
using UnityEngine;

public class Mineral : Element
{
    [Header("Puntos")]
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Thing puntaje;
    private AudioSource audioSourd;
    [SerializeField] private AudioClip recolectar;

    private void Start()
    {
        audioSourd = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSourd.PlayOneShot(recolectar);
            puntaje.SumarPuntos(cantidadPuntos);
            Invoke("DestruirObjeto", 0.1f); // Llama a DestruirObjeto() después de 0.2 segundos
        }
    }

    // Función para destruir el objeto
    private void DestruirObjeto()
    {
        Destroy(gameObject);
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
