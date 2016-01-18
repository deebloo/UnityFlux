public static class ScoreStore {
	static int score;

	public delegate void ScoreUpdated(int score);
	public static event ScoreUpdated OnScoreUpdated;

	static ScoreStore () {
		score = 0;

		Actions.OnScoreUpdateAction += updateScore;
	}

	// increment the score by one and fire the OnScoreUpdated event.
	private static int updateScore() {
		score++;

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
