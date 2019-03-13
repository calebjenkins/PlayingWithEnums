using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingWithEnumsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnumTests
{
	[TestClass]
	public class EnumExtensionTests
	{
		[TestMethod]
		public void ToList_Should_Return_A_List_of_Values()
		{
			var list = typeof(OptionsWithDescriptions).ToList();
			Assert.IsNotNull(list);
			var stringValue = list.ToDelimitedList(",");
		}

		[TestMethod]
		public void Non_Enum_Should_Throw_an_Exception()
		{
			Assert.ThrowsException<ArgumentException>(() => typeof(int).ToList());
			Assert.ThrowsException<ArgumentException>(() => typeof(string).ToList());
			Assert.ThrowsException<ArgumentException>(() => typeof(object).ToList());
		}

		[TestMethod]
		public void should_validate_property()
		{
			var sut = new ExampleClass() { Size = "blah" };
			Assert.IsFalse(ModelValidation.IsValid(sut));
		}

		[TestMethod]
		public void should_validate_found_property_to_true()
		{
			var sut = new ExampleClass() { Size = "Small" };
			Assert.IsTrue(ModelValidation.IsValid(sut));
		}

		[TestMethod]
		public void should_validate_property_even_if_case_is_off()
		{
			var sut = new ExampleClass() { Size = "sMall" };
			Assert.IsTrue(ModelValidation.IsValid(sut));
		}

	}

	public class ModelValidation
	{
		public static bool IsValid(object model)
		{
			var context = new ValidationContext(model, null, null);
			var results = new List<ValidationResult>();

			return Validator.TryValidateObject(model, context, results, true);
		}
	}

	public class ExampleClass
	{
	// [DataTypeAttribute(DataType.Custom)]
	[EnumStringValidator(typeof(OptionsWithDescriptions))] //, ErrorMessageResourceType = typeof(OptionsWithDescriptions))]
		public string Size { get; set; }
	}
}
