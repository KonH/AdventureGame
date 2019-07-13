using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public class TextResult : Result {
		public string Value = string.Empty;
		
		public override void Apply(GameState state) {
			state.Player.ActionTexts.Add(Value);
		}
	}
}