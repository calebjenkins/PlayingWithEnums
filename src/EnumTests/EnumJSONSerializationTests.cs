using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft;
using Newtonsoft.Json;
using PlayingWithEnumsLib;
using System.Diagnostics;

namespace EnumTests
{
	[TestClass]
	public class EnumJSONSerializationTests
	{
		[TestMethod] // Passes Will FALSE (Fails)
		public void SerializingWithStraightEnums()
	{
			//var converter = new Jason
			var StartMsg = new MessageWithOptionsEnum() { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithOptions2Enum>(msgJson);

			Assert.AreNotEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
		}

		[TestMethod] // It's a lot of work to get the object to serialize the enum as a string. 
		public void SerializingWithEnumsBacking()
		{
			var StartMsg = new MessageWithEnumBacking () { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithOptions2Enum>(msgJson);

			Assert.AreEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
		}

		[TestMethod] // This is much better. Using a Newtonsoft attribute on the enum, forces the ToString on the enum instead of the index
		public void SerializingWithStraightEnumsUsingJasonAttributes()
		{
			var StartMsg = new MessageWithOptions1EnumWithAttribute () { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithStringOptions>(msgJson);

			Assert.AreEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
		}

		[TestMethod]
		public void SerializingWithEnumMemberAttribute_DoesntWork_Enum_Serializes_Index_Instead_of_String()
		{
			var StartMsg = new MessageWithEnumMemberOptions() { Options = OptionWithEnumMember.Largish };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithStringOptions>(msgJson);

			Assert.AreNotEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
			Assert.AreEqual<string>("0", EndMsg.Options.ToString());
		}
	}
}
