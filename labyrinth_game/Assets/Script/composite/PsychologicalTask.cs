using UnityEngine;

public class PsychologicalTask : PsychologicalTaskComponent  
{
    [SerializeField] private Life task1;
    [SerializeField] private Map task2;
    public PsychologicalTask(){
	}

    /**
	Se generan los métodos operacionales de las clases
	*/

    private void Start()
    {
        task1.life();
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
        }
        
        if (collision.gameObject.tag == "dano")
        {
            Destroy(task1.MyCanvas.transform.GetChild(task1.CantCorazon + 1).gameObject);
            task1.CantCorazon -= 1;
        }
    }

}
