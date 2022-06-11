namespace NewsWeb.AdminDashboard.Service
{
    public interface ISaveDeleteInterface
    {
        string SaveImage(IFormFile newFile);

        void DeleteImage(Guid id);
    }
}
