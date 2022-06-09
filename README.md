To Open the project must first create database.
then should add this command on package manager.
 <code>Scaffold-DbContext "Server=.\LOCAL_SERVER;User ID=YOUR_DB_USER;Password=YOUR_DB_PASSWORD;Database=YOUR_DATABASE;Trusted_Connection=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models</code>
 (Please add name of your database on command).
 Then add this command: 
 add-migration Init. 


 update-database
 
 Done .....
