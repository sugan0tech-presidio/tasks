select OrderID,ProductName, Quantity "Quantity sold"
from [Order Details] od join Products p
on od.ProductID = p.ProductID
where p.UnitPrice > 15

select od.OrderID, p.ProductName, od.quantity as "Quantity Sold", p.UnitPrice
from [Order Details] od join Products p 
on od.ProductID=p.ProductID join Categories c on p.CategoryID=c.CategoryID
where (p.UnitPrice between 10 and 20) and (c.CategoryName like '%dairy%');
	