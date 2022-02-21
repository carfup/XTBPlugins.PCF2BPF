using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Carfup.XTBPlugins.AppCode
{
    [Serializable]
    public class PCFParameter
    {
        public string ofTypeGroup = null;

        public string[] ComplexTypes { get; set; }
        public List<PCFEnumValue> ComplexValues { get; set; }

        [DisplayName("Param Desc")]
        public string description { get; set; }

        [DisplayName("Param Display Name")]
        public string displayname { get; set; }

        [DisplayName("Is Static ?")]
        public bool isStatic { get; set; }

        [DisplayName("Param Name")]
        public string name { get; set; }

        [DisplayName("Param Type")]
        public string ofType { get; set; } = null;

        [DisplayName("Requied ?")]
        public bool required { get; set; }

        public string usage { get; set; }

        [DisplayName("Param Value")]
        public object value { get; set; }
    }
}