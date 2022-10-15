﻿using Domain.Shared;

namespace Domain.Employment
{
    public class Employment
    {
        public Guid Id { get; set; }
        public string Employer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Experience.Experience> Positions  { get; set; }
        public List<Reference> References { get; set; }
    }
}
