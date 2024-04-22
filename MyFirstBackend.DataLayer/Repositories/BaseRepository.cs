using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.DataLayer.Repositories;
public class BaseRepository
{
    protected readonly BlackBookContext _ctx;
    public BaseRepository(BlackBookContext context)
    {
       _ctx = context;
    }
}