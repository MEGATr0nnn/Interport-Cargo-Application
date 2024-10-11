using System;
namespace IAB251_Assignment_2_Project_Final.Models
{
	public class QuotationRequestModel
	{

		private int requestID;

		private string customerInformation;

		private string source;

		private string destination;

		private int numContainers;

		private string importDetails;

		private string exportDetails;

		private bool packing;

		private string quarantineRequirements;



		public QuotationRequestModel()
		{
		}



		public string JobNature()
		{
			return "";
		}
	}
}

