using System.Xml.Serialization;

namespace AdventureGame.Config.Results {
	public class GiveResult : Result {
		[XmlAttribute]
		public string Item = string.Empty;
	}
}