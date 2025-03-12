using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock Model){
            return new StockDto{
                Id=Model.Id,
                Symbol=Model.Symbol,
                CompanyName=Model.CompanyName,
                Industry=Model.Industry,
                LastDiv=Model.LastDiv,
                MarketCap=Model.MarketCap,
                Purchase=Model.Purchase,
                Comment=Model.Comments
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto Model){
            return new Stock{
                Symbol=Model.Symbol,
                CompanyName=Model.CompanyName,
                Industry=Model.Industry,
                LastDiv=Model.LastDiv,
                MarketCap=Model.MarketCap,
                Purchase=Model.Purchase,
            };
        }
    }
}