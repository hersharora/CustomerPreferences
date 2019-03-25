# CustomerPreferences
This is an implementation of a Rest API built using C# .Net Framework 4.6, Entity Framework, and Microsoft SQL server. The solution follows a Code first approach with Entity Framework to create the database. Following is brief details of the different projects in the solution -


Preferences.Models - This project defines the entities for the Entity Framework code first implementation.
Preferences.Data - This is the implementation for the EF code first. The implementation uses to repository pattern with unit of work and factory pattern, provinding a way to easily scale the repsitory and add new ones.
Preferences.DTO - This project contains the business models exposed by the API. Currently there is just one model for CustomerPreference, but as the app scales, there could be separate models for add and update.
Preferences.API - The main API project providing a way to perform basic CRUD operation using EF repositories. Here the endpoints currently implemented - 

###### returns all entities
GET {basePath}/api/customerpreference/ 
###### returns an entity by id
GET {basePath}/api/customerpreference/{id}
###### returns all entities for the provided customerId
GET {basePath}/api/customerpreference/customer/{customerID} 
###### returns an entity by id
GET {basePath}/api/customerpreference/{id}
###### deletes an entity returned by the provided id
DELETE {basePath}/api/customerpreference/{id} 
###### adds an entity
POST {basePath}/api/customerpreference/ 
example content -
content-type: application/json
{
    "CustomerId": 2,
    "Name": "Test3",
    "TemplateId": 2,
    "Repeat": 1,
    "StartDate": "2019-03-02",
    "IsActive": true   
}

TemplateID and Repeat are stored as Ids and map to an enum in background and the enums can be used to get string value for the corresponding int. A better place to store those string values would be the database itself.


NOTE: Though I prefer .Net core to build APIs, this one has been built using .NET Framework in order to ensure this would work incase the test machine doesn't have .Net Core.


### Steps to setup the API -
1) Build the solution CustomerPreferences.sln either using MSBuild or through Visual Studio.
2) Create the database for Api through following steps:
    a. Set up the connection string to connect to a database -
        The current connection string in Web.Config of Preferences.API project is set to connect to local instance of SQL server with default database set to Shoelace. This can be changed by modifying the connectionString in Web.config.
        <connectionStrings>
            <add name="PreferenceConnection" connectionString="Data Source=(local); Initial Catalog=Shoelace; MultipleActiveResultSets=True; " providerName="System.Data.SqlClient" />
        </connectionStrings>
        You might also need to provide the credentials for your SQL server instance. In that scenario, modify the connection string as follows by substituting values with actial userId and password:
            <add name="PreferenceConnection" connectionString="Data Source=(local); Initial Catalog=Shoelace; User ID=[userID]; Password=[password]; MultipleActiveResultSets=True; " providerName="System.Data.SqlClient" />
    b. Open the Package Manager Console window through Tools > Nuget Package Manager > Package Manager Console.
    c. Select project Preferences.Data in the Default Project dropdown.
    d. Run the command "Update-Database" in the console. This would run in the EF code first migration. Alternatively, you can run MigrationQuery.sql in Preferences.Data\SQLScript folder. Note: Running the Update-Database command is preferred.
3) Setup the API in Preference.API project. This can be done either through running the IIS express through visual studio. The IIS express is configured to run at port 3980. Then the api could be accessed at http://localhost:3980/, Alternatively, set up a website in IIS, set the physical directory to Preferences.API project path and bind it to a desired port. NOTE: The default page at http://localhost:3980 would through an error since it not setup to return anything, and directory browsing is not enabled.
4) Access the API through desired api testing tool (eg: Postman)
