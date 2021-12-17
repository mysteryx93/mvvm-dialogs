using System.Collections.Generic;
using System.Text;

namespace MvvmDialogs.FrameworkDialogs;

/// <summary>
/// Represents a filter in an OpenFileDialog or SaveFileDialog.
/// </summary>
public class FileFilter
{
    /// <summary>
    /// Gets or sets the name of the filter, e.g. ("Text files (.txt)").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a list of file extensions matched by the filter (e.g. "txt" or "*" for all
    /// files).
    /// </summary>
    public List<string> Extensions { get; set; } = new List<string>();

    /// <summary>
    /// Returns a string with all extensions starting with '*.' and separated by specified separator.
    /// ex: "*.BMP;*.JPG;*.GIF"
    /// </summary>
    /// <param name="separator">The separator between extensions.</param>
    /// <returns>A string representation of the extensions.</returns>
    public string ExtensionsToString(char separator = ';')
    {
        var builder = new StringBuilder();
        foreach (var ext in Extensions)
        {
            // Add separator.
            if (builder.Length > 0)
            {
                builder.Append(separator);
            }

            // Add *.ext
            builder.Append('*');
            if (!string.IsNullOrEmpty(ext) && !ext.StartsWith("'"))
            {
                builder.Append('.');
            }
            builder.Append(ext);
        }
        return builder.ToString();
    }

    /// <summary>
    /// Returns a string containing the name plus extensions.
    /// ex: "Image Files (*.BMP;*.JPG;*.GIF)"
    /// </summary>
    /// <remarks>
    /// The '.' in extensions is optional. Extensions will automatically be added
    /// to the descriptions unless it contains '('.
    /// If you do not wish to display extensions, end the name with '()' and it will be trimmed away.
    /// </remarks>
    /// <param name="extensions">The extensions to add, calculated with <see cref="ExtensionsToString"/>.</param>
    /// <returns>The name ready for display.</returns>
    public string NameToString(string extensions)
    {
        var name = Name ?? string.Empty;
        // Only add extensions to description if it doesn't contain parenthesis.
        var hasExtInDesc = name.Contains("(");
        // If name ends with '()', trim it and display no extensions.
        if (name.EndsWith("()"))
        {
            name = name.Substring(0, name.Length - 2).TrimEnd();
        }

        // Add all extensions to description.
        if (!hasExtInDesc && !string.IsNullOrEmpty(extensions))
        {
            name += " (" + extensions + ")";
        }
        return name;
    }
}