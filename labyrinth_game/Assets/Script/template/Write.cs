using TMPro;
using UnityEngine;

public class Write : Mechanic
{

    [SerializeField] private GameObject user;
    [SerializeField] private GameObject edad;
    [SerializeField] private GameObject nombres;
    [SerializeField] private GameObject descripcion1;
    [SerializeField] private GameObject countMap;
    [SerializeField] private GameObject countMiniMap;
    [SerializeField] private GameObject Point;

    private void Start()
    {
        Behaviour();
    }
    public override void Behaviour()
    {
      
        user.GetComponent<TMP_Text>().text = Login.singleton.usuario.user;
        edad.GetComponent<TMP_Text>().text = Login.singleton.usuario.edad.ToString();
        nombres.GetComponent<TMP_Text>().text = Login.singleton.usuario.nombre +" "+ Login.singleton.usuario.apellido;
        descripcion1.GetComponent<TMP_Text>().text = Login.singleton.stats.descripcion;
        countMiniMap.GetComponent<TMP_Text>().text = Login.singleton.stats.penalizacion.ToString();
        Point.GetComponent<TMP_Text>().text = Login.singleton.stats.puntaje.ToString();
        countMap.GetComponent<TMP_Text>().text = Login.singleton.stats.evasion.ToString();
    }

    public override void Position()
    {

    }
}
