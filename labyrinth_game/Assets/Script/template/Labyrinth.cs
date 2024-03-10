using UnityEngine.SceneManagement;
using UnityEngine;

public class Labyrinth : ActivityComplementary {

	private  int  row;

	private  int  column;

	/**
	Se generan los métodos getters and setters
	*/

	private int getRow() {
		return this.row;
	}

	private int getColumn() {
		return this.column;
	}

	public void setRow(int row) {
		this.row=row;
	}

	public void setColumn(int column) {
		this.column=column;
	}

	/**
	Se generan los métodos operacionales de las clases
	*/

	public void paint() 
	{
	}
	/** 
	Realizando Override de metodos que extienden de ActivityComplementary 
	*/
    public override void starGame()
    {
        UnityEngine.Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public override void gameLoop()
    {
        UnityEngine.Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public override void endGame()
    {
        Application.Quit();
    }
}
