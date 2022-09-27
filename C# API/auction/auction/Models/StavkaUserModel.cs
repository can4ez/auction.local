using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class StavkaUserDBModel
    {
        [Key]
        public int id { get; set; }

        public int userId { get; set; }
        public int stavkaId { get; set; }
        public int auctionId { get; set; }

        public static StavkaUserDBModel Convert(StavkaUserDTModel fellowDTModel)
        {
            StavkaUserDBModel fellowDBModel = new StavkaUserDBModel()
            {
                id = fellowDTModel.id,
                userId = fellowDTModel.userId,
                stavkaId = fellowDTModel.stavkaId,
                auctionId = fellowDTModel.auctionId
            };

            return fellowDBModel;
        }

        public class StavkaUserDTModel
        {
            public int id { get; set; }
            public int userId { get; set; }
            public int stavkaId { get; set; }
            public int auctionId { get; set; }

            public static StavkaUserDTModel Convert(StavkaUserDBModel fellowDBModel)
            {
                StavkaUserDTModel fellowDTModel = new StavkaUserDTModel()
                {
                    id = fellowDBModel.id,
                    userId = fellowDBModel.userId,
                    stavkaId = fellowDBModel.stavkaId,
                    auctionId = fellowDBModel.auctionId
                };

                return fellowDTModel;
            }
        }
    }
}