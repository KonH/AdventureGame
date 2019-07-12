using System.Collections.Generic;
using System.Xml.Serialization;
using AdventureGame.Config.Conditions;

namespace AdventureGame.Config {
	[XmlType("Config")]
	public class ConfigRoot {
		public SettingsConfig       Settings  = new SettingsConfig();
		public List<ItemConfig>     Items     = new List<ItemConfig>();
		public List<LocationConfig> Locations = new List<LocationConfig>();
	}
}