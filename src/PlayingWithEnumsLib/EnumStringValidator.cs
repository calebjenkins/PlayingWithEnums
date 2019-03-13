using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlayingWithEnumsLib
{
	public class EnumStringValidator : ValidationAttribute
	{
		private Type enumType;
		private bool ignoreCase;
		public EnumStringValidator(Type T, bool ignoreCase = true)
		{
			enumType = (T.IsEnum == true) ? T : throw new ArgumentException(nameof(T) + " must be an enum type");
			this.ignoreCase = ignoreCase;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var fieldValue = value as string;
			if (fieldValue.IsNullOrEmpty())
				return null;

			var fieldName = validationContext.MemberName;
			var valueList = enumType.ToList();

			if (ignoreCase)
			{
				fieldValue = fieldValue.ToUpper();
				valueList.ToUpper();
			}

			var errMessage = (valueList.Contains(fieldValue)) ? string.Empty : $"{fieldName} must be set to one of these values: {valueList.ToDelimitedList(", ")}";
			return (errMessage.IsNotNullOrEmpty()) ? new ValidationResult(errMessage) : null;

			//return base.IsValid(value, validationContext);

		}

		protected Func<string, Type, DescriptionAttribute, bool> isValid = (v, T, D) =>
		 {
			 //var result = v.Parse<typeof(T)>(true);
			 // return result.HasValue;
			 return false;
		 };
	}
}
