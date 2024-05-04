@WorkpointManagement
Feature: WorkpointManagement
As a Licenta API consumer, I want to be able to manage workpoints

@NotLoggedIn
Scenario: Cannot access /addWorkpoint or other resources without using a valid user
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/AddNewWorkpointRequest.json' file
	Then I confirm the response code from /addWorkpoint is 401 Unauthorized

@LoginAsAdmin
Scenario: Successfully get all workpoints
	When I make a GET request to /getWorkpoints endpoint
	Then I confirm the response code from /getWorkpoints is 200 OK

@LoginAsAdmin
Scenario: Successfully get workpoint by name
	When I make a GET request to /getWorkpoints with the Name=Demo Workpoint param
	Then I confirm the response code from /getWorkpoints is 200 OK
	And I can confirm the searched workpoint's data is displayed in the result from /getWorkpoints
	
@LoginAsAdmin
Scenario: Successfully get workpoint by id
	When I make a GET request to /getWorkpointById with the Id=59 param
	Then I confirm the response code from /getWorkpointById is 200 OK
	And I can confirm the workpoint's 59 data is displayed in the result from /getWorkpointById

@LoginAsAdmin
Scenario: Validation message is displayed if workpoint is not found by id
	When I make a GET request to /getWorkpointById with the Id=900 param
	Then I confirm the response code from /getWorkpointById is 400 Bad Request
	And I confirm /getWorkpointById returns response status 1 with validation message: Punctul de lucru cautat nu exista.

@LoginAsAdmin
Scenario: Successfully get workpoint by user id
	When I make a GET request to /getWorkpointsByUserId with the UserId=549f6812-5753-4442-903c-e52e696ba5c2 param
	Then I confirm the response code from /getWorkpointsByUserId is 200 OK
	And I can confirm the searched user's workpoints are displayed in the result from /getWorkpointsByUserId

@LoginAsAdmin
Scenario: Successfully get workpoint by company id
	When I make a GET request to /getWorkpointsFromCompany with the companyId=2 param
	Then I confirm the response code from /getWorkpointsFromCompany is 200 OK
	And I can confirm the searched company's workpoints are displayed in the result from /getWorkpointsFromCompany

@LoginAsAdmin @WorkpointCleanUp
Scenario: Successfully add a new workpoint
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/AddNewWorkpointRequest.json' file
	Then I confirm the response code from /addWorkpoint is 200 OK
	When I make a GET request to /getWorkpoints with the Name=Workpoint API Test param
	Then I confirm the response code from /getWorkpoints returns the new workpoint's Name - Workpoint API Test

@LoginAsAdmin
Scenario: Cannot add a new workpoint with an existing name and address
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/AddNewWorkpointExistingData.json' file
	Then I confirm the response code from /addWorkpoint is 400 Bad Request
	And I confirm /addWorkpoint returns response status 1 with validation message: Exista deja un punct de lucru cu acest nume si adresa.

@LoginAsAdmin
Scenario: All fields are mandatory for adding a new workpoint - name
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/WorkpointMissingName.json' file
	Then I confirm the response code from /addWorkpoint is 400 Bad Request
	And I confirm /addWorkpoint returns response status 1 with validation message: Toate campurile sunt obligatorii.

@LoginAsAdmin
Scenario: All fields are mandatory for adding a new workpoint - address
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/WorkpointMissingAddress.json' file
	Then I confirm the response code from /addWorkpoint is 400 Bad Request
	And I confirm /addWorkpoint returns response status 1 with validation message: Toate campurile sunt obligatorii.

@LoginAsAdmin @ResetWorkpoint
Scenario: Successfully update workpoint's name
	When I make a POST request to /updateWorkpoint using './Resources/Workpoints/UpdateWorkpointRequest.json' file
	Then I confirm the response code from /updateWorkpoint is 200 OK
	When I make a GET request to /getWorkpoints with the Name=Update Workpoint Test param
	Then I confirm the response code from /getWorkpoints returns the new workpoint's Name - Update Workpoint Test-XYZ

@LoginAsAdmin
Scenario: Cannot update workpoint to an already existing name and address
	When I make a POST request to /updateWorkpoint using './Resources/Workpoints/UpdateWorkpointExistingData.json' file
	Then I confirm the response code from /updateWorkpoint is 400 Bad Request
	And I confirm /updateWorkpoint returns response status 1 with validation message: Exista deja un punct de lucru cu acest nume si adresa.

@LoginAsAdmin
Scenario: Successfully remove workpoint
	When I make a POST request to /addWorkpoint using './Resources/Workpoints/AddNewWorkpointRequest.json' file
	Then I confirm the response code from /addWorkpoint is 200 OK
	When I make a GET request to /getWorkpoints with the Name=Workpoint API Test param
	Then I confirm the response code from /getWorkpoints returns the newly added workpoint's Id
	When I make a POST request to /removeWorkpoint with the Id param to delete the recently added workpoint
	Then I confirm the response code from /removeWorkpoint is 200 OK
	And I confirm /getWorkpoints doesn't return the recently added workpoint - Workpoint API Test

@LoginAsAdmin
Scenario: Cannot remove workpoints that have orders assigned to them
	When I make a GET request to /getWorkpoints with the Name=Demo Workpoint param
	Then I confirm the response code from /getWorkpoints returns the newly added workpoint's Id
	When I make a POST request to /removeWorkpoint with the Id param to delete the recently added workpoint
	Then I confirm the response code from /removeWorkpoint is 400 Bad Request
	And I confirm /removeWorkpoint returns response status 1 with validation message: Nu se pot sterge punctele de lucru pe care exista comenzi.
