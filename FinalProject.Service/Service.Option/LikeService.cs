using FinalProject.Dto.DTO.LikeDTO;
using FinalProject.Model.Entities;
using FinalProject.Repository.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.Service.Service.Option
{
    public class LikeService
    {
        LikeRepository _likeReposito;
        AppUserRepository _appUserReposito;
        public LikeService()
        {
            _likeReposito = new LikeRepository();
            _appUserReposito = new AppUserRepository();
        }

        //Yorumları Ajax Şeklinde Çekilmitir => HomeController Detail
        public void AddLike(LikeAdd DTO,Guid id,string username)
        {
            Guid UserID = _appUserReposito.FindByUserName(username).ID;
          

            if (!_likeReposito.Any(x => x.AppUserID==UserID && x.BlogID == id))
            {
                Like Model = new Like();
                Model.AppUserID = UserID;
                Model.BlogID = id;
                _likeReposito.Add(Model);
                DTO.Likes = _likeReposito.GetDefault(x => x.BlogID == id).Count;
                DTO.userMessage = string.Empty;
                DTO.isSuccess = true;
            }
            DTO.Likes = _likeReposito.GetDefault(x => x.BlogID == id).Count;
            DTO.userMessage = "Bu Makaleyi Daha Önce Beğendiniz.! ";
            DTO.isSuccess = false;
        }
    }
}
