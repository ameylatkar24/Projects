using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catlog.Management.Api.Repository.Infrastructure
{
    public interface ICatlogDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }


    }
}