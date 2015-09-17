<Query Kind="Expression">
  <Connection>
    <ID>30ea22e7-3114-43f6-8d15-f45453fc9fa5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby


//default is ascending
from puzzle in Items
orderby puzzle.Description
select puzzle

//also available in descending

from puzzle in Items
orderby puzzle.CurrentPrice descending
select puzzle 

//both acending and desending
from puzzle in Items
orderby puzzle.CurrentPrice descending,puzzle.Calories ascending
select puzzle

//can use where and order by together

from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
where food.MenuCategory.Description.Equals("Entree")
select food