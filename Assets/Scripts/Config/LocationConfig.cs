using System.Xml.Serialization;
using System.Collections.Generic;

namespace AdventureGame.Config {
	[XmlType("Location")]
	public class LocationConfig {
		[XmlAttribute]
		public string             Name        = string.Empty;
		public string             Description = string.Empty;
		public List<ActionConfig> Actions     = new List<ActionConfig>();
	}
}