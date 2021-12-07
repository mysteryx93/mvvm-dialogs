using System.Collections.Generic;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Represents a filter in an OpenFileDialog or SaveFileDialog.
    /// </summary>
    public class FileFilter
    {
        /// <summary>
        /// Gets or sets the name of the filter, e.g. ("Text files (.txt)").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a list of file extensions matched by the filter (e.g. "txt" or "*" for all
        /// files).
        /// </summary>
        public List<string> Extensions { get; set; } = new List<string>();
    }
}
