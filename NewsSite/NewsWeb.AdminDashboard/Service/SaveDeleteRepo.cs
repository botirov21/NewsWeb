using NewsWeb.Data;
using NewsWeb.Models;

namespace NewsWeb.AdminDashboard.Service
{
    public class SaveDeleteRepo : ISaveDeleteInterface
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext dbContext;

   
        public SaveDeleteRepo(IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.dbContext = dbContext;
        }

        public void DeleteImage(Guid id)
        {
            News news = dbContext.News.FirstOrDefault(p => p.Id == id);
            if (news.Images is not null)
            {
                string uplodFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                string filePath = Path.Combine(uplodFolder, news.Images);
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }

            dbContext.News.Remove(news);
            dbContext.SaveChanges();
        }
        public string SaveImage(IFormFile newFile)
        {
            string uniqueName = string.Empty;
            if (newFile.FileName != null)
            {
                string uplodFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                newFile.CopyTo(fileStream);
                fileStream.Close();
            }

            return uniqueName;

        }
       
        public News UpdateNews(News news)
        {
            dbContext.News.Update(news);
            dbContext.SaveChanges();

            return news;
        }
    }
}
