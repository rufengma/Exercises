--1.	Lock tables Region, Territories, EmployeeTerritories and Employees. Insert following information into the database. 
--In case of an error, no changes should be made to DB.
--a.	A new region called “Middle Earth”;
insert into Region
values (5,'Middle Earth')
--b.	A new territory called “Gondor”, belongs to region “Middle Earth”;
insert into Territories(TerritoryID,TerritoryDescription,RegionID)
values(99999,'Gondor',5)

--c.	A new employee “Aragorn King” who's territory is “Gondor”.

SET IDENTITY_INSERT Employees ON
insert EmployeeTerritories values(10,99999)
insert Employees (EmployeeID,LastName,FirstName)
values(10,'Aragon','King')
select * from EmployeeTerritories

-- 2.	Change territory “Gondor” to “Arnor”.
select * from Territories
update Territories
set TerritoryDescription = 'Arnor'
where TerritoryDescription='Gondor'

--3.	Delete Region “Middle Earth”. (tip: remove referenced data first) 
--(Caution: do not forget WHERE or you will delete everything.) 
--In case of an error, no changes should be made to DB. Unlock the tables mentioned in question 1.
select * from Territories
select * from Region
delete from Territories where TerritoryDescription='Arnor'
delete from Region where RegionID=5

--4. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
create view view_product_order_Ma as 
select p.ProductID,sum(o.Quantity) as 'total'
from Products p
left join [Order Details] o
on p.ProductID=o.ProductID
group by p.ProductID

select * from view_product_order_Ma

--5.	Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
create procedure sp_product_order_quantity_Ma 
@Pid int 
@TotalOrder int output
as
select 
@TotalOrder = sum(od.Quantity)
from [Order Details] od, Products p
on od.ProductID = p.ProductID
group by  p.ProductID

--6.	Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.
create procedure sp_product_order_city_Ma
@PName nvarchar(40)
@VCity output
@Total output
as
select top 5 c.City, sum(od.Quantity)
from [Order Details] od inner join Products p
on p.ProductName = @Pname and p.ProductID = od.ProductID
inner join Orders o
on o.OrderID = od.OrderID
inner join Customers c
on c.CustomerID = o.CustomerID
group by c.City
order by sum(od.Quantity) desc
--7.	Lock tables Region, Territories, EmployeeTerritories and Employees. 
--Create a stored procedure “sp_move_employees_[your_last_name]” that automatically find all employees in territory “Tory”; 
--if more than 0 found, insert a new territory “Stevens Point” of region “North” to the database, and then move those employees to “Stevens Point”.
create procedure sp_move_employees_Ma as
select *
from EmployeeTerritories et inner join Territories t
on t.TerritoryID = et.TerritoryID
inner join Employees e
on et.EmployeeID = e.EmployeeID
where t.TerritoryDescription = 'Tory'
--8.	Create a trigger that when there are more than 100 employees 
--in territory “Stevens Point”, move them back to Troy. (After test your code,) 
--remove the trigger. Move those employees back to “Troy”, if any. Unlock the tables.

Create trigger move_back on EmployeeTerritories
for UPDATE as 
begin 
update EmployeeTerritories
set et.TerritoryID=9
where 100< (select count(et.EmployeeID) as 'total'
from EmployeeTerritories et
right join Territories t
on t.TerritoryID=et.TerritoryID
group by et.TerritoryID)  

end



--9.	Create 2 new tables “people_your_last_name” “city_your_last_name”. City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.
--10.	 Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
--11.	Create a stored procedure named “sp_your_last_name_1” that returns all cites that have at least 2 customers who have bought no or only one kind of product. Create a stored procedure named “sp_your_last_name_2” that returns the same but using a different approach. (sub-query and no-sub-query).
--12.	How do you make sure two tables have the same data?
--We can write 3 queries
--An inner join to pick up the rows where the primary key exists in both tables, but there is a difference in the value of one or more of the other columns. This would pick up changed rows in original.
--A left outer join to pick up the rows that are in the original tables, but not in the backup table (i.e. a row in original has a primary key that does not exist in backup). This would return rows inserted into the original.
--A right outer join to pick up the rows in backup which no longer exist in the original. This would return rows that have been deleted from the original.
--14.
create table t2(varchar(20))
insert t2 values('FullName')
insert t2 values(select (t.FirstName+' 't.LastName) as FullName from t1 t)
--15.
select top 1 t.Student
from t1 t
where t. Sex = 'F'
order by t.Marks
--16. output is 'Li'
select top 1 t.Student
from t1 t
where t. Sex = 'F'
order by t.Marks
