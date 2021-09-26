using System;

namespace SureSuccessApp.Domain.DTOs.Request
{
    public class EditStudentRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}