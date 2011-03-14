using System;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SquarkerApp.Models
{
	
	/// <summary>
	/// Validates that to properties in an object match. Used to check that a new users "Password"
	/// and "PasswordConfirmation" properties match.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public sealed class PropertiesMustMatchAttribute : ValidationAttribute
	{
		private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";
		
		private readonly object _typeId = new object();
		
		public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
			: base(_defaultErrorMessage)
		{
			OriginalProperty = originalProperty;
			ConfirmProperty = confirmProperty;
		}
		
		public string ConfirmProperty
		{
			get;
			private set;
		}
		
		public string OriginalProperty
		{
			get;
			private set;
		}
		
		public override object TypeId
		{
			get
			{
				return _typeId;	
			}
		}
		
		public override string FormatErrorMessage(string name)
		{
			return String.Format(CultureInfo.CurrentUICulture , ErrorMessageString,
			                     OriginalProperty, ConfirmProperty);
		}
		
		public override bool IsValid (object value)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
			object originalValue = properties.Find(OriginalProperty, true /*ingoreCase */).GetValue(value);
			object confirmValue = properties.Find(ConfirmProperty, true /* ingoreCase */).GetValue(value);
			return Object.Equals(originalValue, confirmValue);
		}
		
	}
}

