using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PlayingWithEnumsLib
{
	[DataContract]
	public enum Options
	{
		Unknown,
		Medium,
		Small,
		[EnumMember(Value = "Largish"), Description("Super Large")]
		Large
	}

	public enum Options2
	{
		Large,
		Small,
		Medium,
		Unknown
	}

	public class MessageWithOptionsEnum
	{
		public Options Options { get; set; }
	}

	public class MessageWithOptions2Enum
	{
		public Options2 Options { get; set; }
	}
	public class MessageWithOptions1EnumWithAttribute
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public Options Options { get; set; }
	}

	public class MessageWithStringOptions
	{
		public string Options { get; set; }
	}

	public class MessageWithEnumBacking
	{

		//[NonSerialized]
		[JsonIgnore]
		public Options Options
		{
			get
			{
				var retOption = Options.Unknown;
				return (Enum.TryParse<Options>(_options, out retOption)) ? retOption : Options.Unknown;
			}
			set { _options = value.ToString(); }
		}

		[JsonProperty("Options")]
		public string _options { get; set; }
	}
}
