create table courses(CourseName varchar(40) primary key, CourseDescription varchar (500), photo varbinary(max),
finalPrice decimal(5,2))

create table categories (cagetoryName varchar(40),catetoryDescription varchar(500), employeeName varchar(25), CourseName varchar (40)
FOREIGN key REFERENCES courses(CourseName))

create table recipes(CourseName varchar (40) FOREIGN key REFERENCES courses(CourseName),
ingredientName varchar(100) FOREIGN key references ingredients(ingredientName), 
Unit varchar (20), requiredAmount decimal (5,2))

create table ingredients (ingredientName varchar (100) primary key,unitMeasurement 
varchar (20), totalMass decimal (5,2))



