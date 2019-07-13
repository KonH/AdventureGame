using System.Xml.Serialization;
using System.Collections.Generic;

namespace AdventureGame.Config {
	[XmlType("Config")]
	public class ConfigRoot {
		public SettingsConfig       Settings  = new SettingsConfig();
		public List<ItemConfig>     Items     = new List<ItemConfig>();
		public List<LocationConfig> Locations = new List<LocationConfig>();
	}
}