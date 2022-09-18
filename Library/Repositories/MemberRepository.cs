
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Library.Models;
using Microsoft.Data.SqlClient;
namespace Library.Repositories;


public class MemberRepository
{
    private readonly Database _database;

    public MemberRepository()
    {
        _database = new Database();
    }
    public void InsertMember(Member member)
    {
        const string insertCmd =
            @"INSERT INTO [member] ([Lastname],[Firstname],[AddressM],[phonenumber],[LimitM]) VALUES (@Lastname, @Firstname, @AddressM ,@phonenumber , @LimitM)" ;
        var command = new SqlCommand(insertCmd, _database.Connection);
        command.Parameters.AddWithValue("Firstname", member.Firstname);
        command.Parameters.AddWithValue("Lastname", member.Lastname);
        command.Parameters.AddWithValue("phonenumber", member.phonenumber);
        command.Parameters.AddWithValue("LimitM", member.LimitM);
        command.Parameters.AddWithValue("AddressM", member.AddressM);
        command.ExecuteNonQuery();

        
    } 
        
        
    public void Update(Member member)
    {
           
        var command = new SqlCommand("UPDATE [member] SET  [Lastname]=@Lastname , [Firstname] =@Firstname ,[LimitM]=@LimitM , [AddressM]=@AddressM  WHERE [memberID] = @memberID", 
           _database.Connection );
     
        
        command.Parameters.AddWithValue("memberID", member.memberID);
        command.Parameters.AddWithValue("Firstname", member.Firstname);
        command.Parameters.AddWithValue("Lastname", member.Lastname);
        command.Parameters.AddWithValue("phonenumber", member.phonenumber);
        command.Parameters.AddWithValue("LimitM", member.LimitM);
        command.Parameters.AddWithValue("AddressM", member.AddressM);
        command.ExecuteNonQuery();
    }
        
    public void Delete (Member member)
    {
        var command = new SqlCommand("DELETE FROM [member] WHERE memberID = @memberID", _database.Connection);
        command.Parameters.AddWithValue("memberID", member.memberID);
        command.ExecuteNonQuery();
    }
        
    public IList<Member> SelectAll()
    {
        var result = new List<Member>();
        var command = new SqlCommand("SELECT * FROM [Member]", _database.Connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var item = new Member
            {
                memberID = Convert.ToInt32(reader["memberID"].ToString()),
                Firstname= reader ["Firstname"].ToString(),
                Lastname = reader["Lastname"].ToString(),
                phonenumber = Convert.ToInt32(reader["phonenumber"].ToString()),
                LimitM = Convert.ToInt32(reader["LimitM"].ToString()),
                AddressM = reader["AddressM"].ToString()
            };
            
            result.Add(item);
        }

        return result;
    }
   

    public Member GetById(int id)
    {
        var command = new SqlCommand("SELECT * FROM [Member] WHERE [MemberId] = @MemberId", _database.Connection);
        command.Parameters.AddWithValue("MemberId", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return FromReader(reader);
        }

        return null;
    }


    public IList<Member> FindByName(string name)
    {
        var query = $"SELECT * FROM [Member] WHERE [FirstName] LIKE N'%{name}%' OR [LastName] LIKE N'%{name}%'";
        var command = new SqlCommand(query, _database.Connection);
        var reader = command.ExecuteReader();
        var result = new List<Member>();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }

        return result;
    }

    private Member FromReader(SqlDataReader reader)
    {
        return new Member
        {
            memberID = Convert.ToInt32(reader["memberID"].ToString()),
            Firstname= reader ["Firstname"].ToString(),
            Lastname = reader["Lastname"].ToString(),
            phonenumber = Convert.ToInt32(reader["phonenumber"].ToString()),
            LimitM = Convert.ToInt32(reader["LimitM"].ToString()),
            AddressM = reader["AddressM"].ToString()
        };
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
