E-commerce API

** Overview **

This project is an E-commerce API designed to facilitate online shopping activities. 
It provides functionalities such as managing user carts, placing orders, managing products and categories, and user authentication.

** Features **

User Management: Allows users to register and log in.
Shopping Cart: Supports adding, removing, and updating items in the shopping cart and can clear your cart.
Order Management: Enables users to place orders and view their order history.
Product and Category Management: shows all products, details of any product, and all categories.
Admins: 
Product and Category Management: Provides CRUD operations for managing products and adding new categories.

** Project Structure **
The project follows a N-tier architecture, separating concerns into different layers:

1- Data Access Layer (DAL): Contains Entity Framework Core data models (Models), database context (Data. Context), and repositories (Repositories) for different entities.
2- Business Logic Layer (BL): Implements business logic and operations, Contains managers (Managers) responsible for implementing business logic for different functionalities.
3- API Layer: Exposes RESTful endpoints for clients to interact with the system and contains controllers (Controllers) that define RESTful endpoints for client interaction.

** Technologies Used **

ASP.NET Core: Framework for building web APIs.
Entity Framework Core: ORM for database access.
Identity Framework: For user authentication and authorization.
Dependency Injection: Used for managing dependencies and promoting loose coupling.
postman: Provides API documentation and testing interface.

** Controllers **

1- CartController 
Description: Manages operations related to the user's shopping cart, including adding, removing, and editing cart items, and clearing the cart.
Endpoints:
- GET /api/cart: Retrieves the user's cart.
- POST /api/cart/{productId}/{quantity}: Adds a product to the cart.
- DELETE /api/cart/{productId}: Removes a product from the cart.
- PUT /api/cart/{productId}/{quantity}: Updates the quantity of a product in the cart.
- DELETE /api/cart: Clears the cart.
Authorization: User authentication is required for accessing these endpoints.

2- OrderController
Description: Manages order-related operations, such as placing orders and retrieving order history.
Endpoints:
- POST /api/orders/place-order: Places an order.
- GET /api/orders/order-history: Retrieves the user's order history.
Authorization: User authentication is required for accessing these endpoints.

3- ProductsController
Description: Handles operations related to products, including retrieving, adding, updating, and deleting products with image functionality.
Endpoints:
- GET /api/products: Retrieves products optionally filtered by category or name.
- GET /api/products/{id}: Retrieves details of a specific product.
- POST /api/products: Adds a new product with upload image functionality.
- PUT /api/products/{id}: Updates an existing product  with upload image functionality.
- DELETE /api/products/{id}: Deletes a product.
Authorization: Add, Update, and delete require admin privileges.

4- UsersController
Description: Handles user authentication and registration.
Endpoints:
- POST /api/users/Login: Allows users to log in and obtain an access token.
- POST /api/users/Register: Allows users to register.
Authorization: No authorization is required for these endpoints.

5- CategoryController
Description: Handles operations related to Category, including retrieving and adding.
- GET /api/Category: Retrieves all Categories.
- POST  /api/Category: Adds a new category.
Authorization: Add required admin privileges.


**Video of test**

For a visual demonstration of testing the API using Postman, you can watch the following video:
