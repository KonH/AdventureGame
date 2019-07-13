using System.Xml.Serialization;
using AdventureGame.State;

namespace AdventureGame.Config.Conditions {
	public class HaveCondition : Condition {
		[XmlAttribute]
		public string Item = string.Empty;

		public override bool IsSatisfied(GameState state) {
			return state.Player.Items.Find(i => i.Name == Item) != null;
		}
	}
}