using System;
using System.Xml.Serialization;

namespace AdventureGame.State {
	[Serializable]
	public class EventState {
		[XmlAttribute]
		public string Name = string.Empty;
	}
}