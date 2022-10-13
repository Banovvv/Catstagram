namespace Catstagram.Data
{
    internal class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=Catstagram;Integrated Security=true;";
        }
    }
}
