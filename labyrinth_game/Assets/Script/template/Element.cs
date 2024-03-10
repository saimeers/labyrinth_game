using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{

	[SerializeField] private  bool state;
    [SerializeField] private  int  position;
	
	private bool getState() {
		return this.state;
	}

	private int getPosition() {
		return this.position;
	}


	public void setState(bool state) {
		this.state=state;
	}

	public void setPosition(int position) {
		this.position=position;
	}

	public abstract void collide(List<Element> elements);
	public abstract void addAction(List<Mechanic> mechanics);

}
