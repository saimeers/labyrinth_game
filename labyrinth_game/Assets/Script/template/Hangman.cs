public class Hangman : ActivityComplementary {

	private  string  secretWord;

	private  int  maxAttempt;

	private  char  guessedLetter;

	private  int  remainingAttempts;

	/*
	Se generan los métodos getters and setters
	*/

	private string getSecretWord() {
		return this.secretWord;
	}

	private int getMaxAttempt() {
		return this.maxAttempt;
	}

	private char getGuessedLetter() {
		return this.guessedLetter;
	}

	private int getRemainingAttempts() {
		return this.remainingAttempts;
	}

	public void setSecretWord(string secretWord) {
		this.secretWord=secretWord;
	}

	public void setMaxAttempt(int maxAttempt) {
		this.maxAttempt=maxAttempt;
	}

	public void setGuessedLetter(char guessedLetter) {
		this.guessedLetter=guessedLetter;
	}

	public void setRemainingAttempts(int remainingAttempts) {
		this.remainingAttempts=remainingAttempts;
	}
    /** 
	Realizando Override de metodos que extienden de ActivityComplementary 
	*/
    public override void starGame()
    {
        throw new System.NotImplementedException();
    }

    public override void gameLoop()
    {
        throw new System.NotImplementedException();
    }

    public override void endGame()
    {
        throw new System.NotImplementedException();
    }
}
