using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Mapper;
using api.Models;
using api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){

            var stocks=await _unitOfWork.Stock.GetAllUsingQuery(query,c=>c.Comments);

            return Ok(stocks);
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll(){

        //     var stocks=await _unitOfWork.Stock.GetAllAsync(c=>c.Comments);
            
        //     //Using the extension method
        //     var StockDto=stocks.Select(s=>s.ToStockDto());

        //     return Ok(StockDto);
        // }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){

            var stock=await _unitOfWork.Stock.GetAsync(id);

            if(stock==null){
                return NotFound();
            }
            else{
                return Ok(stock.ToStockDto()); //Extension method
            }  
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){
            var stock=stockDto.ToStockFromCreateDto();

            //await _db.Stock.AddAsync(stock); Not required because we not interacting with the db before adding
            //For example we are not using any sequence to generate primary key, because if we have a sequence then we must interact with the sequence in the db to generate the next primary key
            //hence Add is enough instead of AddAsync

            _unitOfWork.Stock.Add(stock);

            _unitOfWork.SaveChangesAsync(); //Async funtion, Done by UnitOfWork obj

            return CreatedAtAction(nameof(GetById),new{id=stock.Id},stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int? id,[FromBody]UpdateStockRequestDto stockDto){

            var stockModel=await _unitOfWork.Stock.GetAsync(id); //We are getting the reference to the actual object iteself

            if(stockModel==null)
                return NotFound();
            else{
                stockModel.Symbol=stockDto.Symbol;
                stockModel.CompanyName=stockDto.CompanyName;
                stockModel.Industry=stockDto.Industry;
                stockModel.LastDiv=stockDto.LastDiv;
                stockModel.MarketCap=stockDto.MarketCap;
                stockModel.Purchase=stockDto.Purchase;   

                _unitOfWork.SaveChangesAsync();

                return Ok(stockModel.ToStockDto());           
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int?id){
            var stock=await _unitOfWork.Stock.GetAsync(id);
            if(stock==null){
                return NotFound();
            }
            else{
                _unitOfWork.Stock.Remove(stock);
                _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
