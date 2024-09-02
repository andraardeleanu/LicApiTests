@BillManagement
Feature: BillManagement
As a Licenta API consumer, I want to be able to manage bills

@NotLoggedIn
Scenario: Cannot access /getBills or other resources without using a valid user
	When I make a GET request to /getBills endpoint
	Then I confirm the response code from /getBills is 401 Unauthorized

@LoginAsAdmin
Scenario: Successfully get all bills
	When I make a GET request to /getBills endpoint
	Then I confirm the response code from /getBills is 200 OK

@LoginAsAdmin
Scenario: Successfully get details for bills
	When I make a GET request to /getBillDetails with the orderId=1 param
	Then I confirm the response code from /getBillDetails is 200 OK
	And I can confirm bill details for the selected orderId are displayed in the result from /getBillDetails
	
@LoginAsAdmin @OrderCleanUp @OrderProductsReset @BillCleanUp
Scenario: Successfully generate bill for processed order
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/AddNewManualOrderRequest.json' file
	Then I confirm the response code from /addOrder is 200 OK
	And I confirm the response code from /addOrder returns the new order id Id and OrderNo
	When I make a POST request to /updateOrderStatus for the order with Id param
	Then I confirm the response code from /updateOrderStatus is 200 OK
	When I make a POST request to /billGenerator for the order bill with OrderNo param
	Then I confirm the response code from /billGenerator is 200 OK
	And I confirm /getBillDetails returns the bill for the new Id, OrderNo and Status - Facturata
	
@LoginAsAdmin @OrderCleanUp @OrderProductsReset @BillCleanUp
Scenario: Cannot generate bill for initialized order
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /addOrder using './Resources/Orders/AddNewManualOrderRequest.json' file
	Then I confirm the response code from /addOrder is 200 OK
	And I confirm the response code from /addOrder returns the new order id Id and OrderNo
	When I make a POST request to /billGenerator for the order bill with OrderNo param
	Then I confirm the response code from /billGenerator is 400 Bad Request
	And I confirm /billGenerator returns response status 1 with validation message: Facturile se pot genera doar pentru comenzile in status Procesata.
