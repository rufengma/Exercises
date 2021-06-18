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
*/





