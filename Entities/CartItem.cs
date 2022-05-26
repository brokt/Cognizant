using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Quantity { get; set; }
        public virtual Users Users { get; set; }
    }
}
