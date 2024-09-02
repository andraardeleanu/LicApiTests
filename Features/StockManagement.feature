@StockManagement
Feature: StockManagement
As a Licenta API consumer, I want to be able to manage stocks

@LoginAsAdmin
Scenario: Successfully get all stocks
	When I make a GET request to /getStocks endpoint
	Then I confirm the response code from /getStocks is 200 OK

@LoginAsAdmin
Scenario: Successfully get stock by product name
	When I make a GET request to /getStocks with the Name=Stock Test API param
	Then I confirm the response code from /getStocks is 200 OK
	And I can confirm stock for Product Demo 1 data is displayed in the result from /getStocks

@LoginAsAdmin
Scenario: Successfully get stock by id
	When I make a GET request to /getStockById with the id=5 param
	Then I confirm the response code from /getStockById is 200 OK
	And I can confirm searched stock data is displayed in the result from /getStockById

@LoginAsAdmin
Scenario: Successfully get stock by product id
	When I make a GET request to /getStockByProductId with the productId=5 param
	Then I confirm the response code from /getStockByProductId is 200 OK
	And I can confirm searched product returns the expected stock /getStockByProductId

@LoginAsAdmin @OrderProductsReset
Scenario: Successfully update stock
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /updateStock using './Resources/Stock/UpdateStock.json' file
	Then I confirm the response code from /updateStock is 200 OK
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 1000, Pending stock = 7

@LoginAsCustomer
Scenario: Only admin is authorized to update stock
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7
	When I make a POST request to /updateStock using './Resources/Stock/UpdateStock.json' file
	Then I confirm the response code from /updateStock is 403 Forbidden
	When I make a GET request to /getStockByProductId with the productId=1 param
	Then I confirm /getStockByProductId returns the correct stock data for productId - 1: Available stock = 5000, Pending stock = 7