using FinalProject.Dto.DTO.CategoryDTO;
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
   public class CategoryService
    {
        CategoryRepository _categoryRepos;
       
        public CategoryService()
        {
            _categoryRepos = new CategoryRepository();
          
        }
        public void CheckID(Guid id)
        {
            if (id == null)
            {
                HttpContext.Current.Response.Redirect("/Error/NotFound");
            }
        }//Her Oluşturduğum Metod'da Farklı Bir DTO'Classı oluşturup UI'ın Entitylere Ulaşmayıp Sadece DTO ve Service Kısmından Refence Almasını Sağlıyorum. 

        //CategoryRepository'de Oluşturduğum List'i Burada Çağırıp DTO'ya Atıyorum ve UI Kısmında Bu Metodu Çağırmam Yeterli Oluyor. 
        //
        public List<CategoryList> List()
        {
            return _categoryRepos.GetActive().OrderByDescending(x => x.CreatedDate).Select(x => new CategoryList
            {
                ID = x.ID,
                Description = x.Description,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                BlogSayisi = x.Bloglar.Count()
            }).ToList();
        }
        //Category Repository'de Oluşturduğum Add 'i Çağırıp Burada DTO Katmanındaki CategoryAdd Dto yu Parametre Verip UI'da Sadece Bu Parametreyi Göndermek Kalıyor.
        public void Add(CategoryAdd dto)
        {
            _categoryRepos.Add(new Category {
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
                ID = dto.ID
            });
        }
        //AppUser Tablousunu DTO Katmanına Atıp UI Kısmında View E Göndermek İçin Parametre Olarak Alıyorum 'DTO' YU Parametre Aldığım DTO'Yu UI Da Verip Bu Method'a Yönlendiriyorum.
        public void Detail(Guid id,CategoryDetail model)
        {
            CheckID(id);
            Category guncellenecek = _categoryRepos.GetById(id);
            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.Description = guncellenecek.Description;
            model.BlogCountt = guncellenecek.Bloglar.Count();
        }

        public void Delete(Guid id)
        {
            CheckID(id);
            Category Silinecek = _categoryRepos.GetById(id);

            _categoryRepos.Remove(Silinecek);
        }

        public void UpdateGetAction(Guid id, CategoryUpdate model)
        {
            CheckID(id);
            Category guncellenecek = _categoryRepos.GetById(id);

            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.Description = guncellenecek.Description;
        }

        //AppUserController'da Update Action'nın Post Methodu
        //Aslında Detail Methodunda Yaptığım Şeyler Aynı Onu Kullanarak veya Generic Yazarak Yapabilirdim Fakat Projemin İleride Güncellenmesi Bakımından Oluşturdum. Istesek Onu Kullanabilirdik.
        public void UpdatePostAction(CategoryUpdate model, HttpPostedFileBase Image)
        {
            Category cat = _categoryRepos.GetById(model.ID);
            cat.Name = model.Name;
            cat.Description = model.Description;
            cat.ID = model.ID;
            cat.Status = Core.Core.Entity.Enum.Status.Updated;
            _categoryRepos.Update(cat);
        }

    }
}
