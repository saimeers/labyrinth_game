using UnityEngine;

public class Match : Mechanic
{
    [SerializeField] private GameObject habilitar;
    private void Update()
    {
        Behaviour();
    }
    public override void Behaviour()
    {

        if (Login.singleton.stats.puntaje >= 150 && Login.singleton.stats.evasion >= 3)
        {
            habilitar.SetActive(false);
        }
        else if (Login.singleton.stats.puntaje < 150 && Login.singleton.stats.evasion >= 3)
        {
            habilitar.SetActive(true);
        }
        else if (Login.singleton.stats.puntaje >= 150 && Login.singleton.stats.evasion < 3)
        {
            habilitar.SetActive(true);
        }
    }

    public override void Position()
    {
        throw new System.NotImplementedException();
    }
}

