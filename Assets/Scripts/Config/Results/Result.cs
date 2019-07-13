using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public abstract class Result {
		public abstract void Apply(GameState state);
	}
}