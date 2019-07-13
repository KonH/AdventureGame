using System.Collections.Generic;
using System.Xml.Serialization;
using AdventureGame.Config.Conditions;
using AdventureGame.Config.Results;

namespace AdventureGame.Config {
	[XmlType("Action")]
	public class ActionConfig {
		[XmlAttribute]
		public string Name = string.Empty;

		public string Description       = string.Empty;
		public string HiddenDescription = string.Empty;
		public bool   Single            = true;

		[XmlArrayItem(typeof(HaveCondition), ElementName = "Have")]
		public List<Condition> Conditions = new List<Condition>();
		
		[XmlArrayItem(typeof(SpendResult), ElementName = "Spend")]
		[XmlArrayItem(typeof(GiveResult), ElementName = "Give")]
		[XmlArrayItem(typeof(TextResult), ElementName = "Text")]
		[XmlArrayItem(typeof(GoResult), ElementName = "Go")]
		[XmlArrayItem(typeof(GameOverResult), ElementName = "GameOver")]
		public List<Result> Results = new List<Result>();
		
		[XmlArrayItem(typeof(SpendResult), ElementName = "Spend")]
		[XmlArrayItem(typeof(GiveResult), ElementName = "Give")]
		[XmlArrayItem(typeof(TextResult), ElementName = "Text")]
		[XmlArrayItem(typeof(GoResult), ElementName = "Go")]
		[XmlArrayItem(typeof(GameOverResult), ElementName = "GameOver")]
		public List<Result> HiddenResults = new List<Result>();
	}
}