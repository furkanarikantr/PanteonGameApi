﻿using Core.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string BuildType { get; set; }
        public double BuildCost { get; set; }
        public long ConstructionTime { get; set; }
    }
}
