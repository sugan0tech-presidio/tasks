select CategoryID, categoryname from Categories
union 
select SupplierID, CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry = 'Spain'
intersect
select * from Orders where Freight>50

select * from Orders where ShipCountry = 'Spain'
union all
select * from Orders where Freight>50
