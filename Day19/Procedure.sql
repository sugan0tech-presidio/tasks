create procedure proc_GreetWithName(@cname varchar(20), @edob datetime)
as 
begin
	print 'Hllo' +@cname
end

execute proc_GreetWithName 'test'
