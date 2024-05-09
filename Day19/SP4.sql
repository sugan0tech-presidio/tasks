-- Create a query that will float the data from sales,titles, publisher 
-- and authors table to print title name, Publisher's name, author's full 
-- name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price of order

SELECT TOP 5 titles.title, publishers.pub_name, CONCAT(authors.au_fname, ' ', authors.au_lname) AS AuthorName, sales.qty, price
FROM sales
INNER JOIN titles ON sales.title_id = titles.title_id
INNER JOIN publishers ON titles.pub_id = publishers.pub_id
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
ORDER BY price;
