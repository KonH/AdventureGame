using System.Xml.Serialization;
using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public class GoResult : Result {
		[XmlAttribute]
		public string To = string.Empty;

		public override void Apply(GameState state) {
			state.Player.Location = To;
		}
	}
}