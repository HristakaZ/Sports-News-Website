# Sports News Website
A Sports News Website that is built with ASP.NET Framework 4.7.2 MVC.
# Skeleton of the project
The whole solution is made of three projects :
* `DataStructure` - Contains all of the Models (Athletes, Comments, News, Sports, Users).
* `DataAccess` - Contains the migrations added to the project, the Repositories which make CRUD operations linked to the 
models and the Unit Of Work which consists of the repositories. 
* `Sports News Website` - Here we can find the Controllers, Views, DTOs (Data Transfer Objects), Services, ViewModels and
the Photo folder where the images from the news are stored.
# Functionality of the project
* We can create, read, update and delete everything (news, comments, athletes, sports and users) in the project if we have 
Admin privileges.
* The normal user can register an account in which he can log in to read information on the website. He can also apply the 
CRUD operations on the comments and on the accounts, but cannot edit/delete other users' comments/accounts.