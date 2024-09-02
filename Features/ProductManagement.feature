@ProductManagement
Feature: ProductManagement
As a Licenta API consumer, I want to be able to manage products

@NotLoggedIn
Scenario: Cannot access /addProduct or other resources without using a valid user
	When I make a POST request to /addProduct using './Resources/Products/AddNewProductRequest.json' file
	Then I confirm the response code from /addProduct is 401 Unauthorized

@LoginAsCustomer
Scenario: Cannot access /addProduct or other resources if logged in as customer
	When I make a POST request to /addProduct using './Resources/Products/AddNewProductRequest.json' file
	Then I confirm the response code from /addProduct is 403 Forbidden

@LoginAsAdmin
Scenario: Successfully get all products
	When I make a GET request to /getProducts endpoint
	Then I confirm the response code from /getProducts is 200 OK

@LoginAsAdmin
Scenario: Successfully get product by Name
	When I make a GET request to /getProducts with the Name=Stock Test API param
	Then I confirm the response code from /getProducts is 200 OK
	And I can confirm Product Demo 1 data is displayed in the result from /getProducts

@LoginAsAdmin @ProductCleanUp
Scenario: Successfully add a new product
	When I make a POST request to /addProduct using './Resources/Products/AddNewProductRequest.json' file
	Then I confirm the response code from /addProduct is 200 OK
	When I make a GET request to /getProducts with the Name=Product Test API param
	Then I confirm the response code from /getProducts returns the new product's Name - Product Test API

@LoginAsAdmin 
Scenario: Cannot add a new product with an existing name
	When I make a POST request to /addProduct using './Resources/Products/ProductExistingData.json' file
	Then I confirm the response code from /addProduct is 400 Bad Request
	And I confirm /addProduct returns response status 1 with validation message: Exista deja un produs cu acest nume.

@LoginAsAdmin 
Scenario: All details are mandatory for adding a new product
	When I make a POST request to /addProduct using './Resources/Products/ProductMissingName.json' file
	Then I confirm the response code from /addProduct is 400 Bad Request
	And I confirm /addProduct returns response status 1 with validation message: Toate campurile sunt obligatorii.
	
@LoginAsAdmin 
Scenario: Cannot add a new product with an invalid stock
	When I make a POST request to /addProduct using './Resources/Products/ProductInvalidStock.json' file
	Then I confirm the response code from /addProduct is 400 Bad Request
	And I confirm /addProduct returns response status 1 with validation message: Nu se poate adauga un stoc mai mic sau egal cu 0.	

@LoginAsAdmin 
Scenario: Cannot add a new product with an invalid price
	When I make a POST request to /addProduct using './Resources/Products/ProductInvalidPrice.json' file
	Then I confirm the response code from /addProduct is 400 Bad Request
	And I confirm /addProduct returns response status 1 with validation message: Nu se poate adauga un produs cu un pret mai mic sau egal cu 0 RON.

@LoginAsAdmin @ResetProductName
Scenario: Successfully update product's name
	When I make a POST request to /updateProduct using './Resources/Products/UpdateProductRequest.json' file
	Then I confirm the response code from /updateProduct is 200 OK
	When I make a GET request to /getProducts with the Name=Update Product Test param
	Then I confirm the response code from /getProducts returns the new product's Name - Update Product Test-XYZ

@LoginAsAdmin 
Scenario: Cannot update product to an already existing name
	When I make a POST request to /updateProduct using './Resources/Products/UpdateProductExistingData.json' file
	Then I confirm the response code from /updateProduct is 400 Bad Request
	And I confirm /updateProduct returns response status 1 with validation message: Exista deja un produs cu acest nume.