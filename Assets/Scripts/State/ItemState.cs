using System;
using System.Xml.Serialization;

namespace AdventureGame.State {
	[Serializable]
	public class ItemState {
		[XmlAttribute]
		public string Name = string.Empty;
	}
}