using Core.Entity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity.Concrete.MongoDbEntities
{
    public class Build : IEntity
    {
        public ObjectId Id { get; set; }
        public string BuildType { get; set; }
        public double BuildCost { get; set; }
        public long ConstructionTime { get; set; }
    }
}
