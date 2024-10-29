using System;
namespace IAB251_Assignment_2_Project_Final.Models
{
	public class CustomerModel
	{

		public List<Customer> customers = new List<Customer>();


		public void addCustomer(Customer customer)
		{
			customers.Add(customer);
		}



		public void displayAllCustomersNames()
		{
			foreach(var cus in customers)
			{
				Console.WriteLine("Customer Name: " + cus.getFirstName + " " + cus.getLastName);
			}
		}

		public string displayCurrentCustomerName()
		{
			for (int i = 0; i < customers.Count; i++)
			{
				if (i == customers.Count - 1)
				{
					return customers[i].first_Name;
				}
			}

			return "Customer Not Found";
		}



		public CustomerModel()
		{
		}
	}
}

