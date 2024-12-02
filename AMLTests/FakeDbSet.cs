using AML.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AMLTests;

public class FakeDbSet : DbContext
{
    public virtual DbSet<Media> Media { get; set; }
    public virtual DbSet<Account> Accounts { get; set; }
}