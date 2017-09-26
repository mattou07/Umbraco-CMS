﻿using System;
using Umbraco.Core.Models.PublishedContent;

namespace Umbraco.Core.PropertyEditors.ValueConverters
{
    [DefaultPropertyValueConverter]
    public class RadioButtonListValueConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
            => propertyType.PropertyEditorAlias.InvariantEquals(Constants.PropertyEditors.RadioButtonListAlias);

        public override Type GetPropertyValueType(PublishedPropertyType propertyType)
            => typeof (int);

        public override PropertyCacheLevel GetPropertyCacheLevel(PublishedPropertyType propertyType)
            => PropertyCacheLevel.Content;

        public override object ConvertSourceToInter(IPublishedElement owner, PublishedPropertyType propertyType, object source, bool preview)
        {
            var intAttempt = source.TryConvertTo<int>();

            if (intAttempt.Success)
                return intAttempt.Result;

            return null;
        }
    }
}