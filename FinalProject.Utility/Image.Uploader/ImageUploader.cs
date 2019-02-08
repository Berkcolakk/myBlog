using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.Utility
{
    public static class ImageUploader
    {
        // Hata Numara Kontrolü
        // 0 => Dosya Bulunamadı
        // 1 => Dosya zaten var
        // 2 => Uzantı desteklenmemektedir.
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                //Yeni eşsiz bir isim oluşturuyoruz.
                var uniqueName = Guid.NewGuid();

                //Path ismindeki ~ işaretlerini kaldırıyoruz.
                serverPath = serverPath.Replace("~", string.Empty);

                //Uzantıyı yakalayabilmek için split ile bölüyoruz.
                var fileArray = file.FileName.Split('.');
                //Uzantıyı son elemandan yakalıyoruz.
                string extension = fileArray[fileArray.Length - 1].ToLower();

                //Yeni dosya ismini üretiyoruz. Eşsiz guid ismimiz ve orjinal uzantıyı nokta ile birleştirdik.
                var fileName = uniqueName + "." + extension;

                //Uzantı kontrolü
                if (extension == "jpg" || extension == "png" || extension == "gif" || extension == "jpeg")
                {
                    //Server içerisinde bu foto var mı?
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        //Eğer fotoğraf yoksa kaydet ve kayıt edilen path'i dbye kaydetmek için döndür.
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }

            }
            return "0";

        }
    }
}
