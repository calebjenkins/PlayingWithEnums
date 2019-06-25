namespace PlayingWithMappingTests.Models
{
	public class ValuationRequest
	{
		public VehicleMake CarMake { get; set; }
	}

	public enum VehicleMake
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
