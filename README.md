


# Pierre's Sweet and Savory Treats

##### Date: **06/22/2021**

#### By **_Salim Mayan_**

## Description

#### An MVC app built with _Authentication with Identity_ to help Pierre manage _Treats_ and  _Flavors_.  _Pierre_ is allowed to add a list of Treats, a list of Flavors, and specify which Treats come with which flavors (implementation of many-to-many relationship between `Treat`s and `Flavor`s). 

### Implemented User Stories

-   Application has user authentication (register/Log-in) and also includes ability to log in and log out. 
-   Only logged in users have create, update and delete functionality while all users have read functionality
-   User can  navigate to a splash page that lists all treats and flavors. User can click on an individual treat or flavor to see all the treats/flavors that belong to it.
-   There exist a many-to-many relationship between  `Treat`s and  `Flavor`s. -   

## Setup/Installation Requirements

1. Clone this repository from GitHub using `git clone https://github.com/salimmayan/PierresSweetAndSavoryTreats.Solution`

2. Open directory `PierresSweetAndSavoryTreats.Solution` in VS Code

3. To install packages listed in `.csproj` file, from command line navigate to `PierresSweetAndSavoryTreats`  directory and then run  `dotnet restore` (**'obj'** directory would get created in `PierresSweetAndSavoryTreats` directory)

4. To create internal content for build, from command line navigate to `PierresSweetAndSavoryTreats`  directory and then run  `dotnet build` (**'bin'** directory would get created in `PierresSweetAndSavoryTreats`  directory)
5. Create `appsettings.json` file (in path `PierresSweetAndSavoryTreats\appsettings.json`) and add below lines (replace [PASSWORD] with your chosen password)

```{
	"Logging": {
		"LogLevel": {
			"Default": "Warning",
			"System": "Information",
			"Microsoft": "Information"
		}
	},
	"AllowedHosts": "*",
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost;Port=3306;database=salim_mayan;uid=root;pwd=[PASSWORD];"
	}
}```

```

6. **Re-create Database with MySQL Workbench Migration Functionality**:  From command line navigate to `PierresSweetAndSavoryTreats`  directory and execute below command  
	-   		dotnet ef database update
    
   *Note*: In _MySQL Workbench_ Reopen the  _Navigator_  >  _Schemas_  tab. Right click and select  _Refresh All_ (new database will appear with the name "salim_mayan".

7. **Execute Application:** Navigate to `PierresSweetAndSavoryTreats` directory and enter `dotnet run`

8. In Browser enter URL `http://localhost:5000` to access application

⚠️  *Note*: To run project locally you need to have .NET Core (confirm running of .NET Core using command `dotnet --version` in command line)



| **Spec** |
## Running Tests:

-  Tests are not applicable for this application

## Known Bugs

* No Known bugs

## Improvement opportunities

* None

## Technologies Used

-   C# 9
-   ASP.NET MVC
-   .NET Core v5.0
-   Razor View Engine
-   RESTful Routing
-   CRUD & HTTP
-   Bootstrap
-   REPL
-   Git and GitHub
-   Entity Framework Core

## Support and contact details

* For questions, comments, or concerns *[email author](mailto:mailsalim@gmail.com?subject=[GitHub])*


### License

*{This software is licensed under the MIT license}*

Copyright (c) 2021 **_{Salim Mayan}_**