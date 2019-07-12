using System.Xml.Serialization;

namespace AdventureGame.Config {
	[XmlType("Settings")]
	public class SettingsConfig {
		[XmlAttribute]
		public string StartLocation = string.Empty;
	}
}