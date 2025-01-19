using DotNetEnv;

public class DatabaseHelper
{
    public static string GetString()
    {
        Env.Load();

        return Env.GetString("DATABASE_STRING");
    }
}
