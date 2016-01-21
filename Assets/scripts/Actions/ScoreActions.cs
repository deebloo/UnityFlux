namespace Actions {
	public static class ScoreActions {
		public delegate int ScoreUpdateAction();
		public static event ScoreUpdateAction OnScoreUpdateAction;

		// Update the score
		public static void Update() {
			if(OnScoreUpdateAction != null) {
				OnScoreUpdateAction ();
			}
		}
	}
}