using FinalProject.Dto.DTO.BlogDTO;
using FinalProject.Dto.DTO.CommentDTO;
using FinalProject.Model.Entities;
using FinalProject.Repository.Repository.Entities;
using FinalProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.Service.Service.Option
{
   public class BlogService
    {
        BlogRepository _blogReposi;
        CategoryRepository _categoryReposi;
        AppUserRepository _appuserReposi;
        CommentsRepository _CommentReposi;
        LikeRepository _likeReposito;
        public BlogService()
        {
            _categoryReposi = new CategoryRepository();
            _blogReposi = new BlogRepository();
            _appuserReposi = new AppUserRepository();
            _CommentReposi = new CommentsRepository();
            _likeReposito = new LikeRepository();
        }

        //ID Kontrolü Yaptığım Method Eğer ID Null Gelir ise ErrorControllerdaki NotFound Action'una Gitsin.
        public void CheckID(Guid id)
        {
            if (id == null)
            {
                HttpContext.Current.Response.Redirect("/Error/NotFound");
            }
        }

        public List<BlogList> List()
        {
            return _blogReposi.GetActive().OrderByDescending(x => x.CreatedDate).Select(x => new BlogList
            {
                Confirmation = x.Confirmation,
                Content = x.Content.Length > 100 ? x.Content.Substring(0,100) + "..." : x.Content,
                Description = x.Description,
                Header = x.Header,
                Homepage = x.Homepage,
                Image = x.Image,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name,
                CreatedDate = x.CreatedDate,
                ID = x.ID,
                ModifiedDate = x.ModifiedDate,
                ReadNumber = x.ReadNumber
        }).ToList();
        }

        public void Add(BlogAdd dto, HttpPostedFileBase Image)
        {
            dto.Image = ImageUploader.UploadSingleImage("~/Uploads/BlogUploads/", Image);
            if (dto.Image == "0" || dto.Image == "1" || dto.Image == "2")
            {
                //Eğer bir hata aldıysak varsayılan bir fotoğraf oluşturup atıyoruz.
                dto.Image = "/Uploads/BlogUploads/WebLogos.jpg";
            }
            _blogReposi.Add(new Blog
            {
                UsersID = dto.UsersID,
                CategoryID = dto.CategoryID,
                Image = dto.Image,
                Content = dto.Content,
                Description = dto.Description,
                Header = dto.Header,
                ID = dto.ID,
            });
        }

        public void Detail(Guid id, BlogDetail model)
        {
            CheckID(id);
            Blog guncellenecek = _blogReposi.GetById(id);
            model.Comments = _CommentReposi.ListByArticleID(id);
            model.Likes = _likeReposito.GetDefault(x => x.BlogID == id).Count;
            model.ID = guncellenecek.ID;
            model.CategoryID = guncellenecek.CategoryID;
            model.Confirmation = guncellenecek.Confirmation;
            model.Content = guncellenecek.Content;
            model.Description = guncellenecek.Description;
            model.Header = guncellenecek.Header;
            model.Homepage = guncellenecek.Homepage;
            model.Image = guncellenecek.Image;
            model.ReadNumber = guncellenecek.ReadNumber;
            model.CreatedDate = guncellenecek.CreatedDate;
            model.ModifiedDate = guncellenecek.ModifiedDate;
        }

        public void UpdateGet(Guid id,BlogUpdate model)
        {
            CheckID(id);
            Blog guncellenecek = _blogReposi.GetById(id);

            model.ID = guncellenecek.ID;
            model.CategoryID = guncellenecek.CategoryID;
            model.Confirmation = guncellenecek.Confirmation;
            model.Content = guncellenecek.Content;
            model.Description = guncellenecek.Description;
            model.Header = guncellenecek.Header;
            model.Homepage = guncellenecek.Homepage;
            model.Image = guncellenecek.Image;
        }

        public void UpdatePost(BlogUpdate dto,HttpPostedFileBase Image)
        {
            Blog blog = _blogReposi.GetById(dto.ID);
            dto.Image = ImageUploader.UploadSingleImage("~/Uploads/BlogUploads/", Image);
            if (dto.Image != "0" && dto.Image != "1" && dto.Image != "2")
            {
                blog.Image = dto.Image;
            }
            blog.ID = dto.ID;
            blog.CategoryID = dto.CategoryID;
            blog.Confirmation = dto.Confirmation;
            blog.Content = dto.Content;
            blog.Description = dto.Description;
            blog.Header = dto.Header;
            blog.Homepage = dto.Homepage;
            blog.Status = Core.Core.Entity.Enum.Status.Updated;
            _blogReposi.Update(blog);
        }

        public void Delete(Guid id)
        {
            CheckID(id);
            Blog Silinecek = _blogReposi.GetById(id);

            _blogReposi.Remove(Silinecek);
        }
        //Anasayfa Üzerinden Kategorilerin İstenilen Kategoriye Gitme Methodu....
       public List<BlogList> BlogCatList(Guid id)
        {
            CheckID(id);
            return _blogReposi.GetActive().OrderByDescending(x => x.CreatedDate).Where(x => x.Category.ID == id).Select(x => new BlogList
            {
                Confirmation = x.Confirmation,
                Content = x.Content,
                Description = x.Description,
                Header = x.Header,
                Homepage = x.Homepage,
                Image = x.Image,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name,
                CreatedDate = x.CreatedDate,
                ID = x.ID,
                ModifiedDate = x.ModifiedDate
            }).ToList();
        }
        //Article'ın Her Yazdığı Blog'ların Listeleme Methodu
        public List<BlogList> ArticleBlogList(BlogList data,string username)
        {
             Guid UserID = _appuserReposi.FindByUserName(username).ID;
            Blog model = _blogReposi.GetById(UserID);
            return _blogReposi.GetActive().OrderByDescending(x => x.CreatedDate).Where(x => x.UsersID == UserID).Select(x => new BlogList
            {
                Confirmation = x.Confirmation,
                Content = x.Content.Length > 100 ? x.Content.Substring(0, 100) + "..." : x.Content,
                Description = x.Description,
                Header = x.Header,
                Homepage = x.Homepage,
                Image = x.Image,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name,
                CreatedDate = x.CreatedDate,
                ID = x.ID,
                ModifiedDate = x.ModifiedDate,
                UserID = x.UsersID,
            }).ToList();
        }
        //Giriş Yapan Article Rolünde Olan Kullanıcıya Göre Eklediği Blogları Listeleme Her Article Rolüne Sahip Kullanıcı Sadece Kendi Eklediği Blogları Görebiliyor. => ArticleArea 
        public void ArticleAddBlog(BlogAdd dto, HttpPostedFileBase Image,string username)
        {
            dto.UsersID = _appuserReposi.FindByUserName(username).ID;
            dto.Image = ImageUploader.UploadSingleImage("~/Uploads/BlogUploads/", Image);
            if (dto.Image == "0" || dto.Image == "1" || dto.Image == "2")
            {
                //Eğer bir hata aldıysak varsayılan bir fotoğraf oluşturup atıyoruz.
                dto.Image = "/Uploads/BlogUploads/WebLogos.jpg";
            }
            _blogReposi.Add(new Blog
            {
                UsersID = dto.UsersID,
                CategoryID = dto.CategoryID,
                Image = dto.Image,
                Content = dto.Content,
                Description = dto.Description,
                Header = dto.Header,
                ID = dto.ID,
            });
        }

        //Ajax ile Yapılmıştır => CommentService
        //public void CommentAdd(Comment data,string username)
        //{
        //    data.AppUsersID = _accountReposi.FindByUserName(username).ID;
        //    _CommentReposi.Add(data);
        //}
        //Sayfaya Tıklanma Sayısını Öğrenme....
        //Blogların Detail Sayfasına Gittiklerinde OkunmaSayısı Artan Method Ajax ile Yapıldı => HomeController
        public void BlogReadNumber(Guid id)
        {
            Blog blog = _blogReposi.GetByDefault(x => x.ID == id);
            blog.ReadNumber += 1;
            _blogReposi.Save();
        }
    }
}
