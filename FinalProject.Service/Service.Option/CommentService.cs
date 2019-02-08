using FinalProject.Dto.DTO.BlogDTO;
using FinalProject.Dto.DTO.CommentDTO;
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
   public class CommentService
    {
        LikeRepository _likeReposito;
        CommentsRepository _commentsReposi;
        AppUserRepository _appUserReposi; 
        public CommentService()
        {
            _likeReposito = new LikeRepository();
            _commentsReposi = new CommentsRepository();
            _appUserReposi = new AppUserRepository();
        }

        //public void CommentAdd(CommentAdd data, string username)
        //{   
        //    data.UserID = _appUserReposi.FindByUserName(username).ID;
        //    _commentsReposi.Add(new Comment
        //    {
        //        AppUsersID = data.UserID,
        //        BlogID = data.BlogID,
        //        Body = data.Comments,
        //        CreatedDate = data.CreatedDate,
        //        ID = data.ID
        //    });
        //}
        //Yorumları Ajax Şeklinde Çekilmitir => HomeController Detail
        public void CommentAdd(CommentAdd DTO,Guid id,string username)
        {
            DTO.UserID = _appUserReposi.FindByUserName(username).ID;
            _commentsReposi.Add(new Comment {
                AppUsersID = DTO.UserID,
                BlogID = id,
                Body = DTO.Comments,
                ID = DTO.ID
            });
        }
        //Yorumları Ajax Şeklinde Çekilmitir => HomeController Detail
        public List<CommentList> CommentList(Guid id,BlogDetail data)
        {
            return _commentsReposi.ListByArticleID(id).OrderByDescending(x => x.CreatedDate).Select(x => new CommentList
            {
                AppUsersID = x.AppUsersID,
                BlogID= x.BlogID,
                Comments = x.Body,
                CreatedDate = x.CreatedDate,
                AppUserName = x.AppUsers.UserName,
                ImagePath = x.AppUsers.ImagePath
            }).ToList();
        }

        public List<CommentList> AdminCommentList()
        {
            return _commentsReposi.GetActive().OrderByDescending(x => x.CreatedDate).Select(x => new CommentList
            {
                AppUsersID = x.AppUsersID,
                BlogID = x.BlogID,
                Comments = x.Body,
                CreatedDate = x.CreatedDate,
                AppUserName = x.AppUsers.UserName,
                ImagePath = x.AppUsers.ImagePath
            }).ToList();
        }
    }
}
