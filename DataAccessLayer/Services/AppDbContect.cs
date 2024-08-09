using DataAccessLayer.Data;

namespace DataAccessLayer.Services
{
    internal class AppDbContect
    {
        public static implicit operator AppDbContect(AppDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}