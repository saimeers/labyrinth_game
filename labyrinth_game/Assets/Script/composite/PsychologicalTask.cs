using UnityEngine;

public class PsychologicalTask : PsychologicalTaskComponent  
{
    [SerializeField] private Life task1;
    [SerializeField] private Map task2;
     private AudioSource audioSourd;
    [SerializeField] private AudioClip hit;


    private void Start()
    {
        task1.life();
        audioSourd = GetComponent<AudioSource>();
    }
    private void Update()
    {
        doAnything();
    }
    public override void doAnything()
    {
        task1.dead();
        task2.controllerMap();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            task2.end();
            audioSourd.Play();
        }
        
        if (collision.gameObject.tag == "dano")
        {
            audioSourd.PlayOneShot(hit);
            MovimientoCamara.Intance.MoverCamara(4, 2, 1f);
            Destroy(task1.MyCanvas.transform.GetChild(task1.CantCorazon + 1).gameObject);
            task1.CantCorazon -= 1;
        }
    }

}
