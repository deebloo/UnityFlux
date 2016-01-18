public static class Actions {
	public delegate int ScoreUpdateAction();
	public static event ScoreUpdateAction OnScoreUpdateAction;
		
	// Update the score
	public static void UpdateScore() {
		if(OnScoreUpdateAction != null) {
			OnScoreUpdateAction ();
		}
	}
}
