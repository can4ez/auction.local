using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class AuctionInfoDBModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int idUser { get; set; }
        public string image { get; set; }
        public string timeStart { get; set; }
        public string timeEnd { get; set; }
        public int startStavka { get; set; }
        public int stepStavka { get; set; }
        public string description { get; set; }


        public static AuctionInfoDBModel Convert(AuctionInfoDTModel fellowDTModel)
        {
            //UserDBModel user = DatabaseConnections.OrganizationsCatalogDB.Users.Find(fellowDTModel.idUser);

            AuctionInfoDBModel fellowDBModel = new AuctionInfoDBModel()
            {
                id = fellowDTModel.id,
                name = fellowDTModel.name,
                idUser = fellowDTModel.idUser,
                image = fellowDTModel.image,
                timeStart = fellowDTModel.timeStart,
                timeEnd = fellowDTModel.timeEnd,
                startStavka = fellowDTModel.startStavka,
                stepStavka = fellowDTModel.stepStavka,
                description = fellowDTModel.description
            };

            return fellowDBModel;
        }

        public class AuctionInfoDTModel
        {
            public int id { get; set; }
            [Required]
            [StringLength(50, MinimumLength = 5)]
            public string name { get; set; }
            [Required]
            public int idUser { get; set; }
            [StringLength(150, MinimumLength = 5)]
            public string image { get; set; }
            [StringLength(50, MinimumLength = 5)]
            public string timeStart { get; set; }
            [StringLength(50, MinimumLength = 5)]
            public string timeEnd { get; set; }
            public int startStavka { get; set; }
            public int stepStavka { get; set; }
            [StringLength(150, MinimumLength = 5)]
            public string description { get; set; }

            public static AuctionInfoDTModel Convert(AuctionInfoDBModel fellowDBModel)
            {
                AuctionInfoDTModel fellowDTModel = new AuctionInfoDTModel()
                {
                    id = fellowDBModel.id,
                    name = fellowDBModel.name,
                    idUser = fellowDBModel.idUser,
                    image = fellowDBModel.image,
                    timeStart = fellowDBModel.timeStart,
                    timeEnd = fellowDBModel.timeEnd,
                    startStavka = fellowDBModel.startStavka,
                    stepStavka = fellowDBModel.stepStavka,
                    description = fellowDBModel.description
                };

                return fellowDTModel;
            }
        }

        public class AuctionInfoInStavka
        {
            public AuctionInfoDBModel auctionInfo { get; set; }
            public List<StavkaDBModel> listStavka { get; set; }
        }
    }
}