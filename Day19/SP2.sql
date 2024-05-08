create procedure get_titles_sold
    @employee_firstname varchar(50)
as
begin
    select titles.title "Title", titles.price, sales.qty, titles.price * sales.qty  "Cost"
    from sales
    join titles on sales.title_id = titles.title_id
    join employee on employee.pub_id = titles.pub_id
    where employee.fname = @employee_firstname;
end;

go

execute get_titles_sold 'Victoria';

go
drop procedure get_titles_sold
