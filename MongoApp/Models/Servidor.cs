using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoApp.Models
{
    [BsonIgnoreExtraElements]
    public class Servidor
    {
        public ObjectId Id { get; set; }
        [Required]
        public string categoria { get; set; }
        public string cargo { get; set; }
        public string setor_siape { get; set; }
        public string disciplina_ingresso { get; set; }
        public string nome { get; set; }
        public string setor_suap { get; set; }
        
    }
}
