﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media;
using System.ComponentModel;
using System.Globalization;

namespace Windows.UI.Xaml.Media
{
	public partial class BrushConverter : TypeConverter
	{
		public BrushConverter()
		{

		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			var canConvert =
				sourceType == typeof(string)
				|| sourceType == typeof(Color);

			if (canConvert)
			{
				return true;
			}

			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			switch (value)
			{
				case string color:
					return SolidColorBrushHelper.FromARGB(color);

				case Color color:
					return new SolidColorBrush(color);
			}

			return base.ConvertFrom(context, culture, value);
		}
	}
}
