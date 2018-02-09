﻿namespace TVDBSharp.Models
{
    public class TVDBPagingData
    {
        public int First { get; set; }
        public int Last { get; set; }
        public int? Next { get; set; }
        public int? Prev { get; set; }
    }
}