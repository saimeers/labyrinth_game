using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : PsychologicalTask
    { 
    [Header("Vida")]
    [SerializeField] private Image Corazon;
    [SerializeField] public int CantCorazon;
    [SerializeField] private RectTransform PosicionCorazon;
    [SerializeField] public Canvas MyCanvas;
    [SerializeField] private int OffSet;
    [SerializeField] private GameObject player;

    [Header("Control ventanas")]
    [SerializeField] private GameObject panelMuerte;
    [SerializeField] private GameObject reloj;
    [SerializeField] private GameObject crz;

    public void life()
    {
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
    public void dead()
    {
        if (CantCorazon <= 0)
        {
            panelMuerte.SetActive(true);
            Destroy(reloj);
            Destroy(crz);
            Destroy(player);
            Destroy(gameObject);
        }
    }
}
