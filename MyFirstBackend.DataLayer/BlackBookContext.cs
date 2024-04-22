using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.DataLayer;

public class BlackBookContext: DbContext
{
    public DbSet<UserDto> Users { get; set; }
    public DbSet<DeviceDto> Devices { get; set; }
    public BlackBookContext(DbContextOptions<BlackBookContext>options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<DeviceDto>()
            .HasOne(d => d.Owner)
            .WithMany(u => u.Devices);
}
}
