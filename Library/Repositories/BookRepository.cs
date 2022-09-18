using Library.Models;
using Microsoft.Data.SqlClient;

namespace Library.Repositories;

public class BookRepository
{
    private readonly Database _database;

    public BookRepository()
    {
        _database = new Database();
    }


    public void Insert(BOOK book)
    {
        const string insertCmd =
            @"INSERT INTO [book] ([ISBN],[title],[Author],[publishyear],[category]) VALUES (@ISBN,@title,@Author,@publishyear,@category)";
        var command = new SqlCommand(insertCmd, _database.Connection);

        command.Parameters.AddWithValue("ISBN", book.ISBN);
        command.Parameters.AddWithValue("Author", book.Author);
        command.Parameters.AddWithValue("publishyear", book.publishyear);
        command.Parameters.AddWithValue("title", book.Title);
        command.Parameters.AddWithValue("category", book.category);
        command.ExecuteNonQuery();
    }

    public void Update(BOOK book)
    {
        var command = new SqlCommand(
            "UPDATE [BOOK] SET  [ISBN]=@ISBN , [Author] =@Author ,[publishyear]=@publishyear  ,[title]=@title ,[category]=@category  WHERE [bookID] = @bookID",
            _database.Connection);

        command.Parameters.AddWithValue("bookID", book.BookID);
        command.Parameters.AddWithValue("ISBN", book.ISBN);
        command.Parameters.AddWithValue("Author", book.Author);
        command.Parameters.AddWithValue("publishyear", book.publishyear);
        command.Parameters.AddWithValue("title", book.Title);
        command.Parameters.AddWithValue("category", book.category);
        command.ExecuteNonQuery();
    }

    public void Delete(BOOK asghar)
    {
        var command = new SqlCommand("DELETE FROM [BOOK] WHERE BookID = @BookID", _database.Connection);
        command.Parameters.AddWithValue("BookID", asghar.BookID);
        command.ExecuteNonQuery();
    }

    public IList<BOOK> SelectAll()
    {
        var result = new List<BOOK>();
        var command = new SqlCommand("SELECT * FROM [Book]", _database.Connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var item = new BOOK
            {
                BookID = Convert.ToInt32(reader["BookId"].ToString()),
                ISBN = Convert.ToInt32(reader["ISBN"].ToString()),
                Title = reader["Title"].ToString(),
                Author = reader["Author"].ToString(),
                category = reader["Category"].ToString(),
                publishyear = Convert.ToInt32(reader["publishyear"].ToString()),
            };

            result.Add(item);
        }

        return result;
    }

    public BOOK GetById(int id)
    {
        var command = new SqlCommand("SELECT * FROM [Book] WHERE [BookId] = @BookId", _database.Connection);
        command.Parameters.AddWithValue("BookId", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var book = new BOOK
            {
                BookID = Convert.ToInt32(reader["BookId"].ToString()),
                ISBN = Convert.ToInt32(reader["ISBN"].ToString()),
                Title = reader["Title"].ToString(),
                Author = reader["Author"].ToString(),
                category = reader["Category"].ToString(),
                publishyear = Convert.ToInt32(reader["publishyear"].ToString()),
            };
            return book;
        }

        return null;
    }

    public IList<BOOK> FindByName(string name)
    {
        var query = $"SELECT * FROM [book] WHERE [category] LIKE N'%{name}%' OR [Title] LIKE N'%{name}%'";
        var command = new SqlCommand(query, _database.Connection);
        var reader = command.ExecuteReader();
        var result = new List<BOOK>();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }

        return result;
    }

    private BOOK FromReader(SqlDataReader reader)
    {
        return new BOOK
        {
            BookID = Convert.ToInt32(reader["BookID"].ToString()),
            ISBN = Convert.ToInt32(reader["ISBN"].ToString()),
            Title = reader["Title"].ToString(),
            Author = reader["Author"].ToString(),
            publishyear = Convert.ToInt32(reader["publishyear"].ToString()),
            category = reader["category"].ToString()
        };

    }
}