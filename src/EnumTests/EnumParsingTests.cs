using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingWithEnumsLib;
using System;
using SCM = System.ComponentModel;

namespace EnumTests
{
	[TestClass]
	public class EnumParsingTests
	{
		[TestMethod]
		public void EnumParse_Should_Parse_ToString_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = Enum.Parse<OptionsWithDescriptions>("Large");

			Assert.AreEqual(option, newOption);

			Assert.IsTrue("SuperSized".Compare(option.Description<ValueForSystemX>()));
			Assert.IsTrue("MuyBig".Compare(option.Description<ValueForSystemY>()));
			Assert.IsTrue("Largish".Compare(option.Description()));
		}

		[TestMethod]
		public void EnumParse_Should_Fail_When_ToString_Value_Is_Wrong()
		{
			var option = OptionsWithDescriptions.Large;
			var match = Enum.TryParse<OptionsWithDescriptions>("blah", out var newOption);

			Assert.AreNotEqual(option, newOption);
		}

		[TestMethod]
		public void EnumParseSafe_Should_Parse_ToString_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "Large".Parse<OptionsWithDescriptions>();

			Assert.AreEqual(option, newOption);
			Assert.AreEqual(option, newOption.Value);
		}

		[TestMethod]
		public void EnumParseSafe_Should_Parse_To_Nullable()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "blah".Parse<OptionsWithDescriptions>();

			Assert.IsNull(newOption);
			Assert.IsFalse(newOption.HasValue);
			Assert.AreNotEqual(option, newOption);
		}

		[TestMethod]
		public void EnumParse_Should_Parse_ToCustomValue_Value()
		{
			var option = OptionsWithDescriptions.Large;
			var newOption = "Large".Parse<OptionsWithDescriptions>();
			var optionFromDescription = "Largish".Parse<OptionsWithDescriptions, SCM.DescriptionAttribute>();
			var optionFromX = "SuperSized".Parse<OptionsWithDescriptions, ValueForSystemX>();

			Assert.AreEqual(option, newOption);
			Assert.AreEqual(option, optionFromDescription);
			Assert.AreEqual(option, optionFromX);
		}
	}
}
