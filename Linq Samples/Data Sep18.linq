<Query Kind="Program">
  <Connection>
    <ID>30ea22e7-3114-43f6-8d15-f45453fc9fa5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	//anonymous data type queries
	
	/*from food in Items
	where food.MenuCategory.Description.Equals("Entree")
	&& food.Active
	orderby food.CurrentPrice descending
	select new
	 {
	   Description = food.Description,
	   Price = food.CurrentPrice,
	   Cost = food.CurrentCost,
	   Profit = food.CurrentPrice - food.CurrentCost
	   
	 }*/
	 
	var results = from food in Items
			where food.MenuCategory.Description.Equals("Entree")
				&& food.Active
			orderby food.CurrentPrice descending
			select new FoodMargins()
			 {
	 		  Description = food.Description,
	 		  Price = food.CurrentPrice,
	 		  Cost = food.CurrentCost,
	 		  Profit = food.CurrentPrice - food.CurrentCost
	   
	 };
	 results.Dump();
	 
	 //get all the Bills and BillItems for the waiters 
	 //in September 2014 get only those Bills which are paid
	 
	 var results2 = from orders in Bills
	 				where orders.PaidStatus && (orders.BillDate.Month == 9 && orders.BillDate.Year == 2014)
	 				orderby orders.Waiter.LastName, orders.Waiter.LastName
	 				select new
					{
						BillID = orders.BillID,
						WaiterName = orders.Waiter.LastName + ", " + orders.Waiter.FirstName,
						Orders = orders.BillItems
					};
    results2.Dump();					
}//eop

// Define other methods and classes here
//This is a POCO Class
public class FoodMargins
{
	public string Description{get;set;}
	public decimal Price {get;set;}
	public decimal Cost {get;set;}
	public decimal Profit {get;set;}

}


//this is DTO

public class BillOrders
{
	public int BillId{get;set;}
	public string WaiterName{get;set;}
	public BillItems Orders {get;set;}
}
