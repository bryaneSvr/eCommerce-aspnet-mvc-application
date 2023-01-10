Prerequisite
1. dotNet Core 7.0.1 - https://dotnet.microsoft.com/en-us/download/dotnet/7.0
2. SQLServer 2019 - https://www.microsoft.com/en-in/sql-server/sql-server-downloads
3. SQL Server Management Studio 2018 - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
4. Visual Studio 2022 -  https://visualstudio.microsoft.com/vs/community/
5. Any Browser - (Google Crome recommended)

Steps to Launch the site:
1. Download the codebase from the git repository : https://github.com/bryaneSvr/eCommerce-aspnet-mvc-application
2. Download database from git : https://github.com/bryaneSvr/eCommerce-aspnet-mvc-application/tree/master/Database_Backup
3. Restore the database Backup using SSMS (Prerequisite - 2) and add the SQL server name to the data source of DefaultConnectionString in appsettings.json
4. Open the DemoStore.sln In Visual Studio 
5. Set the following configurations in tool bar
	a. Solution Configuration : Debug or Release
	b. Solution Platform : Any CPU
	c. Profiles : IIS Express

That's it. launch the application (ctrl+F5) from Visual Studio 2022 and it should work!


Login Details : 
GeneralUser Login  
1. Admin - Email address : demostoreadmin@gmail.com
		 - Password : Demostore@1
2. User  - Email address : demostoreuser@gmail.com
		 - Password : Demostore@1
GoogleUser Login  
1. Admin - Email address : demostoreadmn@gmail.com
		 - Password : Demostore@1
2. User  - Email address : demostoreusr@gmail.com
		 - Password : DemoStoreUser@1
