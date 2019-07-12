using System.Xml.Serialization;

namespace AdventureGame.Config.Conditions {
	public class HaveCondition : Condition {
		[XmlAttribute]
		public string Item = string.Empty;
	}
}