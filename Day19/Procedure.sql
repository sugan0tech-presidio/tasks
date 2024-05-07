create procedure proc_GreetWithName(@cname varchar(20))
as 
begin
	print 'Hllo' +@cname
end

execute proc_GreetWithName 'test'
