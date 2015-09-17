<Query Kind="Expression">
  <Connection>
    <ID>30ea22e7-3114-43f6-8d15-f45453fc9fa5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Where clause


//List all Tables that hold more than 3 people
//query syntax

from row in Tables
where row.Capacity > 3
select row

//method syntax
Tables.Where(row => row.Capacity > 3)

//List all items with more than 500 calories


//query Syntax
from row in Items
where row.Calories > 500
select row

//method syntax

Items.Where(row => row.Calories > 500)


//list all items with more than 500 calories and selling for more than $10

from row in Items
where row.Calories > 500  && row.CurrentPrice > 10.00m
select row


//list all items more than 500 calories 

from row in Items
where row.Calories > 500 && row.MenuCategory.Description.Equals("Entree")
select row


BillItems

MenuCategory