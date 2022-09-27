using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class UserDBModel
    {
        [Key]
        public int id { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public static UserDBModel Convert(UserDTModel fellowDTModel)
        {
            UserDBModel fellowDBModel = new UserDBModel()
            {
                id = fellowDTModel.id,
                name = fellowDTModel.name,
                password = fellowDTModel.password,
                email = fellowDTModel.email
            };

            return fellowDBModel;
        }

        public class UserDTModel
        {
            public int id { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 5)]
            public string email { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 5)]
            public string password { get; set; }

            [StringLength(50, MinimumLength = 5)]
            public string name { get; set; }

            public static UserDTModel Convert(UserDBModel fellowDBModel)
            {
                UserDTModel fellowDTModel = new UserDTModel()
                {
                    id = fellowDBModel.id,
                    name = fellowDBModel.name,
                    password = fellowDBModel.password,
                    email = fellowDBModel.email
                };

                return fellowDTModel;
            }
        }
    }
}