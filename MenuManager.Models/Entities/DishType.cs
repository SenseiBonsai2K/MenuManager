using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManager.Models.Entities
{
    public class DishType
    {
        public int Id { get; set; }
        public string Type { get; set; }


        public DishType()
        {

        }

        public DishType(int id, string type)
        {
            this.Id = id;
            this.Type = type;
        }
    }
}
