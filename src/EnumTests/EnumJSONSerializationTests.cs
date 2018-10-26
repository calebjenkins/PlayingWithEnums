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

		[TestMethod] 
		public void SerializingWithStraightEnumsUsingJasonAttributes()
		{
			var StartMsg = new MessageWithOptions1EnumWithAttribute () { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithOptions1EnumWithAttribute>(msgJson);

			Assert.AreEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
		}


	}
}
