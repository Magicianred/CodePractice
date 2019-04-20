# ToDoMVC

is a simple Asp .net MVC to show how using UnitTest

## Teory

- ToDoMVC.Interfaces
  - No projects reference  

This's project to manage domain interfaces and class to connect all projects

- ToDoMVC.DAL.EF (Database layer)
  - ToDoMVC.Interfaces (reference)  

This's project to manage access to Database DBLocal

- ToDoMVC.BL (Business logic layer)
  - ToDoMVC.Interfaces (reference)  

This's project to manage business logic of application (no direct access to DAL and EntityFramework ddl, only throw UnitOfWork)

- ToDoMVC (Presentation layer)
  - ToDoMVC.Interfaces (reference)
  - ToDoMVC.BL (reference)

This is a MVC Web Application (no direct access to DAL and EntityFramework ddl, only throw UnitOfWork)
__(now at runtime require EntityFramework ddl, to fix)__

- ToDoMVC.DAL.EF.Fake
  - ToDoMVC.Interfaces (reference)

This project substitute DAL.EF access with a in memory data repository for test

- ToDoMVC.UnitTest.MVC
  - ToDoMVC.Interfaces (reference)
  - ToDoMVC.DAL.EF.Fake (reference)
  - ToDoMVC.BL (reference)
  - ToDoMVC (reference)

This is a project where unit test live
  
- ToDoMVC.UnitTest.BL
  - ToDoMVC.Interfaces (reference)
  - ToDoMVC.DAL.EF.Fake (reference)
  - ToDoMVC.BL (reference)

This is a project where unit test live

## Create Project Setup (to complete)

- Create New Project in Visual Studio
  - Select Asp .Net Web Application (.NET Framework)
    - Select *.NET Framework 4.6.1*
    - Select *MVC* template
    - Select *No Authentication*
    - Name it *ToDoMVC*, it will our presentation layer
    - Click Ok
  - In *Solution Explorer* right button
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *Infrastructure*, it will our domain model layer
      - Remove file *Class1.cs*
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *DAL.EF.Fake*, it will our data layer, it should to be an Entity Framework or other Database ORM, now it will a InMemory repository
      - Remove file *Class1.cs*
      - on *Package Manager Console*
        - Select default project *DAL* and add:
          - install-package EntityFramework
      - Add Reference to project *Infrastructure*
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *DAL.EF*, it will our data layer
      - Remove file *Class1.cs*
      - on *Package Manager Console*
        - Select default project *DAL.EF* and add:
          - install-package EntityFramework
          - Enable-Migrations
      - Add Reference to project *Infrastructure*
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *BL*, it will our business logic layer
      - Remove file *Class1.cs*
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *UnitTest.BL*, it will our unit test layer for BL layer
      - Remove file *Class1.cs*
      - on *Package Manager Console*
        - Select default project *UnitTest* and add:
          - install-package NUnit
          - install-package NUnit3TestAdapter
    - on Solution element -> Add New Project
      - Select *Class Library (.NET Framework)
      - Name it *UnitTest.MVC*, it will our unit test layer for presentation layer
      - Remove file *Class1.cs*
      - on *Package Manager Console*
        - Select default project *UnitTest* and add:
          - install-package NUnit
          - install-package NUnit3TestAdapter