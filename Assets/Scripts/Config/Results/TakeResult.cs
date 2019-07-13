using System.Xml.Serialization;
using AdventureGame.State;

namespace AdventureGame.Config.Results {
	public class TakeResult : Result {
		[XmlAttribute]
		public string Item = string.Empty;

		public override void Apply(GameState state) {
			var items = state.Player.Items;
			var item  = items.Find(i => i.Name == Item);
			items.Remove(item);
		}
	}
}