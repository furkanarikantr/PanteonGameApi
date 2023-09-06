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
    public class BuildType : IEntity
    {
        public ObjectId Id { get; set; }

        public string BuildTypeName { get; set; }

        public double BuildTypeCost { get; set; }

        public int BuildTypeConstructionTime { get; set; }
    }
}
