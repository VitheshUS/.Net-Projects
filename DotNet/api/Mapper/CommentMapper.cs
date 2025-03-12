using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment Model){
            return new CommentDto{
                Id=Model.Id,
                Description=Model.Description,
                StockId=Model.StockId,
                //Stock=Model.Stock,
                //UserId=Model.UserId,
                //User=Model.User,
                CreatedOn=Model.CreatedOn
            };
        }
        
        public static Comment ToCommentFromCommentDto(this CreateCommentDto Model){
            return new Comment{
                Description=Model.Description,
                CreatedOn=Model.CreatedOn
            };
        }

        public static Comment CreateCommentFromCommentDto(CreateCommentDto newComment,Comment comment){
            return new Comment{
                Id=comment.Id,
                StockId=comment.StockId,
                Description=newComment.Description,
                CreatedOn=newComment.CreatedOn
            };
        }
    }
}