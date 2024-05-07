sp_help Employees

select * from Employees
create index indexEmpAddr on Employees(Address)

select * from Employees where Address like'a%'

drop index indexEmpAddr on Employees