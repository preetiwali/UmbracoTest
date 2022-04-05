# Umbraco

# Steps to run the .NET Umbraco Application.

1. Restore the UmbracoTest_DB 
 -	Created a security  login user for the TestDB.
 -	Credentials : 
    -	Userid = UmbracoTest
    -	Password = test@123
 -	Connection String in web.config file (Replace with your server name and userid, password)
 -	connectionString="server=LAPTOP-HU8SA2JG\SQLEXPRESS;database=UmbracoTest_DB;user id=UmbracoTest;password=test@123"

2. Umbraco Install (Nuget Package)
  -	Installed the nuget package – Umbraco CMS
  -	Run IIS Express
  -	You will be redirected to Install Umbraco 
  -	Enter the credentials
  -	Choose MSSQL Server and enter the Database credentials as well
  -	Connect the database
  -	My Credentials: 
      -	Umbraco login: user id – preetiwali212@gmail.com
      -	Password: 1234567890
3. Run the solution
  -	Clean the solution file and rebuild it.
  -	Run IIS Express
  -	The Test Umbraco Website should be up and running

4. Email Functionality – Contact us form
The form contains:
  -	The google map location for the office.
  -	Form to get the details of the potential customers.
  -	Once all the required fields are entered, click the submit button.
  -	An email will be sent to the email address entered in the form with a random token number generated for your enquiry.
  -	All the entered form details/customer details will be stored in the database.
