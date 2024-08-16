@CompanyManagement
Feature: CompanyManagement
As a Licenta API consumer, I want to be able to manage companies

@NotLoggedIn
Scenario: Cannot access /addCompany or other resources without using a valid user
	When I make a POST request to /addCompany using './Resources/Company/AddNewCompanyRequest.json' file
	Then I confirm the response code from /addCompany is 401 Unauthorized

@LoginAsCustomer
Scenario: Cannot access /addCompany or other resources if logged in as customer
	When I make a POST request to /addCompany using './Resources/Company/AddNewCompanyRequest.json' file
	Then I confirm the response code from /addCompany is 403 Forbidden

@LoginAsAdmin
Scenario: Successfully get all companies
	When I make a GET request to /getCompanies endpoint
	Then I confirm the response code from /getCompanies is 200 OK

@LoginAsAdmin
Scenario: Successfully get company by Name
	When I make a GET request to /getCompanies with the Name=Demo Company param
	Then I confirm the response code from /getCompanies is 200 OK
	And I can confirm Demo Company data is displayed in the result from /getCompanies

@LoginAsAdmin
Scenario: Successfully get company by Id
	When I make a GET request to /getCompanyById with the id=1 param
	Then I confirm the response code from /getCompanyById is 200 OK
	And I can confirm the searched company's data is displayed in the result from /getCompanyById
	
@LoginAsAdmin
Scenario: Validation message is displayed if company is not found by id
	When I make a GET request to /getCompanyById with the id=900 param
	Then I confirm the response code from /getCompanyById is 400 Bad Request
	And I confirm /getCompanyById returns response status 1 with validation message: Compania cautata nu exista.

@LoginAsAdmin @CompanyCleanUp
Scenario: Successfully add a new company
	When I make a POST request to /addCompany using './Resources/Company/AddNewCompanyRequest.json' file
	Then I confirm the response code from /addCompany is 200 OK
	When I make a GET request to /getCompanies with the Name=Company API Test param
	Then I confirm the response code from /getCompanies returns the new company's CUI - 4567801

@LoginAsAdmin
Scenario: Cannot add a new company with an existing name
	When I make a POST request to /addCompany using './Resources/Company/CompanyWithExistingNameRequest.json' file
	Then I confirm the response code from /addCompany is 400 Bad Request
	And I confirm /addCompany returns response status 1 with validation message: Exista deja o companie cu acest nume.

@LoginAsAdmin
Scenario: Both fields are mandatory for adding a new company - missing cui
	When I make a POST request to /addCompany using './Resources/Company/CompanyMissingCui.json' file
	Then I confirm the response code from /addCompany is 400 Bad Request
	And I confirm /addCompany returns response status 1 with validation message: Toate campurile sunt obligatorii.

@LoginAsAdmin
Scenario: Both fields are mandatory for adding a new company - missing name
	When I make a POST request to /addCompany using './Resources/Company/CompanyMissingName.json' file
	Then I confirm the response code from /addCompany is 400 Bad Request
	And I confirm /addCompany returns response status 1 with validation message: Toate campurile sunt obligatorii.


@LoginAsAdmin @ResetCompanyName
Scenario: Successfully update company's name
	When I make a POST request to /updateCompany using './Resources/Company/UpdateCompanyRequest.json' file
	Then I confirm the response code from /updateCompany is 200 OK
	When I make a GET request to /getCompanies with the Name=Update Company Test param
	Then I confirm the response code from /getCompanies returns the new company's Name - Update Company Test-XYZ


@LoginAsAdmin 
Scenario: Cannot update company to an already existing name
	When I make a POST request to /updateCompany using './Resources/Company/UpdateCompanyExistingNameRequest.json' file
	Then I confirm the response code from /updateCompany is 400 Bad Request
	And I confirm /updateCompany returns response status 1 with validation message: Exista deja o companie cu acest nume.
