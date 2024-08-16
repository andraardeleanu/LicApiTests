@UserManagement
Feature: UserManagement
As a Licenta API consumer, I want to be able to manage users

@NotLoggedIn
Scenario: Cannot access /getUser or other resources without using a valid user
	When I make a GET request to /getUser endpoint
	Then I confirm the response code from /getUser is 401 Unauthorized

@LoginAsCustomer
Scenario: Cannot access /register resource if logged in as customer
	When I make a POST request to /register using './Resources/User/Register.json' file
	Then I confirm the response code from /register is 403 Forbidden

@LoginAsAdmin
Scenario: Successfully get all users
	When I make a GET request to /getUsers endpoint
	Then I confirm the response code from /getUsers is 200 OK

@LoginAsCustomer
Scenario: Successfully get loged in user
	When I make a GET request to /getUser endpoint
	Then I confirm the response code from /getUser is 200 OK
	And I can confirm Andra Donca user is displayed in the result from /getUser

@LoginAsAdmin
Scenario: Successfully get user by username
	When I make a GET request to /getUserByUsername with the username=custone param
	Then I confirm the response code from /getUserByUsername is 200 OK
	And I can confirm Andra Donca user is displayed in the result from /getUserByUsername

@LoginAsAdmin @UserCleanUp
Scenario: Successfully register a new user
	When I make a POST request to /register using './Resources/User/Register.json' file
	Then I confirm the response code from /register is 200 OK
	When I make a GET request to /getUserByUsername with the username=userapitest param
	Then I confirm the response code from /getUserByUsername is 200 OK
	And I confirm the response code from /getUserByUsername returns the new user with username - userapitest

@LoginAsAdmin 
Scenario: Cannot register a new user with an already existing username
	When I make a POST request to /register using './Resources/User/RegisterExistingUsername.json' file
	Then I confirm the response code from /register is 400 Bad Request
	And I confirm /register returns response status 1 with validation message: Exista deja un client cu acest usernume.
	
@LoginAsAdmin 
Scenario: Cannot register a new user with any empty data
	When I make a POST request to /register using './Resources/User/RegisterEmptyUserData.json' file
	Then I confirm the response code from /register is 400 Bad Request
	And I confirm /register returns response status 1 with validation message: Toate campurile sunt obligatorii.

@LoginAsAdmin 
Scenario: Cannot register a new user without selecting a valid company
	When I make a POST request to /register using './Resources/User/RegisterInvalidCompany.json' file
	Then I confirm the response code from /register is 400 Bad Request
	And I confirm /register returns response status 1 with validation message: Nu ai selectat compania noului user. Daca este o companie noua, o poti crea din tab-ul Companii.

@LoginAsAdmin @ResetFirstname
Scenario: Successfully update user
	When I make a POST request to /updateCustomer using './Resources/User/UpdateCustomerData.json' file
	Then I confirm the response code from /updateCustomer is 200 OK
	When I make a GET request to /getUserByUsername with the username=userToBeUpdated param
	Then I confirm the response code from /getUserByUsername returns the new user's firstname - Updated

@Ignore @Manual
Scenario: Successfully update password for a new user
	When I make a POST request to /register using './Resources/User/Register.json' file
	Then I confirm the response code from /register is 200 OK
	When I make a GET request to /getUserByUsername with the username=userapitest param
	Then I confirm the response code from /getUserByUsername is 200 OK
	And I confirm the response code from /getUserByUsername returns the new user with username - userapitest
	When I make a PATCH request to /changePassword using './Resources/User/ChangePassword.json' file
	Then I confirm the response code from /changePassword is 200 OK