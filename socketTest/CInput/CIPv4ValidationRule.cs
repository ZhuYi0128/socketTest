using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;
using System.Globalization;

namespace socketTest.CInput
{
    class CIPv4ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (String.IsNullOrEmpty(str))
            {
                return new ValidationResult(false,"请输入IP地址！");
            }

            var parts = str.Split('.');
            if (parts.Length != 4)
            {
                return new ValidationResult(false, "请输入完整4段IP地址格式！");
                 
            }

            foreach (var p in parts)
            {
                int intPart;

                if (!int.TryParse(p, NumberStyles.Integer,cultureInfo.NumberFormat, out intPart))   
                {
                    return new ValidationResult(false, "每一段IP地址应该是数字.");
                     
                }

                if (intPart < 0 || intPart > 255)
                {
                    return new ValidationResult(false,"每一段IP地址的数值应该在0到255之间.");
                }
            }

            return new ValidationResult(true, String.Empty);
        }

    }
}
