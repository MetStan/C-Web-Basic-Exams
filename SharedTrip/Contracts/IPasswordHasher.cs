namespace SharedTrip.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
