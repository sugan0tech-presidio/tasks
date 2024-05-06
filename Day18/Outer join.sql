
select ContactName, OrderID
from Customers c left outer join Orders o
on c.CustomerID = O.CustomerID