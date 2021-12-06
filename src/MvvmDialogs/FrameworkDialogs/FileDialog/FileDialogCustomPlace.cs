namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Represents an entry in a FileDialog custom place list.
    /// </summary>
    public class FileDialogCustomPlace
    {
        /// <summary>
        /// Gets the known folder for the custom place.
        /// </summary>
        public FileDialogCustomPlaces? KnownFolder { get; }
        /// <summary>
        /// Gets the file path for the custom place.
        /// </summary>
        public string? Path { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDialogCustomPlace"/> class with the specified known folder.
        /// </summary>
        /// <param name="knownFolder">The known folder.</param>
        public FileDialogCustomPlace(FileDialogCustomPlaces knownFolder) =>
            KnownFolder = knownFolder;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDialogCustomPlace"/> class with the specified path.
        /// </summary>
        /// <param name="path">The file path for the custom place.</param>
        public FileDialogCustomPlace(string path) =>
            Path = path;
    }
}
