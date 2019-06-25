namespace PlayingWithMappingTests.Models.Insurance
{
	public class InsuranceProcessorRequest
	{
		public Manufacturer CarManufacturer { get; set; }
	}

	public enum Manufacturer
	{
		Chevrolet,
		Honda,
		Toyota,
		Acura,
		Saturn,
		Volvo,
		Tesla
	}
}
