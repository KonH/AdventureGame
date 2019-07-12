using System.Xml.Serialization;

namespace AdventureGame.Config.Results {
	public class SpendResult : Result {
		[XmlAttribute]
		public string Item = string.Empty;
	}
}