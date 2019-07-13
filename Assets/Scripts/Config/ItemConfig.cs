using System.Xml.Serialization;
using System.Collections.Generic;

namespace AdventureGame.Config {
	[XmlType("Item")]
	public class ItemConfig {
		[XmlAttribute]
		public string             Name    = string.Empty;
		public List<ActionConfig> Actions = new List<ActionConfig>();
	}
}