--drop tables first if you have executed before.
-- drop table offices
-- drop table cityInfo
-- drop table projects
-- drop table cityProjects

--table cityInfo
create table cityInfo(city varchar(25) primary key,country varchar(25),inhabitations int)
insert into cityInfo values ('New York City','US',500000)
insert into cityInfo values ('Beijing','China', 1000000)
insert into cityInfo values ('London','UK',200000)
insert into cityInfo values ('Troy','US',50000)
--table offices
create table offices(officeName varchar(25) primary key,city varchar(25) FOREIGN KEY REFERENCES cityInfo(city),
country varchar(25),phoneNumber varchar (25), director varchar (25))

insert into offices values ('NYC office', 'New York City','US','(+1)515997654','Steve Jobs')
insert into offices values ('BJ office', 'Beijing','China','(+86)515997654','Huateng Ma')
insert into offices values ('London office', 'London','UK','(+44)515997654','Joseph King')
--Table Projects
create table projects(projectCode int primary key, title varchar(25), startDate datetime,
endDate datetime, budget int, manager varchar(25))

insert into projects values (1,'clean the city','2021-01-01','2022-01-01',1000000, 'Jay Chou')
insert into projects values (2,'clean the air','2022-01-01','2025-01-01',2000000, 'Ruby Lin')
insert into projects values (3,'build facilities','2001-01-01','2030-01-01',3000000, 'Coco Li')

--table cityprojects
create table cityProjects(city varchar(25) FOREIGN key references cityInfo(city),
projectCode int primary key foreign key references projects(projectCode))

insert into cityProjects values ('New York City',1)
insert into cityProjects values ('Beijing',2)

