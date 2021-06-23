--2.	Design a database for a lending company which manages lending among people (p2p lending)

create table lenders(LenderID int primary key, LenderName varchar (40), 
AvailableMoney decimal (10,2))


create table borrowers(BorrowerID int primary key, borrowerName varchar (40),
RiskValue decimal (10,2))

create table loans(LoanCode int primary key, BorrowerID int foreign key references borrowers(BorrowerID),
LoanAmount decimal (10,2),DDL datetime, Rate decimal (5,2),Purpose varchar (100))

create table lenderManage(LenderID int foreign key REFERENCES lenders(LenderID), 
LoanCode int foreign key references loans(LoanCode))

