using UnityEngine;

public class Match : Mechanic
{
    [SerializeField] private float puntaje;
    [SerializeField] private float obstaculos;
    [SerializeField] private GameObject habilitar;
    private void Update()
    {
        Behaviour();
    }
    public override void Behaviour()
    {
        puntaje = PlayerPrefs.GetFloat("Puntaje");
        obstaculos = PlayerPrefs.GetFloat("Obstaculo");

        if(puntaje >= 150 &&  obstaculos >= 3)
        {
            habilitar.SetActive(false);
        }
        else if(puntaje < 150 && obstaculos >= 3)
        {
            habilitar.SetActive(true);
        }
        else if(puntaje >= 150 && obstaculos < 3)
        {
            habilitar.SetActive(true);
        }
    }

    public override void Position()
    {
        throw new System.NotImplementedException();
    }
}

