using MarketStack_2.Helpers.HelperModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace MarketStack_2.Helpers
{
    public class ExternalApiCalls
    {
        public static EOD_Root CallExternalAPIForEndOfDayData(string tickers)
        {
            using (WebClient wc = new WebClient())
            {
                string connUrl = WebConfigurationManager.AppSettings["EndOfDayDataURL"] + tickers;
                var eod_json = wc.DownloadString(connUrl);
                var eod_Root = JsonConvert.DeserializeObject<EOD_Root>(eod_json);
                return eod_Root;
            }
        }

        public static Historic_External.Historic_Root CallExternalAPIForHistoricData(string tickers, DateTime fromDate, DateTime toDate )
        {
            using (WebClient wc = new WebClient())
            {
                string from_Date = fromDate.ToString("yyyy-MM-dd"); 
                string to_Date = toDate.ToString("yyyy-MM-dd"); 
                string connUrl = WebConfigurationManager.AppSettings["HirstoricDataURL"];
                connUrl = connUrl + $"{tickers}&amp;date_from={from_Date}&amp;date_to={to_Date}";
                var h_json = wc.DownloadString(connUrl);
                var h_Root = JsonConvert.DeserializeObject<Historic_External.Historic_Root>(h_json);
                return h_Root;
            }
        }

        public static Intraday_External.IDay_Root CallIntradayData(string tickers)
        {
            using (WebClient wc = new WebClient())
            {
                string connUrl = WebConfigurationManager.AppSettings["IntradayDataURL"] + tickers;
                var iDay_json = wc.DownloadString(connUrl);
                var iDay_Root = JsonConvert.DeserializeObject<Intraday_External.IDay_Root>(iDay_json);
                return iDay_Root;
            }
        }
    }
}