using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStack_2.Helpers.HelperModels
{
    public class Historic_External
    {
        public class Pagination
        {
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
            public int total { get; set; }
        }

        public class Data
        {
            public Nullable<double> open { get; set; }
            public Nullable<double> high { get; set; }
            public Nullable<double> low { get; set; }
            public Nullable<double> close { get; set; }
            public Nullable<double> volume { get; set; }
            public double? adj_high { get; set; }
            public double? adj_low { get; set; }
            public double? adj_close { get; set; }
            public double? adj_open { get; set; }
            public double? adj_volume { get; set; }
            public Nullable<double> split_factor { get; set; }
            public string symbol { get; set; }
            public string exchange { get; set; }
            public DateTime date { get; set; }
        }
        public class Historic_Root
        {
            public Pagination pagination { get; set; }
            public List<Data> data { get; set; }
        }
    }
}