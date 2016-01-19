# UnityFlux

Use flux pattern with Unity from the RollABall tutorial level.

### Actions
```C#
public static class Actions {
  // Create Score updated delegate and event
	public delegate int ScoreUpdateAction();
	public static event ScoreUpdateAction OnScoreUpdateAction;
		
	// Update the score
	public static void UpdateScore() {
		if(OnScoreUpdateAction != null) {
		  // Fire the OnScoreUpdateAction event
			OnScoreUpdateAction ();
		}
	}
}

```

### Store
```C#
public static class ScoreStore {
	// private model
	private static int score;
	
	// This stores delegate and event
	public delegate void ScoreUpdated(int score);
	public static event ScoreUpdated OnScoreUpdated;
	
	// Set default score to 0 and add method to OnScoreUpDateAction event
	static ScoreStore () {
		score = 0;

		Actions.OnScoreUpdateAction += updateScore;
	}

	// increment the score by one and fire the OnScoreUpdated event.
	private static int updateScore() {
		score++;
		
		// Fire the OnScoreUpdated event
		if(OnScoreUpdated != null) {
			OnScoreUpdated (score);
		}

		return score;
	}

	// returns the score value;
	public static int getScore() {
		return score;
	}
}
```

### PlayerController
```C#
...
public class PlayerController : MonoBehaviour {
  ...
	
	// update the score and desactivate collectables
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive (false);
			
			Actions.UpdateScore();
		}
	}
}
```

### ScoreBoardController
```C#
...
public class ScoreBoardController : MonoBehaviour {
	private Text scoreBoard;

	// Use this for initialization
	void Start () {
		scoreBoard = GetComponent<Text> ();
		setCountText (ScoreStore.getScore());
	}

	void OnEnable () {
		ScoreStore.OnScoreUpdated += setCountText;
	}

	void OnDisable () {
		ScoreStore.OnScoreUpdated -= setCountText;
	}

  // Update text when score is updated
	void setCountText (int score) {
		scoreBoard.text = "Score: " + score.ToString();

		if(score >= 5) {
			scoreBoard.text = "You Win!";
		}
	}
}
```
