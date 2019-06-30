using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.Generic.Utility;

namespace StockMarket.DataModel
{
    [MetadataType(typeof(CompanyMetaData))]
    [Serializable]
    public partial class Company : ICloneable
    {
        public Company Clone()
        {
            return this.CopyObject();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
    
    public class CompanyMetaData
    {

    }
}
