using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CS_IA_Ibasic_Intouch_Re
{
    public class XMLdata
    {
		/// <summary>
		/// Class for command words retrieved from XML file
		/// </summary>
		[XmlRoot(ElementName = "CommandWords")]
		public class CommandWords
		{
			[XmlElement(ElementName = "item")]
			public List<string> Item { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}
		/// <summary>
		/// Class for syntax from XML file
		/// </summary>
		[XmlRoot(ElementName = "Syntax")]
		public class Syntax
		{
			[XmlElement(ElementName = "CommandWords")]
			public CommandWords CommandWords { get; set; }
			[XmlElement(ElementName = "isLocal")]
			public string IsLocal { get; set; }
		}


	}
}
