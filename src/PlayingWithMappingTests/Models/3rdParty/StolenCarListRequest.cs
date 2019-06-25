namespace PlayingWithMappingTests
{
	namespace models.FederalPolice
	{
		public class StolenCarListRequest
		{
			public VehicleMake Make { get; set; }
		}

		public enum VehicleMake
		{
			Chevry,
			Honda,
			Toyota,
			Acura,
			Saturn,
			Volvo,
			Tesla
		}
	}

}

