using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public class GameOverResult : Result {
		public override void Apply(GameState state) {
			state.Player.IsEnd = true;
		}
	}
}