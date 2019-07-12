using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdventureGame.State {
	public class LocationState {
		[XmlAttribute]
		public string           Name   = string.Empty;
		public List<EventState> Events = new List<EventState>();
	}
}