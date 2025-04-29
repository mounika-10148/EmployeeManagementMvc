using CrudDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


public class UserRepository
{
    private readonly IConfiguration _config;

    public UserRepository(IConfiguration config)
    {
        _config = config;
    }

    private IDbConnection Connection =>
        new SqlConnection(_config.GetConnectionString("DefaultConnection")); // No changes needed here except namespace

    public IEnumerable<User> GetAll() =>
        Connection.Query<User>("SELECT * FROM Users");

    public User GetById(int id) =>
        Connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });

    public void Add(User user) =>
        Connection.Execute("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", user);

    public void Update(User user) =>
        Connection.Execute("UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id", user);

    public void Delete(int id) =>
        Connection.Execute("DELETE FROM Users WHERE Id = @Id", new { Id = id });

    public User Details(int id)
    {
        using var connection = Connection;
        var user = connection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });

        return user; // Return the user object for further processing in Razor Pages
    }
}

