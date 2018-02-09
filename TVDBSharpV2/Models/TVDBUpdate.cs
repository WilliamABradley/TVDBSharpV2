using System;

namespace TVDBSharp.Models
{
    public class TVDBUpdate
    {
        public TVDBUpdate()
        {
        }

        public uint Id { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}