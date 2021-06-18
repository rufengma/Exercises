/*Q14 . List all Products that has been sold at least once in last 25 years.*

select p.ProductID, o.OrderID,o2.OrderDate
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
where o2.OrderDate between '1995-06-18' and '2021-06-18'

*q15,List top 5 locations (Zip Code) where the products sold most.*

select top 5 o2.ShipPostalCode, sum(o.Quantity) as "total"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
group by  o2.ShipPostalCode
having o2.ShipPostalCode!='null'
order by sum(o.Quantity) desc

*q16*

select top 5 o2.ShipPostalCode, sum(o.Quantity) as "total"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
where o2.OrderDate between '1995-06-18' and '2021-06-18'
group by  o2.ShipPostalCode
having o2.ShipPostalCode!='null'
order by sum(o.Quantity) desc

*q17*
select top 5 o2.ShipPostalCode,o2.ShipCity,count(o2.CustomerID) as "total Customer",sum(o.Quantity) as "total"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
group by  o2.ShipPostalCode,o2.ShipCity
having o2.ShipPostalCode!='null'
order by sum(o.Quantity) desc

*q18*

select o2.ShipPostalCode,o2.ShipCity,count(o2.CustomerID) as "total Customer",sum(o.Quantity) as "total"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
group by  o2.ShipPostalCode,o2.ShipCity
having o2.ShipPostalCode!='null' and count(o2.CustomerID)>10
order by sum(o.Quantity) desc


*q19*
select o2.ShipName, o2.OrderDate
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
where o2.OrderDate between '1998-01-01' and '2021-06-18'

*q20*
select o2.ShipName, o2.OrderDate
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
order by o2.OrderDate DESC

*q21*
select o2.CustomerID, sum(o.Quantity) as "Bought Products"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
group by o2.CustomerID

*q22*
select o2.CustomerID, sum(o.Quantity) as "Bought Products"
from Products p
left join [Order Details] o
on o.ProductID=p.ProductID
left join Orders o2
on o2.OrderID=o.OrderID
group by o2.CustomerID
having sum(o.Quantity)>100

*q23*
select s1.CompanyName as "Supplier Company Name",s2.CompanyName as "Shipper company name"
from Orders o 
left join Shippers s2
on o.ShipVia= s2.ShipperID
left join Suppliers s1
on s1.City=o.ShipCity
where s1.CompanyName!='null'

*q24*/

