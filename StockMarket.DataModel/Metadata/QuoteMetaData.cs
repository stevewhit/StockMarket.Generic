using System;
using System.ComponentModel.DataAnnotations;
using Framework.Generic.Utility;

namespace StockMarket.DataModel
{
    [MetadataType(typeof(QuoteMetaData))]
    [Serializable]
    public partial class Quote : ICloneable
    {
        public Quote Clone()
        {
            return this.CopyObject();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
    
    public class QuoteMetaData
    {

    }
}
