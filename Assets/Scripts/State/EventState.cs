using System.Xml.Serialization;

namespace AdventureGame.State {
	public class EventState {
		[XmlAttribute]
		public string Name = string.Empty;
	}
}