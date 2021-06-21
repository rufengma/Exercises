--1.	List all cities that have both Employees and Customers.
select distinct e.city
from Employees e 
where e.city in (select c.City from Customers c)
union
select distinct c.city
from Customers c
where c.city in (select e.City from Employees e);
--2.	List all cities that have Customers but no Employee.
--a.	Use sub-query
select distinct c.city
from Customers c
where c.city not in (select e.City from Employees e);
--b.	Do not use sub-query
select distinct c.city
from Customers c 
left join Employees e
on c.city=e.City
where e.City is null;

--3.List all products and their total order quantities throughout all orders.
select p.ProductID,sum(o.Quantity) as "total quantities"
from products p
left join [Order Details] o
on p.ProductID=o.ProductID
group by p.ProductID
order by p.ProductID;

--4.	List all Customer Cities and total products ordered by that city.

select c.City,sum(o2.Quantity) as "total products sold"
from Customers c 
inner join Orders o 
on o.CustomerID=c.CustomerID
inner join [Order Details] o2 
on o2.OrderID=o.OrderID
group by c.City
order by c.City;

-- 5.	List all Customer Cities that have at least two customers.
--a.	Use union
select c.City, count(c.CustomerID) as "NumOfCustomers"
from Customers c
group by c.City
having  count(c.CustomerID) > 1
union
select s.City, count(s.SupplierId) 
from Suppliers s
group by s.City;
--b.	Use sub-query and no union
select dt.City, dt.NumOfCustomers
from	
(select c.City, count(c.CustomerID) as "NumOfCustomers"
from Customers c
group by c.city) dt full join Suppliers s
on dt.City = s.City
where dt.NumOfCustomers > 1;
		
--6.	List all Customer Cities that have ordered at least two different kinds of products.
with CTE
as
(
    select c.ContactName, count(p.ProductID) as "Total"
    from Orders o inner join Customers c
    on o.CustomerID = c.CustomerID
    inner join [Order Details] od
    on o.OrderID = od.OrderID
    inner join Products p
    on p.ProductID = od.ProductID
    group by c.ContactName
    having count(p.ProductID) > 1
), CTE2
as
(
    select distinct c.City
    from CTE cte inner join Customers c
    on cte.ContactName = c.ContactName
)
select * from CTE2
order by CTE2.City;
		
		
--7.	List all Customers who have ordered products, but have the ¡®ship city¡¯ on the order different from their own customer cities.
select s.ContactName, s.City as "ShipCity", dt.City as "CustomerCity"
from Suppliers s inner join
(select c.ContactName,c.City
from Customers c
where c.CustomerID in (select o.CustomerID from Orders o))dt
on dt.City != s.City;

--8.	List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
		
select top 5 p.ProductName, avg(p.UnitPrice) as "Avg", count(od.ProductID) as "Qty", c.City
from [Order Details] od inner join Products p
on od.ProductID = p.ProductID
inner join Orders o
on o.OrderID = od.OrderID
inner join Customers c
on c.CustomerID = o.CustomerID
group by p.ProductName, c.City
order by qty desc;
		
		
--9.	List all cities that have never ordered something but we have employees there.
--a.	Use sub-query
select distinct c.City
from Customers c inner join Orders o
on c.CustomerID not in(o.CustomerID)
where o.EmployeeID in (select e.EmployeeID from Employees e);

--b.	Do not use sub-query
select distinct c.City
from Employees e inner join Orders o
on o.EmployeeID = e.EmployeeID
inner join Customers c
on c.CustomerID not in(o.CustomerID);

--10.	List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
with EmployeeIdCount
as
(
    select  e.City, e.EmployeeID, count(o.EmployeeID) as "Total"
    from Employees e inner join orders o
    on e.EmployeeID = o.EmployeeID
    group by e.EmployeeID,e.City
),
CustomerCTE
as
(
    select eic.city, sum(eic.Total) as "TotalOrders"
    from EmployeeIdCount eic
    group by eic.city
)
select top 1 city,TotalOrders from CustomerCTE
order by TotalOrders desc;
		
--11. How do you remove the duplicates record of a table?
--Find duplicate rows using GROUP BY clause or ROW_NUMBER() function
--Use DELETE statement to remove the duplicate rows;

--12. Sample table to be used for solutions below- Employee ( empid integer, mgrid integer, deptid integer, salary integer) Dept (deptid integer, deptname text)
-- Find employees who do not manage anybody.
Declare @Employee TABLE(empid integer, mgrid integer, deptid integer, salary integer) 
Declare @Dept Table(deptid integer, deptname text)
INSERT into @Employee(empid,mgrid)
select EmployeeID,ReportsTo from Employees
UPDATE @Employee SET deptid = 1
update @Employee set salary=200000;

WITH x 
AS (SELECT mgrid FROM @Employee GROUP BY mgrid)
SELECT e.empid
FROM   @Employee e
LEFT   JOIN x ON x.mgrid = e.empid
WHERE  x.mgrid IS NULL
GROUP  BY e.empid;

--13. Find departments that have maximum number of employees. (solution should consider scenario having more than 1 departments that have maximum number of employees). Result should only have - deptname, count of employees sorted by deptname.
select top 1 e.deptid,count(e.empid)
from @Employee e
group by e.deptid;

--14. Find top 3 employees (salary based) in every department. 
--    Result should have deptname, empid, salary sorted by deptname and then employee with high to low salary.

select top 3 e.empid,e.salary,e.deptid
from @Employee e
order by e.deptid,e.empid,e.salary





