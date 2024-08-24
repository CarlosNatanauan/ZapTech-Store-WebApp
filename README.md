# ZapTech Store Web Application

ZapTech Store is a simple CRUD (Create, Read, Update, Delete) web application developed using ASP.NET Core MVC. This application allows users to manage a catalog of products, including viewing, adding, editing, and deleting product records.

## Features
- **View Products**: See a list of all products with details like ID, name, brand, category, price, and image.
- **Add New Product**: Create new products with information such as name, brand, category, price, description, and image.
- **Edit Product**: Modify the details of existing products.
- **Delete Product**: Remove products from the catalog.

## Screenshots

### Home Page
![Home Page](https://github.com/user-attachments/assets/31809c64-f272-41af-9b2b-b1865d27cb78)

The home page provides an overview of the application and access to product management features.

### Product Page
![Product Page](https://github.com/user-attachments/assets/2e5e1625-5456-455f-ac99-ac08e835997b)

Displays a list of all products with options to edit or delete.

### Add Product
![Add Product](https://github.com/user-attachments/assets/8aa5d8e3-d526-4baa-97eb-36f8d742fceb)

Form for adding a new product to the catalog.

### Edit Product
![Edit Product](https://github.com/user-attachments/assets/04b3592c-1747-4c2a-9ba1-e528a03ffc1f)

Form for editing an existing product's details.

### Delete
![Delete](https://github.com/user-attachments/assets/b981d2ff-046b-44de-98f6-24dbc9004212)

Confirmation prompt for deleting a product.

## Project Structure
The project is built using ASP.NET Core MVC. Here is an overview of the structure:

- **Controllers**
  - `ProductController.cs`: Manages CRUD operations for products.

- **Models**
  - `ProductDto.cs`: Data transfer object for product information.
  - `Product.cs`: Represents a product entity with properties such as `Id`, `Name`, `Brand`, `Category`, `Price`, `Description`, and `ImageFileName`.

- **Views**
  - `Home/Index.cshtml`: The main homepage view.
  - `Product/Index.cshtml`: Displays the list of products.
  - `Product/Create.cshtml`: Form for adding a new product.
  - `Product/Edit.cshtml`: Form for editing an existing product.
  - `Product/Delete.cshtml`: Confirmation for deleting a product.

## Usage
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/zaptech-store-webapp.git
