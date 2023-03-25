using System;
using System.ComponentModel;

namespace hackathon.Application.Entities
{
    public static class EnumExtension
    {
        #region Methods

        #region GetDesc
        /// <summary>取得列舉 EnumDesc 的值</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDesc(this Enum value)
        {
            string description = value.ToString();
            System.Reflection.FieldInfo fi = value.GetType().GetField(description);
            EnumDesc[] attributes =
              (EnumDesc[])fi.GetCustomAttributes(typeof(EnumDesc), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return description;
        }
        #endregion GetDesc

        #region MyRegion
        /// <summary>取得列舉 Description 的值</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            string description = value.ToString();
            System.Reflection.FieldInfo fi = value.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return description;
        }
        #endregion

        #endregion Methods
    }

    #region Attribute
    /// <summary>EnumDesc 自訂Attribute</summary>
    public sealed class EnumDesc : Attribute
    {
        private string _Description;
        public string Description { get { return this._Description; } }

        public EnumDesc(string description)
            : base()
        {
            this._Description = description;
        }
    }
    #endregion Attribute
}