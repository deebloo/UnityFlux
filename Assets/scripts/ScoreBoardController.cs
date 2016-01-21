using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Stores;

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

	void setCountText (int score) {
		scoreBoard.text = "Score: " + score.ToString();

		if(score >= 5) {
			scoreBoard.text = "You Win!";
		}
	}
}
