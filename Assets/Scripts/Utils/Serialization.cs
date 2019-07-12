using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AdventureGame.Utils {
	public static class Serialization {
		public static string Save<T>(T instance) where T : class {
			var serializer = new XmlSerializer(typeof(T));
			var settings = new XmlWriterSettings {
				Indent = true
			};
			using ( var sw = new StringWriter() ) {
				using ( var writer = XmlWriter.Create(sw, settings) ) {
					serializer.Serialize(writer, instance);
					return sw.ToString();
				}
			}
		}

		public static T Load<T>(string str) where T : class {
			var serializer = new XmlSerializer(typeof(T));
			using ( var reader = XmlReader.Create(new StringReader(str)) ) {
				var instance = serializer.Deserialize(reader) as T;
				return instance;
			}
		}
	}
}