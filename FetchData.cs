public class FetchData
{
    public static User GetUser(string email)
    {
        try
        {
            using var db = new AppContext();
            var user = db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
        catch (Exception)
        {
            throw new Exception("Could not fetch user");
        }
    }
}
