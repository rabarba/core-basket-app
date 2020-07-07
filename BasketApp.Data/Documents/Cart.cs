using System.Collections.Generic;

namespace BasketApp.Data.Documents
{
    public class Cart : Document
    {
        public List<string> ProductIdList { get; set; }
    }
}
