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
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.Description(), "Largish"));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension()
		{
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.ToValueOrString<System.ComponentModel.DescriptionAttribute>(), "Largish"));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_With_Custom_Descriptor()
		{
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.ToValueOrString<ValueForSystemX>(), "SuperSized"));
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.ToValueOrString<ValueForSystemY>(), "MuyBig"));
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.Description(), "Largish"));
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Large.ToString(), "Large"));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_With_CustomDescriptions_checking_vars()
		{
			var option = OptionsWithDescriptions.Large;
			Assert.IsTrue(StringCompare(option.ToValueOrString<ValueForSystemX>(), "SuperSized"));
			Assert.IsTrue(StringCompare(option.ToValueOrString<ValueForSystemY>(), "MuyBig"));
			Assert.IsTrue(StringCompare(option.Description(), "Largish"));
		}

		[TestMethod]
		public void ValidateToValueOrStringExtension_Uses_ToString_When_Descriptor_Is_Missing()
		{
			Assert.IsTrue(StringCompare(OptionsWithDescriptions.Medium.ToValueOrString<ValueForSystemX>(), "Medium"));
		}

		private bool StringCompare(string string1, string string2)
		{
			var returnValue = false;
			if (string1.IsNotNullOrEmpty())
			{
				returnValue = string1.Equals(string2, StringComparison.CurrentCultureIgnoreCase);
			}
			return returnValue;
		}
	}


}
