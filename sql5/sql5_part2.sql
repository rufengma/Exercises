--1.	Write an sql statement that will display the name of each customer and the 
--sum of order totals placed by that customer during the year 2002

Create table customer(cust_id int primary key,  iname varchar (50))
create table Orders(order_id int primary key,cust_id int foreign key references customer(cust_id),
amount money,order_date smalldatetime)

insert into customer values(1, 'xiaoming')
insert into customer values(2, 'baby')
insert into Orders values(1, 1, '1,000', '2002-01-01')
insert into Orders values(2, 1, '1,000', '2002-01-01')
insert into Orders values(3, 2, '1,000', '2002-01-01')

select c.iname, count(o.order_id) as 'total orders'
from orders o 
inner join customer c
on c.cust_id=o.cust_id
group by c.iname

-- 2.  The following table is used to store information about company’s personnel:
--Create table person (id int, firstname varchar(100), lastname varchar(100)) 
--write a query that returns all employees whose last names  start with “A”.

Create table person (id int, firstname varchar(100), lastname varchar(100))
insert into person values(1,'will','smith')
insert into person values(2,'steve','jobs')
insert into person values(3,'nicole','kidman')
insert into person values(4,'William','Ashok')

select p.id,p.firstname,p.lastname
from person p 
where p.lastname like 'A%'
--3.Please write a query that would return the names of all 
--top managers(an employee who does not have  a manger, and the number of people that report directly to this manager.
Create table person2(person_id int primary key,
 manager_id int null, name varchar(100)not null) 
insert into person2 values(1,null,'will smith')
insert into person2 values(2,1,'steve jobs')
insert into person2 values(3,2,'Coco Li')
insert into person2 values(4,1,'Guigui Wu')
insert into person2 values(5,1,'Lili Ann')

select T1.person_id,T2.subordinate
from (select * from person2) as T1
inner join (select p.manager_id, count(p.person_id) as subordinate
            from person2 p
            group by p.manager_id
            having count(p.person_id)>=1) T2 
            on t1.person_id=T2.manager_id

--4.  List all events that can cause a trigger to be executed.

--DML statements that modify data in a table ( INSERT , UPDATE , or DELETE )
--DDL statements.
--System events such as startup, shutdown, and error messages.
--User events such as logon and logoff. Note: Oracle Forms can define, store, and run triggers of a different sort.

--5. Generate a destination schema in 3rd Normal Form.  
--Include all necessary fact, join, and dictionary tables, 
--and all Primary and Foreign Key relationships.  The following assumptions can be made:

-- a. Each Company can have one or more Divisions.
-- b. Each record in the Company table represents a unique combination 
-- c. Physical locations are associated with Divisions.
-- d. Some Company Divisions are collocated at the same physical of Company Name and Division Name.
-- e. Contacts can be associated with one or more divisions at the address, but are differentiated by 
--    suite/mail drop records.status of each association should be separately maintained and audited.

create table Company(CompanyName varchar(40), DivisionName varchar(40) primary key)
create table Collocat(CompanyName varchar(40) primary key,DivisionName varchar(40))
create table Contacts(DivisionName varchar(40) primary key FOREIGN KEY REFERENCES Company(DivisionName), DivisionAddress varchar (40), DivisionSuite varchar(20))
create table MailDropRecords (ReceiveName varchar(40), ReceiveAddress varchar (100),ReceiveSuite varchar(20))




