
select ContactName, OrderID
from Customers c left outer join Orders o
on c.CustomerID = O.CustomerID


select * from products where ProductID not in (select distinct ProductID from [Order Details])