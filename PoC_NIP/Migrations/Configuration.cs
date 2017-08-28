namespace PoC_NIP.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PoC_NIP_DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PoC_NIP_DbContext context)
        {
            context.Companys.AddOrUpdate(
                p => p.Id,
                new Company { Id = 1, Nip = "1111111111", Regon = "011111111", Krs = "0011111111", Name = "Firma A", Street = "Akacjowa", StreetNumber = "1A", PostalCode = "11-111", City = "Warszawa"},
                new Company { Id = 2, Nip = "2222222222", Regon = "022222222", Krs = "0022222222", Name = "Firma B", Street = "Bakaliowa", StreetNumber = "2B/22", PostalCode = "22-222", City = "Kraków" },
                new Company { Id = 3, Nip = "3333333333", Regon = "033333333", Krs = "0033333333", Name = "Firma C", Street = "Czarna", StreetNumber = "3C", PostalCode = "33-333", City = "Wrocław" },
                new Company { Id = 4, Nip = "4444444444", Regon = "044444444", Krs = "0044444444", Name = "Firma D", Street = "Dąbrowskiego", StreetNumber = "4D", PostalCode = "44-444", City = "Gdańsk" },
                new Company { Id = 5, Nip = "5555555555", Regon = "055555555", Krs = "0055555555", Name = "Firma E", Street = "Estońska", StreetNumber = "55", PostalCode = "55-555", City = "Poznań" }
            );
        }
    }
}
