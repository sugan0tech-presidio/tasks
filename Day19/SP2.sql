-- Create a sp that will take the employee's firtname and 
-- print all the titles sold by him/her, price, quantity and the cost.
CREATE PROCEDURE get_titles_sold
    @employee_firstname varchar(50)
AS
BEGIN

    select titles.title "Title", titles.price, sum(sales.qty) "Sales", titles.price * sum(sales.qty)  "Cost"
    from sales
    join titles on sales.title_id = titles.title_id
    join employee on employee.pub_id = titles.pub_id
    where employee.fname = @employee_firstname
	group by titles.title, titles.price;

END;

GO

EXECUTE get_titles_sold 'Victoria';

GO
DROP PROCEDURE get_titles_sold

GO
SELECT * FROM employee
