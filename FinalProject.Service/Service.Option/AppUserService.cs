using FinalProject.Dto.DTO.AppUserDTO;
using FinalProject.Model.Entities;
using FinalProject.Repository.Repository.Entities;
using FinalProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace FinalProject.Service.Service.Option
{
   public class AppUserService
    {
        AppUserRepository _appUserReposito;
        public AppUserService()
        {
            _appUserReposito = new AppUserRepository();
        }
        //ID Kontrolü Yaptığım Method Eğer ID Null Gelir ise ErrorControllerdaki NotFound Action'una Gitsin.
        public void CheckID(Guid id)
        {
            if (id == null)
            {
                HttpContext.Current.Response.Redirect("/Error/NotFound");
            }
        }
        //Method Tanımlamalarım Core Katmanındaki Interface'den Repositorye Geliyor Bu Kısımda Methodları DTO'ya Bağlayıp UI'Kısmına Atıyorum Bu Sayede UI'Da Sadece Parametre Vermek Ve Diğer Kontrolleri  Sağlamak Kalıyor Kod Kalabalığı YOK.
        public List<AppUserList> List()
        {
            
            return _appUserReposito.GetActive().OrderByDescending(x => x.CreatedDate).Select(x => new AppUserList
            {
                ID = x.ID,
                LastName = x.LastName,
                Name = x.Name,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                ImagePath = x.ImagePath,
                Role = x.Role,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                LastLogin = x.LastLogin
                
            }).ToList();
        }
        //Category Repository'de Oluşturduğum Add 'i Çağırıp Burada DTO Katmanındaki CategoryAdd Dto yu Parametre Verip UI'da Sadece Bu Parametreyi Göndermek Kalıyor.
        public void Add(AppUserAdd dto, HttpPostedFileBase Image)
        {
            if (dto.Role == Core.Core.Entity.Enum.Role.None)
            {
                dto.Role = Core.Core.Entity.Enum.Role.Member;
            }
            dto.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/",Image);
            if (dto.ImagePath == "0" || dto.ImagePath == "1" || dto.ImagePath == "2")
            {
                //Eğer bir hata aldıysak varsayılan bir fotoğraf oluşturup atıyoruz.
                dto.ImagePath = "/Uploads/anon-user.png";
            }
            _appUserReposito.Add(new AppUser
            {
                UserName = dto.UserName,
                Address = dto.Address,
                Birthdate = dto.Birthdate,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                ID = dto.ID,
                ImagePath = dto.ImagePath,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                Role = dto.Role
            });
        }
        //AppUser Tablousunu DTO Katmanına Atıp UI Kısmında View E Göndermek İçin Parametre Olarak Alıyorum 'DTO' YU Parametre Aldığım DTO'Yu UI Da Verip Bu Method'a Yönlendiriyorum.
        public void Detail(Guid id, AppUserDetail model)
        {
            CheckID(id);
            AppUser guncellenecek = _appUserReposito.GetById(id);
            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.Address = guncellenecek.Address;
            model.Birthdate = guncellenecek.Birthdate;
            model.CreatedDate = guncellenecek.CreatedDate;
            model.Email = guncellenecek.Email;
            model.ImagePath = guncellenecek.ImagePath;
            model.LastLogin = guncellenecek.LastLogin;
            model.LastName = guncellenecek.LastName;
            model.ModifiedDate = guncellenecek.ModifiedDate;
            model.Password = guncellenecek.Password;
            model.PhoneNumber = guncellenecek.PhoneNumber;
            model.Role = guncellenecek.Role;
            model.UserName = guncellenecek.UserName;
        }
        //Kullanıcı Silme Methodu => AdminArea
        public void Delete(Guid id)
        {
            CheckID(id);
            AppUser Silinecek  = _appUserReposito.GetById(id);
            _appUserReposito.Remove(Silinecek);
        }
        //AppUserController'da Update Action'nın Get Methodu

        //Aslında Detail Methodunda Yaptığım Şeyler Aynı Onu Kullanarak veya Generic Yazarak Yapabilirdim Fakat Projemin İleride Güncellenmesi Bakımından Oluşturdum. Istesek Onu Kullanabilirdik.

        public void UpdateGetAction(Guid id,AppUserUpdate model)
        {
            CheckID(id);
            AppUser guncellenecek = _appUserReposito.GetById(id);
            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.Address = guncellenecek.Address;
            model.Birthdate = guncellenecek.Birthdate;
            model.Email = guncellenecek.Email;
            model.ImagePath = guncellenecek.ImagePath;
            model.LastName = guncellenecek.LastName;
            model.Password = guncellenecek.Password;
            model.PhoneNumber = guncellenecek.PhoneNumber;
            model.Role = guncellenecek.Role;
            model.UserName = guncellenecek.UserName;
        }
        //AppUserController'da Update Action'nın Post Methodu
        //Aslında Detail Methodunda Yaptığım Şeyler Aynı Onu Kullanarak veya Generic Yazarak Yapabilirdim Fakat Projemin İleride Güncellenmesi Bakımından Oluşturdum. Istesek Onu Kullanabilirdik.
        public void UpdatePostAction(AppUserUpdate model,HttpPostedFileBase Image)
        {
            AppUser user = _appUserReposito.GetById(model.ID);
            model.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);
            if (model.ImagePath != "0" && model.ImagePath != "1" && model.ImagePath != "2")
            {
                user.ImagePath = model.ImagePath;
            }
            user.ID = model.ID;
            user.Name = model.Name;
            user.Password = model.Password;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            user.Address = model.Address;
            user.Birthdate = model.Birthdate;
            user.Email = model.Email;
            user.Status = Core.Core.Entity.Enum.Status.Updated;
            user.LastName = model.LastName;
            _appUserReposito.Update(user);
        }

        public void Roles(AppUserRoles model)
        {
            AppUser user = _appUserReposito.GetById(model.ID);

            user.Role = model.Roles;
            user.ID = model.ID;
            user.Status = Core.Core.Entity.Enum.Status.Updated;
            _appUserReposito.Update(user);
        }

    }
}
