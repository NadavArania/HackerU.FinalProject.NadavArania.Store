# HackerU.FinalProject.NadavArania.StoreStore Project Nadav Arania
I present you "Store" website with server and client side form together for gaming and non-gaming products shopping.
This website giving you the freedom to buy whatever you need and split to 3 user's levels.
Admin – when you logging as admin you have full control over the website, you can manage users and products with few options for editing and deleting users or products and even adding products to the website as you wish.
User – when you logging as user you can view all the products in the store and also view them as a single product, also you have many ways to filter the products as you want, when you finish you can add products to your cart and of course to delete them from your cart.
Also you can go to your settings tab and edit your details and see your previous orders if you would like to.
Guest – if you aren't logged you can register to see what our website include or search get knowledge what products we have.
For admin logging  email : admin@email.com and password : ya12!mmo
For User1 logging email: regUser@email.com and password: 4rt@4abc
For User2 logging email: mike_north154@email.com and password: i8per!mn
First thing I did is to create models project in HackerU.FinalProject.NadavArania.Store.Db project which include the models of db and the context for db ,migrations, folders for interfaces and pre-config models for the db.
With preconfig folder the models that been created will be automatically created when you load the app first and will be inside the db.
Second thing I did is to create the core project that have relationship with the models project in HackerU.FinalProject.NadavArania.Store.Core project which include repositories and services that connect to the repositories, also you can find dtos and converter for the dtos. 
With the repository and service inside the core project I was able to made a generic crud operations and all the models will have those operations, the services bringing option to go for smaller resolution per model.
Also dtos and converter helping to handle models easier and use the needed traits of the models.
Third thing I did is to create web api project that have relationship with the core project in HackerU.FinalProject.NadavArania.Store.UI_And_Api project which include the server side controller with the angular ui client side, and of course all the middlewares in the program file.
With the controllers we have controller for each model with functions that call one of the http requests, every controller connect with the repositories and services from the core project.
Users controller responsible calling db for getting all users or logged user, adding user to the db, editing user, deleting user (by admin), also the login and logout functions and order history per user.
Products controller responsible calling db for getting all products, adding product to cart and deleting them from cart, also adding, editing and deleting products from the store generally by the admin.
Orders controller responsible calling db for getting all orders and adding order after user finish is order and also delete orders from users (by admin).
OrderProducts controller responsible to calling db for getting all the orderproducts connection between those two models.
Inside the clientapp folder that represent angular project you can find the client side web that split to components – home,navbar,about,footer,cart,login.register,product,settings.
For services we have product service which call to the product controller from the api, user service which call the user controller from the api and validations service to include all validations from the web form or alert validations.
Also there 2 guard for discard changes in form that allow the user to choose if to discard changes or not, also navigation guard to prevent unauthorized user access to tabs that he isn’t allowed.
Guest can't navigate to cart, product and settings tab, user have settings page that is different from the admin.
So go out there and explore our store!
