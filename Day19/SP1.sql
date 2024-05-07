CREATE PROCEDURE GetBooksByAuthor
    @AuthorFirstName NVARCHAR(50)
AS
BEGIN
    SELECT titles.title, publishers.pub_name, authors.au_fname
    FROM titles
	INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
    INNER JOIN authors ON titleauthor.au_id = Authors.au_id
    INNER JOIN publishers ON titles.pub_id = publishers.pub_id
    WHERE authors.au_fname = @AuthorFirstName;
END


execute GetBooksByAuthor 'Dean'
drop procedure GetBooksByAuthor
