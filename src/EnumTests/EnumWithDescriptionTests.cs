using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PlayingWithEnumsLib;
using System;

namespace EnumTests
{
	[TestClass]
	public class EnumWithDescriptionTests
	{
		[TestMethod]
		public void ShouldUseDescription()
		{
			var StartMsg = new MessageOptionsWithDescriptions() { Options = OptionsWithDescriptions.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageOptionsWithDescriptions>(msgJson);

			Assert.AreEqual<string>(OptionsWithDescriptions.Large.ToString(), EndMsg.Options.ToString());
		}

		[TestMethod]
		public void ShouldUseDescriptionOrString()
		{
			var StartMsg = new MessageOptionsWithDescriptions() { Options = OptionsWithDescriptions.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageOptionsWithDescriptions>(msgJson);

			Assert.AreEqual<string>(StartMsg.Options.ToString(), EndMsg.Options.ToString());
		}

		[TestMethod]
		public void ValidateToDescriptionExtension()
		{
			Assert.IsTrue("Largish".Compare(OptionsWithDescriptions.Large.Description()));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension()
		{
			Assert.IsTrue("Largish".Compare(OptionsWithDescriptions.Large.Description<System.ComponentModel.DescriptionAttribute>()));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_With_Custom_Descriptor()
		{
			Assert.IsTrue("SuperSized".Compare(OptionsWithDescriptions.Large.Description<ValueForSystemX>()));
			Assert.IsTrue("MuyBig".Compare(OptionsWithDescriptions.Large.Description<ValueForSystemY>()));
			Assert.IsTrue("Largish".Compare(OptionsWithDescriptions.Large.Description()));
			Assert.IsTrue("Large".Compare(OptionsWithDescriptions.Large.ToString()));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_With_CustomDescriptions_checking_vars()
		{
			var option = OptionsWithDescriptions.Large;
			Assert.IsTrue("SuperSized".Compare(option.Description<ValueForSystemX>()));
			Assert.IsTrue("MuyBig".Compare(option.Description<ValueForSystemY>()));
			Assert.IsTrue("Largish".Compare(option.Description()));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_Uses_ToString_When_Descriptor_Is_Missing()
		{
			Assert.IsTrue("Medium".Compare(OptionsWithDescriptions.Medium.Description<ValueForSystemX>()));
		}
	}
}
