public class Emotion {

	private  StateStrategy  state;

	public Emotion(){
	}

	public Emotion( StateStrategy  state ) {
		this.state=state;
	}

	/**
	Se generan los métodos getters and setters
	*/

	private StateStrategy getState() {
		return this.state;
	}

	public void setState(StateStrategy state) {
		this.state=state;
	}

	/**
	Se generan los métodos operacionales de las clases
	*/

	public void setStateStrategy() {


	}


}
