using System;
using System.Linq.Expressions;

namespace MvvmDialogs.Private
{
    /// <summary>
    /// Class containing methods for extracting member information using reflection.
    /// </summary>
    // TODO: This class isn't used anymore, it was used by DialogService previously
    internal static class Reflection
    {
        internal static readonly string DialogResultPropertyName =
            Reflection.GetPropertyName((IModalDialogViewModel viewModel) => viewModel.DialogResult);

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T">The type of the class or interface.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertyExpression">The expression pointing to a property.</param>
        /// <returns>The name of the property.</returns>
        internal static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            if (propertyExpression == null) throw new ArgumentNullException(nameof(propertyExpression));

            var member = (MemberExpression)propertyExpression.Body;
            return member.Member.Name;
        }
    }
}
