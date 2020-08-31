using Nest;
using System;
using System.Text.Json.Serialization;

namespace Phase8
{

    public class Person
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("eyeColor")]
        public string EyeColor { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("registration_date")]
        public string RegistrationDate { get; set; }

        [Ignore]
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [Ignore]
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        private string location = null;
        public string Location
        {
            get
            {
                if (location is null)
                    return $"{Latitude},{Longitude}";
                return location;
            }
            set
            {
                location = value;
            }
        }

        public override string ToString()
        {
            return "Age: " + Age + '\n' +
                "Eye color: " + EyeColor + '\n' +
                "Name: " + Name + '\n' +
                "Gender: " + Gender + '\n' +
                "Company: " + Company + '\n' +
                "Email: " + Email + '\n' +
                "Phone: " + Phone + '\n' +
                "Address: " + Address + '\n' +
                "About: " + About + '\n' +
                "RegistrationDate: " + RegistrationDate + '\n' +
                "Location: " + Location + '\n';
        }
    }
}