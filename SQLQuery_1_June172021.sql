
/* Q1*/
Select p.ProductID, p.Name,p.Color, p.ListPrice
From Production.Product p;

/*Q2*/
Select p.ProductID, p.Name,p.Color, p.ListPrice
From Production.Product p
where p.ListPrice=0;

/* Q3*/
Select p.ProductID, p.Name,p.Color, p.ListPrice
From Production.Product p
where p.color is NULL;

/* Q4*/
Select p.ProductID, p.Name,p.Color, p.ListPrice
From Production.Product p
where p.color is not NULL;

/* Q5*/
Select p.ProductID, p.Name,p.Color, p.ListPrice
From Production.Product p
where (p.color is not NULL) and (p.ListPrice!=0);

/* Q6*/
Select p.Name,p.Color
From Production.Product p
where p.color is not NULL;

/* Q7*/
Select p.Name,p.Color
From Production.Product p
where p.Color is not null;

/* Q8*/
Select p.ProductID,p.Name
From Production.Product p
where p.ProductID between 400 and 500;

/* Q9*/
Select p.ProductID,p.Name,p.Color
From Production.Product p
where p.Color='Black' or p.Color='Blue';

/* Q10*/
Select p.Name, p.ProductID
From Production.Product p
where p.Name like 'S%';

/* Q11*/
Select p.Name, p.ListPrice
From Production.Product p
where p.Name like 'S%'
order by p.Name;

/* Q12*/
Select p.Name, p.ListPrice
From Production.Product p
where (p.Name like 'S%') or (p.Name like 'A%')
order by p.Name;

/* Q13*/
Select p.*
From Production.Product p
where (p.Name like 'S[^k,K]%') or (p.Name like 'P[^k,K]%') or (p.Name like 'O[^k,K]%') 
order by p.Name;

/* Q14 distinct colors*/
Select distinct p.Color
From Production.Product p
order by p.Color desc;

/* Q15*/
Select distinct p.ProductSubcategoryID, p.Color
From Production.Product p
where (p.Color is not NULL) and (p.ProductSubcategoryID is not null)
order by p.ProductSubcategoryID;

/* Q16*/
SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice 
FROM Production.Product
WHERE not ((Color IN ('Red','Black')) and ProductSubCategoryID = 1 and (ListPrice not BETWEEN 1000 AND 2000) ) 
ORDER BY ProductID

/* Q17*/
SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
where ProductSubcategoryID<=14 and (ListPrice in (1431.5000, 1364.50,1700.99,539.9900))
order by ProductSubcategoryID desc;
