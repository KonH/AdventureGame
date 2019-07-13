using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdventureGame.State {
	[Serializable]
	public class PlayerState {
		[XmlAttribute]
		public string          Location    = string.Empty;
		public List<ItemState> Items       = new List<ItemState>();
		public bool            IsEnd       = false;
		public List<string>    ActionTexts = new List<string>();
	}
}