using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Empty()
    {
        //Arrange 
        string firstName = "John";
        string lastName = "";
        string email = "john@Doe.pl";
        DateTime dateTime = new DateTime(1980, 1, 1);
        int clientId = 1;
        UserService userService = new UserService();
        //Act
        bool result = userService.AddUser(firstName, lastName, email, dateTime, clientId);
        //Assert
        //Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange 
        string firstName = "John";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        string email = "doeee";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);

        //Assert
        //Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Under_Restricted21()
    {
        //Arrange 
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@Doe.pl";
        DateTime dateTime = new DateTime(2018, 1, 1);
        int clientId = 1;
        UserService userService = new UserService();
        //Act
        bool result = userService.AddUser(firstName, lastName, email, dateTime, clientId);
        //Assert
        //Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Throw_ArgumentException_When_Client_Doesnt_Exist()
    {
        //Arrange
        var userService = new UserService();
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@Doe.pl";
        DateTime dateTime = new DateTime(1980, 1, 1);
        int clientId = 0;

        //Act && Assert
        Assert.Throws<ArgumentException>(() => { userService.AddUser(firstName, lastName, email, dateTime, -1); });
    }

     [Fact]
     public void AddUser_Should_Return_False_When_Client_Credit_Is_Below_Restricted_And_Has_Credit_Limit()
     {
         //ARRANGE
         string firstName = "John";
         string lastName = "Kowalski";
         string email = "john@Doe.pl";
         DateTime dateTime = new DateTime(1980, 1, 1);
         int clientId = 1;
    
         UserService userService = new UserService();
         
         //ACT
         bool result = userService.AddUser(firstName, lastName, email, dateTime, 1);
         
         //assert
         Assert.False(result);
     }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Client_Is_Very_Important()
    {
        //ARRANGE
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@Doe.pl";
        DateTime dateTime = new DateTime(1980, 1, 1);
        int clientId = 2;
        
        UserService userService = new UserService();
        
        //ACT
        bool result = userService.AddUser(firstName, lastName, email, dateTime, clientId);
    
        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Client_Is_Important_And_Has_Valid_Credit_Limit()
    {
        //ARRANGE
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@Doe.pl";
        DateTime dateTime = new DateTime(1980, 1, 1);
        int clientId = 4;

        // UserService userService = new UserService(new FakeClientRepository(new Client
        // {
        //     Type = "ImportantClient"
        // }), new FakeUserCreditService(600));
        
        //ACT
        UserService userService = new UserService();
        bool result = userService.AddUser(firstName, lastName, email, dateTime, clientId);
    
        //assert
        Assert.True(result);
    }
    
}