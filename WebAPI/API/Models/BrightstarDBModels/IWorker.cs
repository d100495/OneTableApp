using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.BrightstarDBModels
{
    [Entity]
    public interface IWorker
    {
        int IdWorker { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        decimal Payment { get; set; }
        string Office { get; set; }
        int Pesel { get; set; }
    }
}
