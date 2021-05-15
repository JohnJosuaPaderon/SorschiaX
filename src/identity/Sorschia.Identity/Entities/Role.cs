﻿namespace Sorschia.Identity.Entities
{
    public class Role : RoleBase
    {
    }

    public abstract class RoleBase
    {
        public int Id { get; set; }
        public string LookupCode { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}