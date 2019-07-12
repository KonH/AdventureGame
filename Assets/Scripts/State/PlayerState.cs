using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdventureGame.State {
	public class PlayerState {
		[XmlAttribute]
		public string Location = string.Empty;
		public List<ItemState> Items = new List<ItemState>();
	}
}