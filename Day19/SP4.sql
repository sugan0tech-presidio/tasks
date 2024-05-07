SELECT TOP 5 titles.title, publishers.pub_name, CONCAT(authors.au_fname, ' ', authors.au_lname) AS AuthorName, sales.qty, price
FROM sales
INNER JOIN titles ON sales.title_id = titles.title_id
INNER JOIN publishers ON titles.pub_id = publishers.pub_id
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
ORDER BY price;
