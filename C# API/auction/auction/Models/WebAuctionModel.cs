using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class WebAuctionDBModel
    {
        [Key]
        public int id { get; set; }

        public int idAuction { get; set; }
        public int idWeb { get; set; }

        public static WebAuctionDBModel Convert(WebAuctionDTModel fellowDTModel)
        {
            WebAuctionDBModel fellowDBModel = new WebAuctionDBModel()
            {
                id = fellowDTModel.id,
                idAuction = fellowDTModel.idAuction,
                idWeb = fellowDTModel.idWeb
            };

            return fellowDBModel;
        }

        public class WebAuctionDTModel
        {
            public int id { get; set; }
            public int idAuction { get; set; }
            public int idWeb { get; set; }

            public static WebAuctionDTModel Convert(WebAuctionDBModel fellowDBModel)
            {
                WebAuctionDTModel fellowDTModel = new WebAuctionDTModel()
                {
                    id = fellowDBModel.id,
                    idAuction = fellowDBModel.idAuction,
                    idWeb = fellowDBModel.idWeb
                };

                return fellowDTModel;
            }
        }
    }
}