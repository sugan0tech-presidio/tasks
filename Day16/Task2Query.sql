use pubs;
select * from titles

-- Question 1: Print all the titles names
select title from titles

-- Question 2: Print all the titles that have been published by 1389

select title from titles
where pub_id = 1389

-- Question 3: Print the books that have price in rangeof 10 to 15

select * from titles
where price between 10 and 15

-- Question 4: Print those books that have no price
select * from titles
where price is null

-- Question 5: Print the book names that strat with 'The'
select * from titles
where title LIKE 'The%'


-- Question 6: Print the book names that do not have 'v' in their name
select * from titles
where title not LIKE '%v%'

-- Question 7: print the books sorted by the royalty
select * from titles
order by royalty asc

-- Question 8: print the books sorted by publisher in descending then by types in asending then by price in descending
select * from titles
order by pub_id desc, price asc

-- Question 9: Print the average price of books in every type
select avg(price) as 'average price', type from titles
group by type

-- Question 10: print all the types in uniques
select distinct type from titles

-- Question 11: Print the first 2 costliest books
select TOP 2 * from titles
order by price 

-- Question 12: Print books that are of type business and have price less than 20 which also have advance greater than 7000
select * from titles
where type = 'business' and price < 20 and advance > 7000

-- Question 13: Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count
select pub_id, count(title) as 'count' from titles
where title like '%It%' and price between 15 and 25
group by pub_id
having count(title) > 2
order by count(title)

-- Question 14: Print the Authors who are from 'CA'
select * from authors 
where state = 'CA'

-- Question 15: Print the count of authors from every state
select state, count(au_id) as 'count' from authors
group by state

