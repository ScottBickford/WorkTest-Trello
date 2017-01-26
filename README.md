# WorkTest-Trello
A basic integration against Trello using ASP.NET MVC v4.

-------------
Create the DB
-------------

This project writes to an SQL Server Database, in order to run you must create the DB by following the steps below.

- Run the following script: Setup\CreateDB.sql
- Open up the 'web.config' in the 'WorkTestTrello.Website' project and replace the DB credential tags. ie [datasource], [userid], [password]
- Open up the 'app.config' in the 'WorkTestTrello.Website.Tests' project and replace the DB crential tags as above.



-------------------
Running the Project
-------------------
- In Visual Studio, set 'WorkTestTrello.Website' to the startup project



---------------------------
Testing different scenarios
---------------------------
- Browse to the 'WorkTestTrello.Website\Configuration\Test Configurations' folder and find a specific scenario to test
- Copy the content of the test file
- Open 'WorkTestTrello.Website\Configuration\unity.config'
- Replace the relevant section that you copied from the test file.
- Run the solution