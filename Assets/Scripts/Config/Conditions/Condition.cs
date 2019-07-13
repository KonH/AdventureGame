using AdventureGame.State;

namespace AdventureGame.Config.Conditions {
	public abstract class Condition {
		public abstract bool IsSatisfied(GameState state);
	}
}