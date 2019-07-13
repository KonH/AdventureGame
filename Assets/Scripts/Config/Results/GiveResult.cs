using System.Xml.Serialization;
using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public class GiveResult : Result {
		[XmlAttribute]
		public string Item = string.Empty;

		public override void Apply(GameState state) {
			state.Player.Items.Add(new ItemState { Name = Item });
		}
	}
}