# AnimalShelter
--- 
Developers: Aaron Van Curen, David Benge, Jacob Hash

## Table of Contents
- Mission Statement
- Testing Directions
- Database
- Features
- Links

# Mission Statement
---
We are creating an API for an animal adoption website hub.
We would like various shelters to post available animals that are ready to be adopted and give potential animal owners an easy way to access this information.

# Testing Directions
**NOTE**
This is scaffolding for utilizing the Web Api. You might still need to change certain values based on your own databases made from this program

1. Clone Solution
2. Upon opening solution find the **Postman Tests** folder in the file location for the solution
3. Included is the AnimalShelter.postman_collection.json file
4. In Postman import a new Workspace
5. Drag and drop AnimalShelter.postman_collection.json
6. In the workspace you will notice a plethora of endpoints
7. Use *Post* Register Vet Account - This will create your account as a Vet
8. Use *Get* Vet Token - This will automatically pull in your Bearer Token into the other tests 
9. The Vet Account was made for the Vaccine Tests. Initial testing of Vaccine will not enable any other tests
10. Use *Post* Logout - This will enable you to create a new user
11. Use *Post* Register Company Account - This will create your account as a Company
12. Use *Get* Company Token - This will automatically pull in your Bearer Token into the other tests 
13. The Company Account was specifically made for the Post class and it's controllers
14. Use *Post* Dog, Cat, and Bunny to allow you to test the Animals class. The Animals class will enable the Post class Tests
15. Test the Post Class *Post*, *Get*, *Put*, and *Delete* Animal Posts endpoints
16. Use *Post* Logout
17. Use *Post* Register Customer Account - This will create your account as a Customer
18. Use *Get* Customer Token - This will automatically pull in your Bearer Token into the other tests 
19. The Customer Account was made for the Adopt Tests. Previous testing of the Company process will enable the Adoption Tests
20. This is the time to Test Comments and Replies. Comments on Posts will enable the Replies Tests.
21. Adoptions can now be successfully tests

# Database
---
#### table User
- Id string
- UserType UserType
- FullName string
- CompanyName string
- PhoneNumber string
- Address string
- Vaccines virtualListVaccine
- Animals virtualListAnimal
- Posts virtualListPost
- Ratings virtualListRating
- Rating double

#### table Adoption
- UserId string
- AdoptionId int
- PostId int
- Post virtualPost


#### table Animal
- AnimalId int
- Name string
- Species SpeciesType
- Breed string
- Sex bool
- Fixed bool
- Vaccines virtualListVaccine
- Age string
- Description string
- AdoptionPrice decimal
- IsHouseTrained bool
- IsDeclawed bool
- IsEdible bool


### table Comment
- CommentId int
- Content string
- Author string
- Replies virtualListReply
- PostId int
- Post virtualPost


### table UserRating
- RatingId int
- AdoptingProcessScore double
- FriendlinessScore double
- AverageScore double
- Id int
- ApplicationUser virtualApplicationUser


### table Post
- UserId string
- PostId int
- AnimalId int
- Animal virtualAnimal
- ProfileId int
- Comments virtualListComment


### table Reply
- ReplyId int
- Content string
- Author string
- CommentId int
- Comment virtualComment
 

### table Vaccine
- VaccineId int
- Name string
- CommonName string
- ApplicableAnimals listString
- VaccinationSchedule string


# Endpoints

- Post Register Account
- Get Token
- Post Logout
- Get Customers
- Get Companies
- Get Vets
- Get User by Email
- Update User by Id
- Delete User by Email
- Post User Rating
- Get User Rating
- Get User Rating by Rating Id
- Post Create Dog
- Post Create Cat
- Post Create Bunny
- Get Animals Posts
- Update Animal Posts
- Delete Animal Posts
- Post Adoption
- Get Adoption
- Get Adoption By Id
- Update Adoption
- Comment on Post
- Get Comment on Post
- Update Comment on Post
- Delete Comment on Post
- Reply on Comment
- Get Reply on Comment
- Update Reply on Comment
- Delete Reply on Comment
- Create Vaccine
- Get Vaccines
- Update Vaccine
- Delete Vaccine
 
# Features

### Version 1.0 / MVP	Version 2.0 / Stretch Goals
-	Search for Animal
-	Post an Animal
-	Adopt an Animal	
-	Provide Vaccine Info

# Links

[Trello](https://trello.com/b/lJKVo70w/animal-shelter)

[DB Diagram](https://dbdiagram.io/d/60536101ecb54e10c33c1866)
