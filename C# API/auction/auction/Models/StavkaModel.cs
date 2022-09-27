using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class StavkaDBModel
    {
        [Key]
        public int id { get; set; }

        public int idUser { get; set; }
        public string time { get; set; }
        public int size { get; set; }

        public static StavkaDBModel Convert(StavkaDTModel fellowDTModel)
        {
            StavkaDBModel fellowDBModel = new StavkaDBModel()
            {
                id = fellowDTModel.id,
                idUser = fellowDTModel.idUser,
                time = fellowDTModel.time,
                size = fellowDTModel.size
            };

            return fellowDBModel;
        }

        public class StavkaDTModel
        {
            public int id { get; set; }
            public int idUser { get; set; }
            public string time { get; set; }
            public int size { get; set; }

            public static StavkaDTModel Convert(StavkaDBModel fellowDBModel)
            {
                StavkaDTModel fellowDTModel = new StavkaDTModel()
                {
                    id = fellowDBModel.id,
                    idUser = fellowDBModel.idUser,
                    time = fellowDBModel.time,
                    size = fellowDBModel.size
                };

                return fellowDTModel;
            }
        }
    }
}