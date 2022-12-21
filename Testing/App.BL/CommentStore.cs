using System.Data.SqlClient;
using System.Configuration;

namespace App.BL
{
    public interface ICommentStoreWrapper
    {
        public void AddCommentToThread(Comment comment);
    }

    public class CommentStoreWrapper : ICommentStoreWrapper
    {
        public void AddCommentToThread(Comment comment)
        {
            CommentStore.AddCommentToThread(comment);
        }
    }

    // DO NOT CHANGE STATIC
    public static class CommentStore 
    {
        public static void AddCommentToThread(Comment comment)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var query = $"INSERT INTO Comments VALUES ({comment.Id},{comment.Text},{comment.AuthorName},{comment.Created},{comment.ThreadId})";
            new SqlCommand(query, sqlConnection).ExecuteNonQuery();
        }
    }
    
}