using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Mapper;
using api.Models;
using api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Controllers
{
    [ApiController]
    [Route("api/stock/{StockId:int}/comment")]
    [Route("api/stock/comment")]
    public class CommentController :ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int?id){
            var comment=await _unitOfWork.Comment.GetAsync(id);
            return Ok(comment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            List<Comment>? comments=await _unitOfWork.Comment.GetAllAsync();;
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute]int?StockId,[FromBody]CreateCommentDto CreateCommentDto){

            var stock=await _unitOfWork.Stock.GetAsync(StockId);
            if(stock!=null){
            var comment=CreateCommentDto.ToCommentFromCommentDto();
            //comment.Stock=stock;
            comment.StockId=StockId;

            _unitOfWork.Comment.AddAsync(comment);

            stock.Comments.Add(comment);

            _unitOfWork.SaveChangesAsync();

            return Ok(stock);
            }
            else {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult>Update([FromRoute]int?id,[FromBody]CreateCommentDto createCommentDto){

            var comment=await _unitOfWork.Comment.GetAsync(id);

            if(comment==null){
                return NotFound();
            }

            else{
             comment.Description=createCommentDto.Description;
             comment.CreatedOn=createCommentDto.CreatedOn;
             _unitOfWork.SaveChangesAsync();
             return Ok(comment);  
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult>Delete([FromRoute]int?id){
             _unitOfWork.Comment.DeleteAsync(id);
             _unitOfWork.SaveChangesAsync();
             return Ok();  
        }
    }
}