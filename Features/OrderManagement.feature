@OrderManagement
Feature: OrderManagement
As a Licenta API consumer, I want to be able to manage products

@NotLoggedIn
Scenario: Cannot access /addOrder or other resources without using a valid user
	When I make a POST request to /addOrder using './Resources/Orders/AddNewManualOrderRequest.json' file
	Then I confirm the response code from /addOrder is 401 Unauthorized

@LoginAsAdmin
Scenario: Successfully get all orders
	When I make a GET request to /getOrders endpoint
	Then I confirm the response code from /getOrders is 200 OK

@LoginAsAdmin
Scenario: Successfully get orders by id
	When I make a GET request to /getOrders with the Id=1 param
	Then I confirm the response code from /getOrders is 200 OK
	And Order searched by id is displayed displayed in the result from /getOrders
	
@LoginAsAdmin
Scenario: Successfully get orders by orderNo
	When I make a GET request to /getOrders with the OrderNo=2bf92285-b09b-4e04-a5b3-3dc5c27baadb param
	Then I confirm the response code from /getOrders is 200 OK
	And Order searched by id is displayed displayed in the result from /getOrders

@LoginAsAdmin
Scenario: Successfully get orders by workpoint id
	When I make a GET request to /getOrders with the WorkpointId=1 param
	Then I confirm the response code from /getOrders is 200 OK
	And Order searched by id is displayed displayed in the result from /getOrders

@LoginAsAdmin
Scenario: Successfully get orders by workpoint id and status
	When I make a GET request to /getOrders with the WorkpointId=1 & Status=Initializata param
	Then I confirm the response code from /getOrders is 200 OK
	And Order searched by id is displayed displayed in the result from /getOrders

@LoginAsAdmin
Scenario: Successfully get orders by order id and status
	When I make a GET request to /getOrders with the Id=1 & Status=Initializata param
	Then I confirm the response code from /getOrders is 200 OK
	And Order searched by id is displayed displayed in the result from /getOrders

@LoginAsCustomer @OrderProductsReset @OrderCleanUp 
Scenario: Successfully add new manual order using valid data
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/AddNewManualOrderRequest.json' file
	Then I confirm the response code from /addOrder is 200 OK
	And I confirm the response code from /addOrder returns the new order's OrderNo
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 4850, Pending stock = 157

@LoginAsCustomer
Scenario: Cannot add orders with duplicated products
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrderDuplicatedProducts.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Au fost identificate produse duplicate. Te rog sa revizuiesti comanda.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7

@LoginAsCustomer
Scenario: Cannot add orders without the product lists
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrdersNoProducts.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Nu ai selectat niciun produs pentru comanda.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7

@LoginAsCustomer
Scenario: Cannot add orders with an invalid workpoint
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrdersInvalidWorkpoint.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Nu ai selectat punctul de lucru pentru noua comanda. Daca este un punct de lucru nou, il poti crea din tab-ul Puncte de lucru.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7

@LoginAsCustomer
Scenario: Cannot add orders with invalid quanitites of products
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrderInvalidQuantity.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Cantitatea setata pentru unul sau mai multe produse este invalida.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7

@LoginAsCustomer
Scenario: Cannot add orders if product's quantity is not enough
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrderNotEnoughQuantity.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Verifica stocul disponibil pentru produsele din comanda.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	
@LoginAsCustomer
Scenario: Cannot add orders if there are invalid products
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/ManualOrderInvalidProduct.json' file
	Then I confirm the response code from /addOrder is 400 Bad Request
	And I confirm /addOrder returns response status 1 with validation message: Produsul cautat nu exista.
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
			
@LoginAsCustomer @OrderProductsReset @OrderCleanUp 
Scenario: Only admin can update order status to Procesata
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/AddNewManualOrderRequest.json' file
	Then I confirm the response code from /addOrder is 200 OK
	And I confirm the response code from /addOrder returns the new order id Id and OrderNo
	When I make a POST request to /updateOrderStatus for the order with Id param
	Then I confirm the response code from /updateOrderStatus is 403 Forbidden

@LoginAsAdmin
Scenario: Successfully get order details
	When I make a GET request to /getOrderDetails with the orderId=1 param
	Then I confirm the response code from /getOrderDetails is 200 OK
	And I can confirm the searched order's details are displayed in the result from /getOrderDetails

