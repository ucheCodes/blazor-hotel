using Microsoft.AspNetCore.Components.Forms;

namespace Hotel.Data
{
    public class ImageUploadService
    {
        private readonly IWebHostEnvironment _environment;
        //declare as add scoped in program cs file and inject 
        //when needed.
        public ImageUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void DeleteImage(string filePath)
        {
            if (_environment != null)
            {
                string imagePath = Path.Combine(_environment.WebRootPath, filePath);

                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
        }
        private async Task<string> CaptureFile(IBrowserFile file)
        {
            if (file == null)//pass e.file of input change event args
            {
                return "";//on loadfile call this capture file method
            }
            string path = "";
            try
            {
                if (_environment != null)
                {
                    var uploadPath = Path.Combine(_environment.WebRootPath, "Upload");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    string newFilename = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
                    path = Path.Combine(uploadPath, newFilename);

                    string fileExtension = Path.GetExtension(file.Name);
                    string relativePath = Path.Combine("Upload", newFilename);
                    await using FileStream fs = new(path, FileMode.Create);
                   // await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
                    return Path.Combine("./", relativePath);//use .result to get the value when returned
                }
                return "";

            }
            catch (Exception)
            {
                //errors.Add($"File : {file.Name} Error : {ex.Message}");
                throw;
            }

        }
    }
}
