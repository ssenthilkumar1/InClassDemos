<Query Kind="Expression">
  <Connection>
    <ID>30ea22e7-3114-43f6-8d15-f45453fc9fa5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//group by

from food in Items
group food by food.MenuCategory.Description

//this creates a key with a key value
//and the row collection for that key value

//Other functions - ANY ALL

//more than one field

from food in Items
group food by new {food.MenuCategory.Description,food.CurrentPrice}
