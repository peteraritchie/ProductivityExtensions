using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace PRI.ProductivityExtensions.Reflection
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Expressionable'
	public static class Expressionable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Expressionable'
	{
		/// <summary>
		/// Converts the body of the lambda expression into the <see cref="T:System.Reflection.PropertyInfo" /> referenced by it.
		/// </summary>
		public static PropertyInfo ToPropertyInfo(this LambdaExpression expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			var propertyInfo = memberExpression?.Member as PropertyInfo;

			if (propertyInfo == null) throw new ArgumentException(expression.ToString());

			return propertyInfo;
		}

		/// <summary>
		/// Converts the body of the lambda expression into the <see cref="T:System.Reflection.PropertyInfo" /> referenced by it.
		/// </summary>
		public static PropertyDescriptor ToPropertyDescriptor(this LambdaExpression expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			var propertyInfo = memberExpression?.Member as PropertyInfo;

			if (propertyInfo == null) throw new ArgumentException(expression.ToString());

			var type = propertyInfo.DeclaringType;
			return TypeDescriptor.GetProperties(type)[propertyInfo.Name];
		}
	}
}