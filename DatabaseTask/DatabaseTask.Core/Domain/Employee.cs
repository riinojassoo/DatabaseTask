using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Range(10000000000, 99999999999)]
        public long PersonalIdentificationNr { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Range(100000000000000, 999999999999999)]
        public long ContactPhone { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime WorkingSince { get; set; }

        [DataType(DataType.Date)]
        public DateTime? WorkingUntil { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        // Foreign key to BranchOffice
        [ForeignKey("BranchOffice")]
        public Guid BranchOfficeId { get; set; }

        // Navigation property to BranchOffice
        public BranchOffice BranchOffice { get; set; }
        public ICollection<Child> Children { get; set; } = new List<Child>();

        public ICollection<SickLeave> sickLeaves { get; set; } = new List<SickLeave>();
        public ICollection<Holiday> Holidays { get; set; } = new List<Holiday>();
        public ICollection<HealthInspection> HealthInspections { get; set; } = new List<HealthInspection>();
        public ICollection<Requests> Requests { get; set; } = new List<Requests>();

        public ICollection<Renting> Renting { get; set; } = new List<Renting>();

        public ICollection<WorkingHistory> WorkingHistory { get; set; } = new List<WorkingHistory>();
        public ICollection<Job> Job { get; set; } = new List<Job>();
        public ICollection<AccessPermission> AccessPermissions { get; set; } = new List<AccessPermission>();



        /// ESIMENE HINDELINE HARJUTUS
        /// Nõuded ja tegevus:
        /// 1. Kui tahate, siis võite forkida minu projekti GitHubist ja läbi Sourcetree enda arvutisse tõmmata.
        /// 2. See teeb teil teise hindelise ülesande tegemise lihtsamaks kuna siis on ainult vaja commitida ja pushida.
        /// 3. Teha Code First ja Database First Migration.
        /// 4. Teha word dokumendile töökäik koos piltidega ja detailne. Mitte, et vajuta seda ja mine sinna ning siis on valmis. 
        /// St, et kui mina hakkan teie õpetust jäljendama, siis ma saan selle tehtud.
        /// 5. Kindlasti tahan näha MS SQL DB-st pilti enne migrationit ja peale seda.
        /// 6. Enne Database first migrationi tegemist tuleb ära kustutada Employee.cs ja TARge20DbContext.cs​ . Seda juhul, kui kasutad minu projektipõhja.
        /// 7. Code first puhul peab tekkima Serverisse sinu loodud objekt(id), serverisse __EFMigrationsHistory objekt ja  Migrations kaust projekti.
        /// 8. Database first puhul tekib projekti Models-i alla Serveris loodud objekt(id).


        /// TEINE HINDELINE HARJUTUS
        ///
        /// 1. Teha Teie meeskonna poolt esitletud FirmaDB-st objektide struktuur.
        /// 2. Kui see on valmis, siis teha code first migration. Vajadusel võib mitu migrationit teha.
        /// 3. NB! Kasutate enda meeskonna poolt esitatud FirmaDB ERD-d, aga igaüks teeb individuaalselt.
        /// 4. Järgida hea programmeerimise tava.
        /// 5. Kogu solution laadida GitHubi ja link valmis tööst saata mulle.
        /// 6. Järgmisena teha print screen MS SQL-s database diagrams all olevast auto-genereeritud ERD-st pilt. See lisada readMe.md failina sama projekti alla GitHubis.

        /// Mõned muutujad võivad olla ka NULL väärtusega ja need tuleb ära märkida

        /// kui peate tõmbama mingeid packagesi alla, siis kasutage eelistatult microsofti omasid ning latest stabel versiooni

        /// <summary>
        /// Kui kasutate enumit, siis peate olema kindel, et on tegemist valikutega, mis jäävad kogu rakenduse eluajaks samaks.
        /// </summary>
        //public Gender Gender { get; set; }

        /// <summary>
        /// 
        /// Siin on info ja analüüs, et mis varianti kasutada
        /// https://stackoverflow.com/questions/10113244/why-use-icollection-and-not-ienumerable-or-listt-on-many-many-one-many-relatio/10113331
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?redirectedfrom=MSDN&view=net-5.0
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?redirectedfrom=MSDN&view=net-5.0
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?redirectedfrom=MSDN&view=net-5.0
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#:~:text=Object%20initializers%20let%20you%20assign,by%20lines%20of%20assignment%20statements.
        /// </summary>
        /// Kas peaks objekti initsialiseerima või mitte
        //public IEnumerable<Children> Childrens { get; set; } = new List<Children>();
        //public ICollection<Children> Childrens { get; set; }
        //public List<Children> Childrens { get; set; }
    }


    //public enum Gender
    //{
    //    Female, 
    //    Male,
    //    Unknown
    //}

    //public class Children
    //{
    //    [Key]
    //    public Guid Id { get; set; }

    //    public string FirstName { get; set; }
    //}
}

