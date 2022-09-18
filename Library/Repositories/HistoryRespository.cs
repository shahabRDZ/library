using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Library.Models;
using Microsoft.Data.SqlClient;
namespace Library.Repositories;

public class HistoryRepository
{
    private readonly Database _database;

    public HistoryRepository()
    {
        _database = new Database();
    }
    public void Insert(History history)
    {
        const string insertCmd =
            @"INSERT INTO [history] ([memberID],[bookID],[loandate],[returndate],[duedate]) VALUES (@memberID , @bookID , @loandate , @returndate , @duedate)";
        var command = new SqlCommand(insertCmd, _database.Connection);
        
        command.Parameters.AddWithValue("memberID", history.memberID);
        command.Parameters.AddWithValue("bookID", history.bookID);
        command.Parameters.AddWithValue("loandate", history.loandate);
        command.Parameters.AddWithValue("returndate", history.returndate);
        command.Parameters.AddWithValue("duedate", history.duedate);
        command.ExecuteNonQuery();
    }
    
    public void Update(History history)
    {
        var command = new SqlCommand("UPDATE [History] SET [memberID] =@memberID,[bookID]=@bookID , [returndate] =@returndate ,[duedate]= @duedate , [loandate]= @loandate  + WHERE [Id] = @Id"
            , _database.Connection);
        command.Parameters.AddWithValue("Id", history.Id);
        command.Parameters.AddWithValue("memberID", history.memberID);
        command.Parameters.AddWithValue("bookID", history.bookID);
        command.Parameters.AddWithValue("loandate", history.loandate);
        command.Parameters.AddWithValue("returndate", history.returndate);
        command.Parameters.AddWithValue("duedate", history.duedate);
        command.ExecuteNonQuery();
     
    }
    public void Delete (History history)
    {
        var command = new SqlCommand("DELETE FROM [History] WHERE Id = @Id", _database.Connection);
        command.Parameters.AddWithValue("Id", history.Id);
        command.ExecuteNonQuery();
    }
    public IList<History> SelectAll()
    {
        var result = new List<History>();
        var command = new SqlCommand("SELECT * FROM [History]", _database.Connection);
        var reader = command.ExecuteReader();
        
        
        while (reader.Read())
        {
            var item = new History
            {
                Id = Convert.ToInt32(reader["Id"].ToString()),
                memberID = Convert.ToInt32(reader["memberID"].ToString()),
                bookID = Convert.ToInt32(reader["bookID"].ToString()),
                loandate = Convert.ToInt32(reader ["loandate"].ToString()),
                returndate = Convert.ToInt32(reader["returndate"].ToString()),
                duedate = Convert.ToInt32(reader["duedate"].ToString())
            };
            
            result.Add(item);
        }

        return result;
    }
    
    public History GetById(int Id)
    {
        var command = new SqlCommand("SELECT * FROM [History] WHERE [Id] = @Id", _database.Connection);
        command.Parameters.AddWithValue("Id", Id);
        var reader = command.ExecuteReader();
        if (reader.Read())

        {
            return FromReader(reader);
        }

        return null;
    }
    
    private History FromReader(SqlDataReader reader)
    {
        return new History
        {

            Id = Convert.ToInt32(reader["Id"].ToString()),
            memberID = Convert.ToInt32(reader["memberID"].ToString()),
            bookID = Convert.ToInt32(reader["bookID"].ToString()),
            loandate = Convert.ToInt32(reader["loandate"].ToString()),
            returndate = Convert.ToInt32(reader["returndate"].ToString()),
            duedate = Convert.ToInt32(reader["duedate"].ToString())
        };

    }
    

}