using System.Xml.Serialization;

namespace AdventureGame.State {
	public class ItemState {
		[XmlAttribute]
		public string Name = string.Empty;
	}
}