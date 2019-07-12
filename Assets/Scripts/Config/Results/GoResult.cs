using System.Xml.Serialization;

namespace AdventureGame.Config.Results {
	public class GoResult : Result {
		[XmlAttribute]
		public string To = string.Empty;
	}
}