using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Model;

namespace Models.Data
{
    public partial class CustomerInfoContext : DbContext
    {
        public CustomerInfoContext()
        {
        }

        public CustomerInfoContext(DbContextOptions<CustomerInfoContext> options)
            : base(options)
        {
            EnsureCountryTablePopulated();
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CustomerInfo;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Country");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CustomerAddress_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void EnsureCountryTablePopulated()
        {
            if(this.Countries.Count() ==0)
            {
                List<Country> c = new List<Country>();
                c.AddRange(new List<Country>(){
                    new Country() { CountryName = "Afghanistan                                 " },
                    new Country() { CountryName = "Albania                                     " },
                    new Country() { CountryName = "Algeria                                     " },
                    new Country() { CountryName = "Andorra                                     " },
                    new Country() { CountryName = "Angola                                      " },
                    new Country() { CountryName = "Antigua & Deps                              " },
                    new Country() { CountryName = "Argentina                                   " },
                    new Country() { CountryName = "Armenia                                     " },
                    new Country() { CountryName = "Australia                                   " },
                    new Country() { CountryName = "Austria                                     " },
                    new Country() { CountryName = "Azerbaijan                                  " },
                    new Country() { CountryName = "Bahamas                                     " },
                    new Country() { CountryName = "Bahrain                                     " },
                    new Country() { CountryName = "Bangladesh                                  " },
                    new Country() { CountryName = "Barbados                                    " },
                    new Country() { CountryName = "Belarus                                     " },
                    new Country() { CountryName = "Belgium                                     " },
                    new Country() { CountryName = "Belize                                      " },
                    new Country() { CountryName = "Benin                                       " },
                    new Country() { CountryName = "Bhutan                                      " },
                    new Country() { CountryName = "Bolivia                                     " },
                    new Country() { CountryName = "Bosnia Herzegovina                          " },
                    new Country() { CountryName = "Botswana                                    " },
                    new Country() { CountryName = "Brazil                                      " },
                    new Country() { CountryName = "Brunei                                      " },
                    new Country() { CountryName = "Bulgaria                                    " },
                    new Country() { CountryName = "Burkina                                     " },
                    new Country() { CountryName = "Burundi                                     " },
                    new Country() { CountryName = "Cambodia                                    " },
                    new Country() { CountryName = "Cameroon                                    " },
                    new Country() { CountryName = "Canada                                      " },
                    new Country() { CountryName = "Cape Verde                                  " },
                    new Country() { CountryName = "Central African Rep                         " },
                    new Country() { CountryName = "Chad                                        " },
                    new Country() { CountryName = "Chile                                       " },
                    new Country() { CountryName = "China                                       " },
                    new Country() { CountryName = "Colombia                                    " },
                    new Country() { CountryName = "Comoros                                     " },
                    new Country() { CountryName = "Congo                                       " },
                    new Country() { CountryName = "Congo { Democratic Rep}                     " },
                    new Country() { CountryName = "                Costa Rica                  " },
                    new Country() { CountryName = "Croatia                                     " },
                    new Country() { CountryName = "Cuba                                        " },
                    new Country() { CountryName = "Cyprus                                      " },
                    new Country() { CountryName = "Czech Republic                              " },
                    new Country() { CountryName = "Denmark                                     " },
                    new Country() { CountryName = "Djibouti                                    " },
                    new Country() { CountryName = "Dominica                                    " },
                    new Country() { CountryName = "Dominican Republic                          " },
                    new Country() { CountryName = "East Timor                                  " },
                    new Country() { CountryName = "Ecuador                                     " },
                    new Country() { CountryName = "Egypt                                       " },
                    new Country() { CountryName = "El Salvador                                 " },
                    new Country() { CountryName = "Equatorial Guinea                           " },
                    new Country() { CountryName = "Eritrea                                     " },
                    new Country() { CountryName = "Estonia                                     " },
                    new Country() { CountryName = "Ethiopia                                    " },
                    new Country() { CountryName = "Fiji                                        " },
                    new Country() { CountryName = "Finland                                     " },
                    new Country() { CountryName = "France                                      " },
                    new Country() { CountryName = "Gabon                                       " },
                    new Country() { CountryName = "Gambia                                      " },
                    new Country() { CountryName = "Georgia                                     " },
                    new Country() { CountryName = "Germany                                     " },
                    new Country() { CountryName = "Ghana                                       " },
                    new Country() { CountryName = "Greece                                      " },
                    new Country() { CountryName = "Grenada                                     " },
                    new Country() { CountryName = "Guatemala                                   " },
                    new Country() { CountryName = "Guinea                                      " },
                    new Country() { CountryName = "Guinea - Bissau                             " },
                    new Country() { CountryName = "Guyana                                      " },
                    new Country() { CountryName = "Haiti                                       " },
                    new Country() { CountryName = "Honduras                                    " },
                    new Country() { CountryName = "Hungary                                     " },
                    new Country() { CountryName = "Iceland                                     " },
                    new Country() { CountryName = "India                                       " },
                    new Country() { CountryName = "Indonesia                                   " },
                    new Country() { CountryName = "Iran                                        " },
                    new Country() { CountryName = "Iraq                                        " },
                    new Country() { CountryName = "Ireland { Republic}                         " },
                    new Country() { CountryName = "                Israel                      " },
                    new Country() { CountryName = "                Italy                       " },
                    new Country() { CountryName = "Ivory Coast                                 " },
                    new Country() { CountryName = "Jamaica                                     " },
                    new Country() { CountryName = "Japan                                       " },
                    new Country() { CountryName = "Jordan                                      " },
                    new Country() { CountryName = "Kazakhstan                                  " },
                    new Country() { CountryName = "Kenya                                       " },
                    new Country() { CountryName = "Kiribati                                    " },
                    new Country() { CountryName = "Korea North                                 " },
                    new Country() { CountryName = "Korea South                                 " },
                    new Country() { CountryName = "Kosovo                                      " },
                    new Country() { CountryName = "Kuwait                                      " },
                    new Country() { CountryName = "Kyrgyzstan                                  " },
                    new Country() { CountryName = "Laos                                        " },
                    new Country() { CountryName = "Latvia                                      " },
                    new Country() { CountryName = "Lebanon                                     " },
                    new Country() { CountryName = "Lesotho                                     " },
                    new Country() { CountryName = "Liberia                                     " },
                    new Country() { CountryName = "Libya                                       " },
                    new Country() { CountryName = "Liechtenstein                               " },
                    new Country() { CountryName = "Lithuania                                   " },
                    new Country() { CountryName = "Luxembourg                                  " },
                    new Country() { CountryName = "Macedonia                                   " },
                    new Country() { CountryName = "Madagascar                                  " },
                    new Country() { CountryName = "Malawi                                      " },
                    new Country() { CountryName = "Malaysia                                    " },
                    new Country() { CountryName = "Maldives                                    " },
                    new Country() { CountryName = "Mali                                        " },
                    new Country() { CountryName = "Malta                                       " },
                    new Country() { CountryName = "Marshall Islands                            " },
                    new Country() { CountryName = "Mauritania                                  " },
                    new Country() { CountryName = "Mauritius                                   " },
                    new Country() { CountryName = "Mexico                                      " },
                    new Country() { CountryName = "Micronesia                                  " },
                    new Country() { CountryName = "Moldova                                     " },
                    new Country() { CountryName = "Monaco                                      " },
                    new Country() { CountryName = "Mongolia                                    " },
                    new Country() { CountryName = "Montenegro                                  " },
                    new Country() { CountryName = "Morocco                                     " },
                    new Country() { CountryName = "Mozambique                                  " },
                    new Country() { CountryName = "Myanmar, { Burma}                           " },
                    new Country() { CountryName = "                Namibia                     " },
                    new Country() { CountryName = "                Nauru                       " },
                    new Country() { CountryName = "Nepal                                       " },
                    new Country() { CountryName = "Netherlands                                 " },
                    new Country() { CountryName = "New Zealand                                 " },
                    new Country() { CountryName = "Nicaragua                                   " },
                    new Country() { CountryName = "Niger                                       " },
                    new Country() { CountryName = "Nigeria                                     " },
                    new Country() { CountryName = "Norway                                      " },
                    new Country() { CountryName = "Oman                                        " },
                    new Country() { CountryName = "Pakistan                                    " },
                    new Country() { CountryName = "Palau                                       " },
                    new Country() { CountryName = "Panama                                      " },
                    new Country() { CountryName = "Papua New Guinea                            " },
                    new Country() { CountryName = "Paraguay                                    " },
                    new Country() { CountryName = "Peru                                        " },
                    new Country() { CountryName = "Philippines                                 " },
                    new Country() { CountryName = "Poland                                      " },
                    new Country() { CountryName = "Portugal                                    " },
                    new Country() { CountryName = "Qatar                                       " },
                    new Country() { CountryName = "Romania                                     " },
                    new Country() { CountryName = "Russian Federation                          " },
                    new Country() { CountryName = "Rwanda                                      " },
                    new Country() { CountryName = "St Kitts & Nevis                            " },
                    new Country() { CountryName = "St Lucia                                    " },
                    new Country() { CountryName = "Saint Vincent &the Grenadines               " },
                    new Country() { CountryName = "Samoa                                       " },
                    new Country() { CountryName = "San Marino                                  " },
                    new Country() { CountryName = "Sao Tome &Principe                          " },
                    new Country() { CountryName = "Saudi Arabia                                " },
                    new Country() { CountryName = "Senegal                                     " },
                    new Country() { CountryName = "Serbia                                      " },
                    new Country() { CountryName = "Seychelles                                  " },
                    new Country() { CountryName = "Sierra Leone                                " },
                    new Country() { CountryName = "Singapore                                   " },
                    new Country() { CountryName = "Slovakia                                    " },
                    new Country() { CountryName = "Slovenia                                    " },
                    new Country() { CountryName = "Solomon Islands                             " },
                    new Country() { CountryName = "Somalia                                     " },
                    new Country() { CountryName = "South Africa                                " },
                    new Country() { CountryName = "South Sudan                                 " },
                    new Country() { CountryName = "Spain                                       " },
                    new Country() { CountryName = "Sri Lanka                                   " },
                    new Country() { CountryName = "Sudan                                       " },
                    new Country() { CountryName = "Suriname                                    " },
                    new Country() { CountryName = "Swaziland                                   " },
                    new Country() { CountryName = "Sweden                                      " },
                    new Country() { CountryName = "Switzerland                                 " },
                    new Country() { CountryName = "Syria                                       " },
                    new Country() { CountryName = "Taiwan                                      " },
                    new Country() { CountryName = "Tajikistan                                  " },
                    new Country() { CountryName = "Tanzania                                    " },
                    new Country() { CountryName = "Thailand                                    " },
                    new Country() { CountryName = "Togo                                        " },
                    new Country() { CountryName = "Tonga                                       " },
                    new Country() { CountryName = "Trinidad & Tobago                           " },
                    new Country() { CountryName = "Tunisia                                     " },
                    new Country() { CountryName = "Turkey                                      " },
                    new Country() { CountryName = "Turkmenistan                                " },
                    new Country() { CountryName = "Tuvalu                                      " },
                    new Country() { CountryName = "Uganda                                      " },
                    new Country() { CountryName = "Ukraine                                     " },
                    new Country() { CountryName = "United Arab Emirates                        " },
                    new Country() { CountryName = "United Kingdom                              " },
                    new Country() { CountryName = "United States                               " },
                    new Country() { CountryName = "Uruguay                                     " },
                    new Country() { CountryName = "Uzbekistan                                  " },
                    new Country() { CountryName = "Vanuatu                                     " },
                    new Country() { CountryName = "Vatican City                                " },
                    new Country() { CountryName = "Venezuela                                   " },
                    new Country() { CountryName = "Vietnam                                     " },
                    new Country() { CountryName = "Yemen                                       " },
                    new Country() { CountryName = "Zambia                                      " },
                    new Country() { CountryName = "Zimbabwe                                " }
                    });
                foreach (Country x in c)
                {
                    x.CountryName.Trim();
                }
                this.Countries.AddRangeAsync(c);
                this.SaveChangesAsync();
            }
        }
    }
}
