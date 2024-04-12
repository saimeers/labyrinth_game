using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    private AudioSource audioSourd;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        audioSourd = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioSourd.Play();
        }
    }
}
