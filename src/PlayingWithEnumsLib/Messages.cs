using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PlayingWithEnumsLib
{
	public enum Options
	{
		Unknown,
		Medium,
		Small,
		Large
	}

	public enum Options2
	{
		Large,
		Small,
		Medium,
		Unknown
	}

	[DataContract]
	public enum OptionWithEnumMember
	{
		[EnumMember(Value = "Large")]
		Largish,
		[EnumMember(Value = "Medium")]
		Avg,
		[EnumMember(Value = "Small")]
		ReallyLittle
	}

	public enum OptionsWithDescriptions
	{
		[Description("Smallish")]
		Small,

		[Description("Largish")]
		[ValueForSystemX("SuperSized")]
		[ValueForSystemY("MuyBig")]
		Large,

		[Description("No Idea")]
		Unknown,

		[Description("Avg I guess")]
		Medium
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

		[JsonIgnore] //[NonSerialized]
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

	public class MessageWithEnumMemberOptions
	{
		public OptionWithEnumMember Options { get; set; }
	}

	public class MessageOptionsWithDescriptions
	{
		public OptionsWithDescriptions Options { get; set; }
	}

	public class MessageOptionsCustomAttributes
	{
		public MessageOptionsCustomAttributes Options { get; set; }
	}

	public class ValueForSystemX : DescriptionAttribute
	{
		public ValueForSystemX(string description) : base(description)
		{
		}
	}

	public class ValueForSystemY : DescriptionAttribute
	{
		public ValueForSystemY(string description) : base(description)
		{
		}
	}
}
