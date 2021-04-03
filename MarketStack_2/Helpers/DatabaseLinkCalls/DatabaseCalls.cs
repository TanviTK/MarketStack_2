using MarketStack_2.Helpers.HelperModels;
using MarketStack_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStack_2.Helpers.DatabaseLinkCalls
{
    public class DatabaseCalls
    {
        public Guid PostEODPagination(Pagination eod_pagination)
        {
            var eod_ID = Guid.NewGuid();
            using (var mse = new MarketStackEntities())
            {
                mse.End_Of_Day.Add(new End_Of_Day()
                {
                    EOD_Id = eod_ID,
                    Limit = eod_pagination.limit,
                    Count = eod_pagination.count,
                    Offset = eod_pagination.offset,
                    Total = eod_pagination.total,
                    DateOfEntry = DateTime.Now.ToUniversalTime()
                });
                mse.SaveChanges();
            }
            return eod_ID;
        }

        public void PostEODData(List<Data> eod_DataList, Guid eod_ID)
        {
            using (var mse = new MarketStackEntities())
            {
                var query = from eod_Data in eod_DataList
                            select new End_Of_Day_Data
                            {
                                EOD_Data_ID = Guid.NewGuid(),
                                Open = eod_Data.open,
                                High = eod_Data.high,
                                Low = eod_Data.low,
                                Close = eod_Data.close,
                                Volume = eod_Data.volume,
                                Adj_High = eod_Data.adj_high,
                                Adj_Low = eod_Data.adj_low,
                                Adj_Close = eod_Data.adj_close,
                                Adj_Open = eod_Data.adj_open,
                                Adj_Volume = eod_Data.adj_volume,
                                Split_Factor = eod_Data.split_factor,
                                Symbol = eod_Data.symbol,
                                Exchange = eod_Data.exchange,
                                Date = eod_Data.date.ToUniversalTime(),
                                EOD_Id  = eod_ID
                            };
                mse.End_Of_Day_Data.AddRange(query);
                mse.SaveChanges();
            }
        }

        public Guid PostHistoricPagination(Historic_External.Pagination historic_pagination)
        {
            var H_ID = Guid.NewGuid();
            using (var mse = new MarketStackEntities())
            {
                mse.Historicals.Add(new Historical()
                {
                    H_Id = H_ID,
                    Limit = historic_pagination.limit,
                    Count = historic_pagination.count,
                    Offset = historic_pagination.offset,
                    Total = historic_pagination.total,
                    DateOfEntry = DateTime.Now.ToUniversalTime()
                });
                mse.SaveChanges();
            }
            return H_ID;
        }

        public void PostHistoricData(List<Historic_External.Data> historic_DataList, Guid h_ID)
        {
            using (var mse = new MarketStackEntities())
            {
                var query = from h_Data in historic_DataList
                            select new Historical_Data
                            {
                                H_Data_ID = Guid.NewGuid(),
                                Open = h_Data.open,
                                High = h_Data.high,
                                Low = h_Data.low,
                                Close = h_Data.close,
                                Volume = h_Data.volume,
                                Adj_High = h_Data.adj_high,
                                Adj_Low = h_Data.adj_low,
                                Adj_Close = h_Data.adj_close,
                                Adj_Open = h_Data.adj_open,
                                Adj_Volume = h_Data.adj_volume,
                                Split_Factor = h_Data.split_factor,
                                Symbol = h_Data.symbol,
                                Exchange = h_Data.exchange,
                                Date = h_Data.date.ToUniversalTime(),
                                H_Id = h_ID
                            };
                mse.Historical_Data.AddRange(query);
                mse.SaveChanges();
            }
        }

        public Guid PostIntraDayPagination(Intraday_External.Pagination iDay_pagination)
        {
            var iDay_ID = Guid.NewGuid();
            using (var mse = new MarketStackEntities())
            {
                mse.IntraDays.Add(new IntraDay()
                {
                    IDay_Id = iDay_ID,
                    Limit = iDay_pagination.limit,
                    Count = iDay_pagination.count,
                    Offset = iDay_pagination.offset,
                    Total = iDay_pagination.total,
                    DateOfEntry = DateTime.Now.ToUniversalTime()
                });
                mse.SaveChanges();
            }
            return iDay_ID;
        }

        public void PostIntraDayData(List<Intraday_External.Data> iDay_DataList, Guid iDay_ID)
        {
            using (var mse = new MarketStackEntities())
            {
                var query = from iDay_Data in iDay_DataList
                            select new IntraDay_Data
                            {
                                IDay_Data_ID = Guid.NewGuid(),
                                Open = iDay_Data.open,
                                High = iDay_Data.high,
                                Low = iDay_Data.low,
                                Last = iDay_Data.last,
                                Close = iDay_Data.close,
                                Volume = iDay_Data.volume,
                                Date = iDay_Data.date.ToUniversalTime(),
                                Symbol = iDay_Data.symbol,
                                Exchange = iDay_Data.exchange,
                                IDay_Id = iDay_ID
                            };
                mse.IntraDay_Data.AddRange(query);
                mse.SaveChanges();
            }
        }
    }
}