﻿namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions.Implementations
{
    public class NotNullOrEmptyCondition : XmlBuildingCondition
    {
        public override bool CheckIfSatisfiedBy(object? value)
        {
            if (value == null)
            {
                return false;
            }

            if (!(value is string strValue))
            {
                return true;
            }

            return !string.IsNullOrEmpty(strValue);
        }
    }
}