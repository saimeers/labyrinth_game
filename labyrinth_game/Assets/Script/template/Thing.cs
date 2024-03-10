
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Thing : Element
{
    [Header("Texto")]
    private float puntos;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = puntos.ToString("0");
        Login.singleton.stats.puntaje = ((int)puntos);
        PlayerPrefs.SetString("Point", puntos.ToString());
        PlayerPrefs.SetFloat("Puntaje", puntos);
    }
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
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

