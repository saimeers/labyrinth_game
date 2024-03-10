using UnityEngine;

public class Map : PsychologicalTask
{
    [SerializeField] public GameObject cartel;
    [SerializeField] public GameObject capsula;
    [SerializeField] public GameObject informacion;
    [SerializeField] public GameObject score;
    [SerializeField] public GameObject mapa;
    [SerializeField] public GameObject btn_pause;
    [SerializeField] public GameObject corazon;
    [SerializeField] private bool abierto = false;
    [SerializeField] private int countMap;

    public void controllerMap()
    {
        if (abierto == false && Input.GetKeyDown(KeyCode.M))
        {
            mapa.SetActive(true);
            cartel.SetActive(false);
            capsula.SetActive(false);
            btn_pause.SetActive(false);
            informacion.SetActive(false);
            score.SetActive(false);
            corazon.SetActive(false);
            abierto = true;
        }
        else if (abierto == true && Input.GetKeyDown(KeyCode.M))
        {
            mapa.SetActive(false);
            score.SetActive(true);
            cartel.SetActive(true);
            capsula.SetActive(true);
            btn_pause.SetActive(true);
            informacion.SetActive(true);
            abierto = false;
            countMap++;
        }
    }
    public void end()
    {
        cartel.SetActive(false);

        PlayerPrefs.SetString("countMap", countMap.ToString());
        Destroy(mapa);
        Destroy(informacion);
        corazon.SetActive(true);
        gameObject.SetActive(false);
    }
   
    public void BtnCerrar()
    {
        mapa.SetActive(false);
        cartel.SetActive(true);
        informacion.SetActive(true);
        capsula.SetActive(true);
        btn_pause.SetActive(true);
        corazon.SetActive(true);
    }
}
