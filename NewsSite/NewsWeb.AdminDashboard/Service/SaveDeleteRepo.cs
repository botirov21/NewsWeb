namespace NewsWeb.AdminDashboard.Service
{
    public class SaveDeleteRepo : ISaveDeleteInterface
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public SaveDeleteRepo(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
    }
}
