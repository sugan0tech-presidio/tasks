select OrderID,ProductName, Quantity "Quantity sold"
from [Order Details] od join Products p
on od.ProductID = p.ProductID
where p.UnitPrice > 15

select od.OrderID, p.ProductName, od.quantity as "Quantity Sold", p.UnitPrice
from [Order Details] od join Products p 
on od.ProductID=p.ProductID join Categories c on p.CategoryID=c.CategoryID
where (p.UnitPrice between 10 and 20) and (c.CategoryName like '%dairy%');
	
select top 10 OrderID, c.CustomerID  
from Orders od join Customers c
on od.CustomerID = c.CustomerID


with OrderDetailsFRUS_CTE (OrderID,CustomerName,ProductName) as (
select O.OrderId, C.ContactName, P.ProductName 
from Orders O
join [Order Details] OD on OD.OrderID = O.OrderID
join Customers C on C.CustomerID = O.CustomerID
join Products P on P.ProductID = OD.ProductID
where O.ShipCountry like 'USA'
union
select O.OrderId, C.ContactName, P.ProductName 
from Orders O
join [Order Details] OD on OD.OrderID = O.OrderID
join Customers C on C.CustomerID = O.CustomerID
join Products P on P.ProductID = OD.ProductID
where O.ShipCountry like 'France' and O.Freight < 20)
 
Select top 10 * from OrderDetailsFRUS_CTE;
