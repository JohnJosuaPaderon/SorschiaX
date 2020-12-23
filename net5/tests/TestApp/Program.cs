using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Entities;
using System;

var optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseSqlServer("SERVER=.;DATABASE=SorschiaSAMPLE;USER ID=sa;PASSWORD=calypsoelgrande;");

using var dbContext = new CoreContext();
//var user = new User
//{
//    FirstName = "John Josua",
//    LastName = "Paderon"
//};

//user.Modules.Add(new Module
//{
//    ApplicationId = 2,
//    Name = "Module A",
//    Description = "Sample Description for Module A"
//});

//await dbContext.AddAsync(user);

var existingUser = await dbContext.Users.FindAsync(1);
existingUser.Modules.Add(new Module
{
    Description = "Module B",
    Name = "Module B"
});
existingUser.Roles.Add(new Role
{
    Name = "Role 1",
    Description = "Role 1 Description"
});

await dbContext.SaveChangesAsync();

var query = dbContext.Users.Include(user => user.Modules).Include(user => user.Roles);
var sqlString = query.ToQueryString();
var user = await query.SingleOrDefaultAsync();

Console.WriteLine(user);

await dbContext.SaveChangesAsync();
