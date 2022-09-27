using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class WebUsersDBModel
    {
        [Key]
        public int id { get; set; }
        public int idUser { get; set; }
        public int idWeb { get; set; }

        public static WebUsersDBModel Convert(WebUsersDTModel fellowDTModel)
        {
            WebUsersDBModel fellowDBModel = new WebUsersDBModel()
            {
                id = fellowDTModel.id,
                idUser = fellowDTModel.idUser,
                idWeb = fellowDTModel.idWeb
            };

            return fellowDBModel;
        }

        public class WebUsersDTModel
        {
            public int id { get; set; }
            public int idUser { get; set; }
            public int idWeb { get; set; }

            public static WebUsersDTModel Convert(WebUsersDBModel fellowDBModel)
            {
                WebUsersDTModel fellowDTModel = new WebUsersDTModel()
                {
                    id = fellowDBModel.id,
                    idUser = fellowDBModel.idUser,
                    idWeb = fellowDBModel.idWeb
                };

                return fellowDTModel;
            }
        }
    }
}