<Query Kind="Statements">
  <Connection>
    <ID>30ea22e7-3114-43f6-8d15-f45453fc9fa5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Simplest form for dumping a table

Waiters


//Simple query syn tax

from person in Waiters
select person


//simple method syntax

Waiters.Select(person => person)

//inside our project we will be writing C# statement

var results = from person in Waiters 
select person;

//to display the contents of a variable in Linqpad
//use the .Dump() Method

results.Dump();

//sample to show how changes to be done to the project in the VS side


//Implemented inside a VS project's class library BLL method
//[DataObjectMethod(DataObjectMethodType.Select,false)]
//public List<Waiters> SomeMethodName()
{
//you will need to connect to your DAL object
//this will be done using a new xxxxx() constructor
//Assume your connection variable is called contextvariable

//do your query
//var results = from person in contextvariable.Waiters 
//select person;

//return your results
//Dump() is specific to LINQ and should be 
//replaced with the below statement

//return results.ToList();
}