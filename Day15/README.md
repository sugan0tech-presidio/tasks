Day 15 30 Apr Tue 

Question1

Design the database for a shop which sells products
Points for consideration
  1) One product can be supplied by many suppliers
  2) One supplier can supply many products
  3) All customers details have to present
  4) A customer can buy more than one product in every purchase
  5) Bill for every purchase has to be stored
  6) These are just details of one shop
 
Note:- you do not have to store the shop details.

### ER Diagram

![ShoppingER](./ShoppingER.png)
 
Question2

Case 1: A Simple Case on ER Modelling
•	Goal – to demonstrate how to build an E-R model from a simple Statement of Objectives of a movie store. ( given very clearly in statement forms)
Scenario:
- A video store rents movies to members.
- Each movie in the store has a title and is identified by a unique movie number.
- A movie can be in VHS, VCD, or DVD format.
- Each movie belongs to one of a given set of categories (action, adventure, comedy, ... )
- The store has a name and a (unique) phone number for each member.
- Each member may provide a favorite movie category (used for marketing purposes).
- There are two types of members: 
  - Golden Members:
  - Bronze Members:
- Using  their credit cards gold members can rent one or more movies and bronze members max. of one movie.  
- A member may have a number of dependents (with known names).|


## ER Diagram
![MovieStoreER](./MovieStoreER.png)
- Each dependent is allowed to rent one (1) movie at a time.
