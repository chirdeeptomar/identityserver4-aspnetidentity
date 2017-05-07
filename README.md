# identityserver4-aspnetidentity
Identity Server 4 with ASP.net Identity

This code used Postgres for storage, please make appropriate changes for SqlServer in ConfigureServices method.

Register User:

POST  http://localhost:5000/api/accounts/
{
	"email": "hello@test.com",
	"password": "Sample123!!"
}

Login User:

username:hello@test.com
password:Sample123!!
scope:api.location
grant_type:password
client_id:client
client_secret:secret
