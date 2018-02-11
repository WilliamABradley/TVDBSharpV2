using System;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Information about a Series being updated.
    /// </summary>
    public class TVDBUpdate
    {
        internal TVDBUpdate()
        {
        }

        /// <summary>
        /// Series ID that was updated.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// The Time it was updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}