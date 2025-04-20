using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.AttachmentService
{
   public class AttachmentService : IAttachmentService
    {
        List<string> AllowedExtensions = [".Png", ".Jpg", ".Jpeg"];
        int maxsize =2_097_152;

      

        public string? Upload(IFormFile file , string folderName)
        {

            //1-Check Extension
            if (file == null) return null;
            var ext = Path.GetExtension(file.FileName);
            if(!AllowedExtensions.Contains(ext)) return null;


            // 2-Check Size
            if (file.Length >= maxsize) return null;

            //3- Get Located Folder Path

            //  var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\{folderName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files",folderName);

            // 4- Make Attachment NAme Uniqe  GUID
            var FileName = $"{Guid.NewGuid()}_{file.FileName}";
            //5- Get File Path
            var FilePath = Path.Combine(folderPath, FileName);
            // 6- Create File Stream To Copy File [Unmanaged]
            using var fileStream = new FileStream(FilePath,FileMode.Create);

            // 7- Use Stream TO Copy File 
            file.CopyTo(fileStream);
            // 8-Return FileName To Store In DataBase  
            return FileName;
        }
        public bool Delete(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }
    }
}
