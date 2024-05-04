@StockManagement
Feature: StockManagement
As a Licenta API consumer, I want to be able to manage stocks

@LoginAsAdmin
Scenario: Successfully get all stocks
	When I make a GET request to /getStocks endpoint
	Then I confirm the response code from /getStocks is 200 OK

@LoginAsAdmin
Scenario: Successfully get stock by product name
	When I make a GET request to /getStocks with the Name=Stock Test Api param
	Then I confirm the response code from /getStocks is 200 OK
	And I can confirm stock for Product Demo 1 data is displayed in the result from /getStocks

@LoginAsAdmin
Scenario: Successfully get stock by id
	When I make a GET request to /getStockById with the id=34 param
	Then I confirm the response code from /getStockById is 200 OK
	And I can confirm searched stock data is displayed in the result from /getStockById

@LoginAsAdmin
Scenario: Successfully get stock by product id
	When I make a GET request to /getStockByProductId with the productId=61 param
	Then I confirm the response code from /getStockByProductId is 200 OK
	And I can confirm searched product returns the expected stock /getStockByProductId