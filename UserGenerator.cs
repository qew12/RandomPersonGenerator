using System;
using Bogus;

namespace Task3
{
    public class UserGenerator
    {
        private static Faker<TableUser> m_instance;
        private static string m_locale;

        private UserGenerator()
        {
            
        }

        public static Faker<TableUser> GetInstace()
        {
            if (m_instance == null) m_instance = new  Faker<TableUser>(m_locale)
                .CustomInstantiator(f => new TableUser())
                .RuleFor(o => o.FullName, f => f.Name.FullName())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.Country, f => f.Address.Country())
                .RuleFor(o => o.StreetName, f => f.Address.StreetName())
                .RuleFor(o => o.ZipCode, f => f.Address.ZipCode())
                .RuleFor(o => o.PhoneNumberFormat, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.SecondaryAddress, f => f.Address.SecondaryAddress())
                .RuleFor(o => o.BuildingNumber, f => f.Address.BuildingNumber());
            return m_instance;
        }
        public static void SetLocale (string locale)
        {
            m_locale = locale;
        }
        
    }
}