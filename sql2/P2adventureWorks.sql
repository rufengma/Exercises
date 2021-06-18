
/*The AdventureWorks database*/
/*q1 as we showed, here are total 504 products.*/
select count(p.productId)
from Production.Product p;

/*q2 group by subcagtegoryID*/
select count(p.productId), p.ProductSubcategoryID
from Production.Product p
group by p.ProductSubcategoryID
having p.ProductSubcategoryID is not null;

/*q3 group by, showed as another name*/
select p.ProductSubcategoryID, count(p.ProductID) as "CountedProducts"
from Production.Product p
group by p.ProductSubcategoryID;

/*q4*/
select count(ProductID)
from Production.Product p
where p.ProductSubcategoryID is null;


/*q5*/
select sum(p.Quantity)
from Production.ProductInventory p;

/*Q6*/
select p.ProductID, sum(p.Quantity) as "TheSum"
from Production.ProductInventory p
group by p.ProductID,p.LocationID
having p.LocationID=40 and sum(p.Quantity)<100;

/*Q7*/
select p.Shelf,p.ProductID, sum(p.Quantity) as "TheSum"
from Production.ProductInventory p
group by p.ProductID,p.Shelf,p.LocationID
having p.LocationID=40 and sum(p.Quantity)<100;

/*Q8*/
select avg(p.Quantity),p.ProductID
from Production.ProductInventory p
group by p.ProductID,p.LocationID
having p.LocationID=10;

/*Q9*/
select p.ProductID, p.Shelf, avg(p.Quantity) as "TheAvg"
from Production.ProductInventory p
group by p.ProductID,p.Shelf;

/*Q10*/
select p.ProductID, p.Shelf, avg(p.Quantity) as "TheAvg"
from Production.ProductInventory p
group by p.Shelf,p.ProductID
having p.Shelf!='N/A';

/*Q11*/
SELECT p.Color,p.Class, count(p.ListPrice),avg(p.ListPrice)
from Production.Product p
group by p.Color,p.Class
having p.Color!='NULL' and p.Class!='null';

/*Q12 Joins*/
select c.Name as "Country", p.Name as "Province"
from person.CountryRegion c
left join person.StateProvince p 
on p.CountryRegionCode=c.CountryRegionCode
where p.Name!='null';

/*Q13 Joins*/
select c.Name as "Country", p.Name as "Province"
from person.CountryRegion c
left join person.StateProvince p 
on p.CountryRegionCode=c.CountryRegionCode
where p.Name!='null' and c.Name in ('Germany', 'Canada');

