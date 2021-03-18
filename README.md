# AnimalShelter
--- 
Developers: Aaron Van Curen, David Benge, Jacob Hash

## Table of Contents
- Mission Statement
- Database
- Features
- Links

# Mission Statement
---
We are creating an API for an animal adoption website hub.
We would like various shelters to post available animals that are ready to be adopted and give potential animal owners an easy way to access this information.

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

[Trello](https://trello.com/b/lJKVo70w/animal-shelter)

[DB Diagram](https://dbdiagram.io/d/60536101ecb54e10c33c1866)
