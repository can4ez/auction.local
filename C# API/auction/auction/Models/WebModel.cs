using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class WebDBModel
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public static WebDBModel Convert(WebDTModel fellowDTModel)
        {
            WebDBModel fellowDBModel = new WebDBModel()
            {
                id = fellowDTModel.id,
                name = fellowDTModel.name
            };

            return fellowDBModel;
        }

        public class WebDTModel
        {
            public int id { get; set; }

            [StringLength(50, MinimumLength = 5)]
            public string name { get; set; }

            public static WebDTModel Convert(WebDBModel fellowDBModel)
            {
                WebDTModel fellowDTModel = new WebDTModel()
                {
                    id = fellowDBModel.id,
                    name = fellowDBModel.name
                };

                return fellowDTModel;
            }
        }
    }
}