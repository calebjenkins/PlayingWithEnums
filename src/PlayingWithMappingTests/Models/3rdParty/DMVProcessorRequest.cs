namespace PlayingWithMappingTests
{

	namespace models.DMV
	{
		public class DMVProcessorRequest
		{
			public Manufacturer Make { get; set; }
		}

		public enum Manufacturer
		{
			Chevy,
			Honda,
			Toyota,
			Acura,
			Saturn,
			Volvo,
			Tesla
		}
	}
}

