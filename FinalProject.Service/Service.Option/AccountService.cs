using FinalProject.Repository.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using FinalProject.Dto.DTO.AppUserDTO;
using FinalProject.Model.Entities;
using FinalProject.Utility;
using FinalProject.Dto.DTO.AccountDTO;
using System.Net.Mail;

namespace FinalProject.Service.Service.Option
{
   public class AccountService
    {
        AppUserRepository _appUserReposito;
        public AccountService(params string[] roles)
        {
            _appUserReposito = new AppUserRepository();
        }

        //Kullanıcı Rollerine Göre Yönlendirme Metodu ...
        public void GetByUsername(string username)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserReposito.FindByUserName(username);
                if (user.Role == Core.Core.Entity.Enum.Role.Admin)
                    HttpContext.Current.Response.Redirect("/Admin/AppUser/List");
                else if (user.Role == Core.Core.Entity.Enum.Role.Member)
                    HttpContext.Current.Response.Redirect("/Home/Index");
                else if (user.Role == Core.Core.Entity.Enum.Role.Editor)
                    HttpContext.Current.Response.Redirect("/Editor/Editor/Index");
                else if (user.Role == Core.Core.Entity.Enum.Role.Article)
                    HttpContext.Current.Response.Redirect("/Article/Article/Index");
            }
        }
        //UI İçerisindeki RoleAttribute Methodunu 
        public bool RoleAttribute(string username,string[] _roles)
        {
            AppUser currentUser = _appUserReposito.FindByUserName(username);
            if (username == null || _roles == null || currentUser == null)
            {
                HttpContext.Current.Response.Redirect("/Error/NotFound");
            }
            foreach (var item in _roles)
            {
                if (currentUser.Role.ToString() == item.ToString())
                    return true;
            }
            HttpContext.Current.Response.Redirect("/Error/NotFound");
            return false;
        }
        //KullanıcıAdı ve Şifre Kontrolünü Sağlamak İçin Gereken Method => AccountController 
        public bool Check(string username, string password)
        {
            if (_appUserReposito.CheckCredentials(username, password))
            {
                AppUser currentUser = _appUserReposito.FindByUserName(username);
                currentUser.LastLogin = DateTime.Now;
                HttpContext.Current.Session["userID"] = currentUser.ID.ToString();
                string cookie = currentUser.UserName;
                FormsAuthentication.SetAuthCookie(cookie, true);
                if (currentUser.Role == Core.Core.Entity.Enum.Role.Admin)
                    HttpContext.Current.Response.Redirect("/Admin/AppUser/List");
                else if (currentUser.Role == Core.Core.Entity.Enum.Role.Member)
                    HttpContext.Current.Response.Redirect("/Home/Index");
                else if (currentUser.Role == Core.Core.Entity.Enum.Role.Editor)
                    HttpContext.Current.Response.Redirect("/Editor/Editor/Index");
                else if (currentUser.Role == Core.Core.Entity.Enum.Role.Article)
                    HttpContext.Current.Response.Redirect("/Article/Article/Index");
                _appUserReposito.Save();
                return true;
            }
            return false;
        }
        //Kullanıcı Kayıt İşlemi İçin Gereken Method => AccountController
        public bool MemberRegister(AccountAdd dto, HttpPostedFileBase Image)
        {
            var Email = _appUserReposito.FindByEmail(dto.Email);
            var userName = _appUserReposito.FindByUserName(dto.UserName);
            if (userName == null && Email == null)
            {
            if (dto.Role == Core.Core.Entity.Enum.Role.None || dto.Role == Core.Core.Entity.Enum.Role.Admin)
            {
                dto.Role = Core.Core.Entity.Enum.Role.Member;
            }
            dto.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);
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
                HttpContext.Current.Response.Redirect("/Account/Login");
            return true;
            }
            return false;
        }
        //Kullanıcı Ayarları İçin Method => /Member/AppUser/AppUserUpdateGET
        //string Username İle Kullanıcı ID'si ve KullanıcıAdı Yakalanıyor Yakalanan ID'yi find(id) ile yakalayıp kullanıcının id'sinden getiriyorum  o id'si yakalanmış kullanıcının bilgilerini getiriyorum.
        public void UserUpdateGet(string username,AppUserDetail Dto)
        {
            Guid AppUsersID = _appUserReposito.FindByUserName(username).ID;
            AppUser model = _appUserReposito.GetById(AppUsersID);
            model.ID = AppUsersID;
            Dto.Name = model.Name;
            Dto.UserName = model.UserName;
            Dto.LastName = model.LastName;
            Dto.Password = model.Password;
            Dto.PhoneNumber = model.PhoneNumber;
            Dto.Address = model.Address;
            Dto.Birthdate = model.Birthdate;
            Dto.Email = model.Email;
            Dto.ImagePath = model.ImagePath;
        }
        //Kullanıcı Ayarları İçin Method => /Member/AppUser/AppUserUpdatePOST
          public bool UserUpdatePost(string username, AppUserDetail DTO, HttpPostedFileBase Image)
        {
                Guid AppUsersID = _appUserReposito.FindByUserName(username).ID;
                AppUser user = _appUserReposito.GetById(AppUsersID);
                DTO.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);
                if (DTO.ImagePath != "0" && DTO.ImagePath != "1" && DTO.ImagePath != "2")
                {
                    user.ImagePath = DTO.ImagePath;
                }
                AppUsersID = DTO.ID;
                user.Name = DTO.Name;
                user.UserName = DTO.UserName;
                user.LastName = DTO.LastName;
                user.PhoneNumber = DTO.PhoneNumber;
                user.Address = DTO.Address;
                user.Birthdate = DTO.Birthdate;
                user.Email = DTO.Email;
                _appUserReposito.Update(user);
            FormsAuthentication.SignOut();
            string cookie = DTO.UserName;
            FormsAuthentication.SetAuthCookie(cookie, true);
            HttpContext.Current.Response.Redirect("/Member/AppUser/AccountSetting");
            return true;
        }

        public bool PasswordChange(AccountPassChange DTO,string username)
        {
            Guid AppUsersID = _appUserReposito.FindByUserName(username).ID;
            AppUser user = _appUserReposito.GetById(AppUsersID);
            if (DTO.OldPassword == user.Password && DTO.AgainPassword == user.Password)
            {
                user.Password = DTO.NewPassword;
                _appUserReposito.Update(user);
                return true;
            }
            else
            {
                HttpContext.Current.Response.RedirectPermanent("/Member/AppUser/PasswordChange");
                return false;
            }
        }


        Random rndm = new Random();
   
        public bool PasswordForgot(AccountCheckMail DTO)
        {
            int numberPass = rndm.Next(1000000, 999999999);
            if (_appUserReposito.MailCredentials(DTO.Mail))
            {
                MailMessage Mail = new MailMessage();
                Mail.From = new MailAddress("rastgelehesap001@gmail.com");
                Mail.To.Add(DTO.Mail);
                Mail.Subject = "Information Mail Message Berk Çolak";
                for (int i = 0; i < 8; i++)
                {
                    Mail.Body = $"Berk Çolak Yeni Şifreniz : {numberPass.ToString()} Bu Mailin Yanlış Olduğunu Düşünüyorsanız Lütfen Bize Bildirim'de Bulununuz.!!";
                }
                string mail = "";
                mail = DTO.Mail;
                Guid AppUserID = _appUserReposito.FindByEmail(mail).ID;
                AppUser user = _appUserReposito.GetById(AppUserID);
                user.Password = numberPass.ToString();
                _appUserReposito.Update(user);
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("rastgelehesap001@gmail.com", "rastgelehesap11");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = Mail;
                bool kontrol = true;
                smtp.Send(Mail);
                HttpContext.Current.Response.Redirect("/Account/Login");
                return kontrol;
            }

            return false;
        }
    }
}
