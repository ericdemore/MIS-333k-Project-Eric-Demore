using Microsoft.AspNetCore.Identity;
using BevoBnB.Utilities;
using BevoBnB.DAL;
using BevoBnB.Models;

namespace BevoBnB.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            List<AddUserModel> AllUsers = new List<AddUserModel>();

            // Customers
            
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "cbaker@freezing.co.uk",
                Email = "cbaker@freezing.co.uk",
                PhoneNumber = "5125595133",
                FirstName = "Christopher",
                LastName = "Baker",
                LineAddress = "1245 Lake America Blvd.",
                DOB = DateTime.ParseExact("11/28/1968", "MM/dd/yyyy", null)
            },
            Password = "hellothere",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "mb@puppy.com",
                Email = "mb@puppy.com",
                PhoneNumber = "2102702860",
                FirstName = "Michelle",
                LastName = "Bradicus",
                LineAddress = "1300 Small Pine Lane",
                DOB = DateTime.ParseExact("02/07/1988", "MM/dd/yyyy", null)
            },
            Password = "555533",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "fd@puppy.com",
                Email = "fd@puppy.com",
                PhoneNumber = "8175683686",
                FirstName = "Franco",
                LastName = "Broccoli",
                LineAddress = "62 Cookie Rd",
                DOB = DateTime.ParseExact("11/07/1999", "MM/dd/yyyy", null)
            },
            Password = "666645",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "wendy@puppy.com",
                Email = "wendy@puppy.com",
                PhoneNumber = "5125967209",
                FirstName = "Wendy",
                LastName = "Charile",
                LineAddress = "202 Bellmoth Hall",
                DOB = DateTime.ParseExact("10/27/1992", "MM/dd/yyyy", null)
            },
            Password = "Kansas",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "limchou@puppy.com",
                Email = "limchou@puppy.com",
                PhoneNumber = "2107748586",
                FirstName = "Lim",
                LastName = "Chou",
                LineAddress = "1600 Barbara Lane",
                DOB = DateTime.ParseExact("11/11/1961", "MM/dd/yyyy", null)
            },
            Password = "Rockwall",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "444444.Dave@aool.com",
                Email = "444444.Dave@aool.com",
                PhoneNumber = "2142667242",
                FirstName = "Shan",
                LastName = "Dave",
                LineAddress = "234 Puppy Circle",
                DOB = DateTime.ParseExact("12/19/1972", "MM/dd/yyyy", null)
            },
            Password = "444444",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "louann@puppy.com",
                Email = "louann@puppy.com",
                PhoneNumber = "8172580736",
                FirstName = "Lou Ann",
                LastName = "Feeley",
                LineAddress = "700 S 9th Street W",
                DOB = DateTime.ParseExact("08/01/1958", "MM/dd/yyyy", null)
            },
            Password = "longhorns",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "tfreeley@puppy.com",
                Email = "tfreeley@puppy.com",
                PhoneNumber = "8173279674",
                FirstName = "Tesa",
                LastName = "Freeley",
                LineAddress = "4334 Meanview Ave.",
                DOB = DateTime.ParseExact("07/12/2001", "MM/dd/yyyy", null)
            },
            Password = "puppies",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "mgar@puppy.com",
                Email = "mgar@puppy.com",
                PhoneNumber = "8176617531",
                FirstName = "Margaret",
                LastName = "Garcia",
                LineAddress = "594 Puppyview",
                DOB = DateTime.ParseExact("11/17/1956", "MM/dd/yyyy", null)
            },
            Password = "horses",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "chaley@thug.com",
                Email = "chaley@thug.com",
                PhoneNumber = "2148499570",
                FirstName = "Charles",
                LastName = "Harley",
                LineAddress = "One Ranger Pkwy",
                DOB = DateTime.ParseExact("05/29/1998", "MM/dd/yyyy", null)
            },
            Password = "mycats",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "wjhearniii@umch.edu",
                Email = "wjhearniii@umch.edu",
                PhoneNumber = "2148989608",
                FirstName = "John",
                LastName = "Hearn",
                LineAddress = "4445 South First",
                DOB = DateTime.ParseExact("12/29/1983", "MM/dd/yyyy", null)
            },
            Password = "posicles",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "hicks43@puppy.com",
                Email = "hicks43@puppy.com",
                PhoneNumber = "2105812952",
                FirstName = "Mark",
                LastName = "Hicks",
                LineAddress = "32 NE Mark Ln., Ste 910",
                DOB = DateTime.ParseExact("12/16/1989", "MM/dd/yyyy", null)
            },
            Password = "guac45",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "bradsingram@mall.utexas.edu",
                Email = "bradsingram@mall.utexas.edu",
                PhoneNumber = "5124702808",
                FirstName = "Brad",
                LastName = "Ingram",
                LineAddress = "6548 La Chess St.",
                DOB = DateTime.ParseExact("09/18/1958", "MM/dd/yyyy", null)
            },
            Password = "father",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "father.Ingram@aool.com",
                Email = "father.Ingram@aool.com",
                PhoneNumber = "5124677352",
                FirstName = "Todd",
                LastName = "Jacobs",
                LineAddress = "4564 Palm St.",
                DOB = DateTime.ParseExact("12/09/1975", "MM/dd/yyyy", null)
            },
            Password = "555897",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "victoria@puppy.com",
                Email = "victoria@puppy.com",
                PhoneNumber = "5129481386",
                FirstName = "Victoria",
                LastName = "Lawrence",
                LineAddress = "6639 Butterfly Ln.",
                DOB = DateTime.ParseExact("05/29/1981", "MM/dd/yyyy", null)
            },
            Password = "something",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "lineback@flush.net",
                Email = "lineback@flush.net",
                PhoneNumber = "2102473963",
                FirstName = "Brad",
                LastName = "Lineback",
                LineAddress = "1300 Pirateland St",
                DOB = DateTime.ParseExact("05/19/1973", "MM/dd/yyyy", null)
            },
            Password = "treelover",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "elowe@netscrape.net",
                Email = "elowe@netscrape.net",
                PhoneNumber = "2105368614",
                FirstName = "Evan",
                LastName = "Lowe",
                LineAddress = "3201 Pineapple Drive",
                DOB = DateTime.ParseExact("06/07/1993", "MM/dd/yyyy", null)
            },
            Password = "headear",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "luce_chuck@puppy.com",
                Email = "luce_chuck@puppy.com",
                PhoneNumber = "2107007535",
                FirstName = "Chuck",
                LastName = "Luce",
                LineAddress = "2345 Silent Clouds",
                DOB = DateTime.ParseExact("06/11/1995", "MM/dd/yyyy", null)
            },
            Password = "gooseyloosey",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "mackcloud@pimpdaddy.com",
                Email = "mackcloud@pimpdaddy.com",
                PhoneNumber = "5124772125",
                FirstName = "Jennifer",
                LastName = "MacLeod",
                LineAddress = "2504 Far East Blvd.",
                DOB = DateTime.ParseExact("10/11/1965", "MM/dd/yyyy", null)
            },
            Password = "rainyday",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "liz@puppy.com",
                Email = "liz@puppy.com",
                PhoneNumber = "5124603832",
                FirstName = "Elizabeth",
                LastName = "Markham",
                LineAddress = "7861 Chevy Mace Rd",
                DOB = DateTime.ParseExact("06/18/1989", "MM/dd/yyyy", null)
            },
            Password = "ember22",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "mclarence@puppy.com",
                Email = "mclarence@puppy.com",
                PhoneNumber = "8174979188",
                FirstName = "Clarence",
                LastName = "Martin",
                LineAddress = "87 Alcedo St.",
                DOB = DateTime.ParseExact("04/28/1984", "MM/dd/yyyy", null)
            },
            Password = "lamemartin",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "lamemartin.Martin@aool.com",
                Email = "lamemartin.Martin@aool.com",
                PhoneNumber = "8178770705",
                FirstName = "Gregory",
                LastName = "Martinez",
                LineAddress = "8295 Moon Blvd.",
                DOB = DateTime.ParseExact("12/27/1981", "MM/dd/yyyy", null)
            },
            Password = "gregory",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "cmiller@mapster.com",
                Email = "cmiller@mapster.com",
                PhoneNumber = "8177482602",
                FirstName = "Charles",
                LastName = "Miller",
                LineAddress = "8962 Side St.",
                DOB = DateTime.ParseExact("05/05/1987", "MM/dd/yyyy", null)
            },
            Password = "mucky44",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "nelson.Kelly@puppy.com",
                Email = "nelson.Kelly@puppy.com",
                PhoneNumber = "5122950953",
                FirstName = "Kelly",
                LastName = "Nelson",
                LineAddress = "2601 Green River",
                DOB = DateTime.ParseExact("08/03/1969", "MM/dd/yyyy", null)
            },
            Password = "Tree34",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "jojoe@puppy.com",
                Email = "jojoe@puppy.com",
                PhoneNumber = "2143149884",
                FirstName = "Joe",
                LastName = "Nguyen",
                LineAddress = "1249 4th NW St.",
                DOB = DateTime.ParseExact("02/06/1956", "MM/dd/yyyy", null)
            },
            Password = "jvb485bg",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "orielly@foxnets.com",
                Email = "orielly@foxnets.com",
                PhoneNumber = "2103474912",
                FirstName = "Bill",
                LastName = "O'Reilly",
                LineAddress = "8800 Gringo Drive",
                DOB = DateTime.ParseExact("03/14/1989", "MM/dd/yyyy", null)
            },
            Password = "Bobbygirl",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "or@puppy.com",
                Email = "or@puppy.com",
                PhoneNumber = "2142369553",
                FirstName = "Anka",
                LastName = "Radkovich",
                LineAddress = "1300 Freaky",
                DOB = DateTime.ParseExact("10/26/1952", "MM/dd/yyyy", null)
            },
            Password = "radioactive",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "megrhodes@freezing.co.uk",
                Email = "megrhodes@freezing.co.uk",
                PhoneNumber = "5123768733",
                FirstName = "Megan",
                LastName = "Rhodes",
                LineAddress = "4587 Rightfield Rd.",
                DOB = DateTime.ParseExact("03/18/1958", "MM/dd/yyyy", null)
            },
            Password = "gopigs",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "erynrice@puppy.com",
                Email = "erynrice@puppy.com",
                PhoneNumber = "5123900644",
                FirstName = "Eryn",
                LastName = "Rice",
                LineAddress = "3405 Rio Small",
                DOB = DateTime.ParseExact("11/02/2000", "MM/dd/yyyy", null)
            },
            Password = "iloveme",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "jorge@hootmail.com",
                Email = "jorge@hootmail.com",
                PhoneNumber = "8178928361",
                FirstName = "Jorge",
                LastName = "Rodriguez",
                LineAddress = "6788 Cotten Street",
                DOB = DateTime.ParseExact("01/01/1979", "MM/dd/yyyy", null)
            },
            Password = "565656",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "ra@aoo.com",
                Email = "ra@aoo.com",
                PhoneNumber = "5128776930",
                FirstName = "Allen",
                LastName = "Rogers",
                LineAddress = "4965 Rabbit Hill",
                DOB = DateTime.ParseExact("03/12/2000", "MM/dd/yyyy", null)
            },
            Password = "treeman",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "o_st-jean@home.com",
                Email = "o_st-jean@home.com",
                PhoneNumber = "2104169665",
                FirstName = "Olivier",
                LastName = "Saint-Jean",
                LineAddress = "255 Slap Dr.",
                DOB = DateTime.ParseExact("05/01/1997", "MM/dd/yyyy", null)
            },
            Password = "55htrq",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "ss34@puppy.com",
                Email = "ss34@puppy.com",
                PhoneNumber = "5123521797",
                FirstName = "Sarah",
                LastName = "Saunders",
                LineAddress = "332 Fish C",
                DOB = DateTime.ParseExact("05/31/1994", "MM/dd/yyyy", null)
            },
            Password = "leaves",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "willsheff@email.com",
                Email = "willsheff@email.com",
                PhoneNumber = "5124534071",
                FirstName = "William",
                LastName = "Sewell",
                LineAddress = "2365 34st St.",
                DOB = DateTime.ParseExact("12/10/1951", "MM/dd/yyyy", null)
            },
            Password = "borbj44",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "sheff44@puppy.com",
                Email = "sheff44@puppy.com",
                PhoneNumber = "5125503154",
                FirstName = "Martin",
                LastName = "Sheffield",
                LineAddress = "3886 Road A",
                DOB = DateTime.ParseExact("07/02/1993", "MM/dd/yyyy", null)
            },
            Password = "ldiul485",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "johnsmith187@puppy.com",
                Email = "johnsmith187@puppy.com",
                PhoneNumber = "2108345875",
                FirstName = "John",
                LastName = "Smith",
                LineAddress = "23 Known Forge Dr.",
                DOB = DateTime.ParseExact("06/13/1985", "MM/dd/yyyy", null)
            },
            Password = "kribv75",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "jeff@puppy.com",
                Email = "jeff@puppy.com",
                PhoneNumber = "5127002600",
                FirstName = "Jeffrey",
                LastName = "Stark",
                LineAddress = "337 40th St.",
                DOB = DateTime.ParseExact("05/02/1974", "MM/dd/yyyy", null)
            },
            Password = "jeffery",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "dustroud@mail.com",
                Email = "dustroud@mail.com",
                PhoneNumber = "2142370654",
                FirstName = "Dustin",
                LastName = "Stroud",
                LineAddress = "1212 Henrietta Rd",
                DOB = DateTime.ParseExact("07/14/1974", "MM/dd/yyyy", null)
            },
            Password = "klavjkb48",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "eric_stuart@puppy.com",
                Email = "eric_stuart@puppy.com",
                PhoneNumber = "5128202322",
                FirstName = "Eric",
                LastName = "Stuart",
                LineAddress = "5576 Big Ring",
                DOB = DateTime.ParseExact("06/17/1968", "MM/dd/yyyy", null)
            },
            Password = "vkb451",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "peterstump@hootmail.com",
                Email = "peterstump@hootmail.com",
                PhoneNumber = "8174584890",
                FirstName = "Peter",
                LastName = "Stump",
                LineAddress = "1300 Kellen Square",
                DOB = DateTime.ParseExact("07/23/2001", "MM/dd/yyyy", null)
            },
            Password = "kdsiu4",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "tanner@puppy.com",
                Email = "tanner@puppy.com",
                PhoneNumber = "8174614916",
                FirstName = "Jeremy",
                LastName = "Tanner",
                LineAddress = "4347 Palmstead",
                DOB = DateTime.ParseExact("12/28/1973", "MM/dd/yyyy", null)
            },
            Password = "klrfbj45",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "taylordjay@puppy.com",
                Email = "taylordjay@puppy.com",
                PhoneNumber = "5124772439",
                FirstName = "Allison",
                LastName = "Taylor",
                LineAddress = "467 Nueces St.",
                DOB = DateTime.ParseExact("09/30/1999", "MM/dd/yyyy", null)
            },
            Password = "lraggrhb854",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "lraggrhb854.Taylor@aool.com",
                Email = "lraggrhb854.Taylor@aool.com",
                PhoneNumber = "5124536618",
                FirstName = "Rachel",
                LastName = "Taylor",
                LineAddress = "345 Shortview Dr.",
                DOB = DateTime.ParseExact("02/24/1956", "MM/dd/yyyy", null)
            },
            Password = "alsuib95",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "tee_frank@hootmail.com",
                Email = "tee_frank@hootmail.com",
                PhoneNumber = "8178789530",
                FirstName = "Frank",
                LastName = "Tee",
                LineAddress = "5590 Big Dr.",
                DOB = DateTime.ParseExact("11/11/1964", "MM/dd/yyyy", null)
            },
            Password = "kd1734",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "tuck33@puppy.com",
                Email = "tuck33@puppy.com",
                PhoneNumber = "2148495141",
                FirstName = "Clent",
                LastName = "Tucker",
                LineAddress = "3132 Main St.",
                DOB = DateTime.ParseExact("06/25/1990", "MM/dd/yyyy", null)
            },
            Password = "kjdb983",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "avelasco@puppy.com",
                Email = "avelasco@puppy.com",
                PhoneNumber = "2144009625",
                FirstName = "Allen",
                LastName = "Velasco",
                LineAddress = "634 W. 4th",
                DOB = DateTime.ParseExact("12/13/1966", "MM/dd/yyyy", null)
            },
            Password = "odrb02",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "westj@pioneer.net",
                Email = "westj@pioneer.net",
                PhoneNumber = "2148499231",
                FirstName = "Jake",
                LastName = "West",
                LineAddress = "RR 3244",
                DOB = DateTime.ParseExact("02/06/1968", "MM/dd/yyyy", null)
            },
            Password = "kndl847",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "louielouie@puppy.com",
                Email = "louielouie@puppy.com",
                PhoneNumber = "2145674085",
                FirstName = "Louis",
                LastName = "Winthorpe",
                LineAddress = "2500 Madre Blvd",
                DOB = DateTime.ParseExact("07/23/1961", "MM/dd/yyyy", null)
            },
            Password = "lb2394",
            RoleName = "Customer"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "rwood@voyager.net",
                Email = "rwood@voyager.net",
                PhoneNumber = "5124569229",
                FirstName = "Reagan",
                LastName = "Wood",
                LineAddress = "447 Westlake Dr.",
                DOB = DateTime.ParseExact("10/24/1988", "MM/dd/yyyy", null)
            },
            Password = "drai494",
            RoleName = "Customer"
        });
    

            // Hosts
            
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "jacobs@yahoo.com",
                Email = "jacobs@yahoo.com",
                PhoneNumber = "8176663948",
                FirstName = "Todd",
                LastName = "Jacobs",
                LineAddress = "4564 Elm St.",
                DOB = DateTime.ParseExact("01/29/1978", "MM/dd/yyyy", null)
            },
            Password = "tj2245",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "rice@yahoo.com",
                Email = "rice@yahoo.com",
                PhoneNumber = "2148545987",
                FirstName = "Eryn",
                LastName = "Rice",
                LineAddress = "3405 Rio Grande",
                DOB = DateTime.ParseExact("06/11/2003", "MM/dd/yyyy", null)
            },
            Password = "ricearoni",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "ingram@gmail.com",
                Email = "ingram@gmail.com",
                PhoneNumber = "5127049017",
                FirstName = "John",
                LastName = "Ingram",
                LineAddress = "6548 La Posada Ct.",
                DOB = DateTime.ParseExact("06/25/1980", "MM/dd/yyyy", null)
            },
            Password = "ingram68",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "martinez@aol.com",
                Email = "martinez@aol.com",
                PhoneNumber = "2105859369",
                FirstName = "Paul",
                LastName = "Martinez",
                LineAddress = "8295 Sunset Blvd.",
                DOB = DateTime.ParseExact("06/25/1969", "MM/dd/yyyy", null)
            },
            Password = "party1",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "tanner@utexas.edu",
                Email = "tanner@utexas.edu",
                PhoneNumber = "5129527803",
                FirstName = "Jared",
                LastName = "Tanner",
                LineAddress = "4347 Almstead",
                DOB = DateTime.ParseExact("06/02/1979", "MM/dd/yyyy", null)
            },
            Password = "sandman",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "chung@yahoo.com",
                Email = "chung@yahoo.com",
                PhoneNumber = "2107053952",
                FirstName = "Lauren",
                LastName = "Chung",
                LineAddress = "234 RR 12",
                DOB = DateTime.ParseExact("03/24/1976", "MM/dd/yyyy", null)
            },
            Password = "listen",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "loter@yahoo.com",
                Email = "loter@yahoo.com",
                PhoneNumber = "5124650249",
                FirstName = "Wandavison",
                LastName = "Loter",
                LineAddress = "3453 RR 3235",
                DOB = DateTime.ParseExact("09/23/1966", "MM/dd/yyyy", null)
            },
            Password = "pottery",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "morales@aol.com",
                Email = "morales@aol.com",
                PhoneNumber = "8177529019",
                FirstName = "Heather",
                LastName = "Morales",
                LineAddress = "4501 RR 140",
                DOB = DateTime.ParseExact("01/16/1971", "MM/dd/yyyy", null)
            },
            Password = "heckin",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "rankin@yahoo.com",
                Email = "rankin@yahoo.com",
                PhoneNumber = "5122997370",
                FirstName = "Martin",
                LastName = "Rankin",
                LineAddress = "340 Second St",
                DOB = DateTime.ParseExact("05/16/1961", "MM/dd/yyyy", null)
            },
            Password = "rankmark",
            RoleName = "Host"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "gonzalez@aol.com",
                Email = "gonzalez@aol.com",
                PhoneNumber = "2142415970",
                FirstName = "Garth",
                LastName = "Gonzalez",
                LineAddress = "103 Manor Rd",
                DOB = DateTime.ParseExact("12/10/1993", "MM/dd/yyyy", null)
            },
            Password = "gg2017",
            RoleName = "Host"
        });
    

            // Admins
            
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "taylor@bevobnb.com",
                Email = "taylor@bevobnb.com",
                PhoneNumber = "2149036025",
                FirstName = "Albert",
                LastName = "Taylor",
                LineAddress = "467 Nueces St.",
                DOB = DateTime.ParseExact("08/14/1954", "MM/dd/yyyy", null)
            },
            Password = "TRY563",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "sheffield@bevobnb.com",
                Email = "sheffield@bevobnb.com",
                PhoneNumber = "5124749225",
                FirstName = "Molly",
                LastName = "Sheffield",
                LineAddress = "3886 Avenue A",
                DOB = DateTime.ParseExact("08/27/1986", "MM/dd/yyyy", null)
            },
            Password = "longsnores",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "macleod@bevobnb.com",
                Email = "macleod@bevobnb.com",
                PhoneNumber = "5124723769",
                FirstName = "Jenny",
                LastName = "MacLeod",
                LineAddress = "2504 Far West Blvd.",
                DOB = DateTime.ParseExact("12/05/1984", "MM/dd/yyyy", null)
            },
            Password = "kittys",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "rhodes@bevobnb.com",
                Email = "rhodes@bevobnb.com",
                PhoneNumber = "2102520380",
                FirstName = "Michelle",
                LastName = "Rhodes",
                LineAddress = "4587 Enfield Rd.",
                DOB = DateTime.ParseExact("07/02/1972", "MM/dd/yyyy", null)
            },
            Password = "puppies",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "stuart@bevobnb.com",
                Email = "stuart@bevobnb.com",
                PhoneNumber = "2105415031",
                FirstName = "Evan",
                LastName = "Stuart",
                LineAddress = "5576 Toro Ring",
                DOB = DateTime.ParseExact("04/17/1984", "MM/dd/yyyy", null)
            },
            Password = "coolboi",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "swanson@bevobnb.com",
                Email = "swanson@bevobnb.com",
                PhoneNumber = "5124818542",
                FirstName = "Ron",
                LastName = "Swanson",
                LineAddress = "245 River Rd",
                DOB = DateTime.ParseExact("07/25/1991", "MM/dd/yyyy", null)
            },
            Password = "swanbong",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "white@bevobnb.com",
                Email = "white@bevobnb.com",
                PhoneNumber = "8175025605",
                FirstName = "Jabriel",
                LastName = "White",
                LineAddress = "12 Valley View",
                DOB = DateTime.ParseExact("03/17/1986", "MM/dd/yyyy", null)
            },
            Password = "456789",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "montgomery@bevobnb.com",
                Email = "montgomery@bevobnb.com",
                PhoneNumber = "8178817122",
                FirstName = "Washington",
                LastName = "Montgomery",
                LineAddress = "210 Blanco Dr",
                DOB = DateTime.ParseExact("05/04/1961", "MM/dd/yyyy", null)
            },
            Password = "python4",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "walker@bevobnb.com",
                Email = "walker@bevobnb.com",
                PhoneNumber = "2143196301",
                FirstName = "Lisa",
                LastName = "Walker",
                LineAddress = "9 Bison Circle",
                DOB = DateTime.ParseExact("04/18/2003", "MM/dd/yyyy", null)
            },
            Password = "walkameter",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "chang@bevobnb.com",
                Email = "chang@bevobnb.com",
                PhoneNumber = "2103521329",
                FirstName = "Gregory",
                LastName = "Chang",
                LineAddress = "9003 Joshua St",
                DOB = DateTime.ParseExact("04/26/1958", "MM/dd/yyyy", null)
            },
            Password = "pupgang",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "derek@bevobnb.com",
                Email = "derek@bevobnb.com",
                PhoneNumber = "5125556789",
                FirstName = "Derek",
                LastName = "Dreibrodt",
                LineAddress = "4 Privet Dr",
                DOB = DateTime.ParseExact("01/01/2001", "MM/dd/yyyy", null)
            },
            Password = "2cool4u",
            RoleName = "Admin"
        });
    
        AllUsers.Add(new AddUserModel()
        {
            User = new AppUser()
            {
                UserName = "rester@bevobnb.com",
                Email = "rester@bevobnb.com",
                PhoneNumber = "2103521329",
                FirstName = "Amy",
                LastName = "Rester",
                LineAddress = "2110 Speedway",
                DOB = DateTime.ParseExact("01/01/2000", "MM/dd/yyyy", null)
            },
            Password = "KIzGreat",
            RoleName = "Admin"
        });
    

            String errorFlag = "Start";
            IdentityResult result = new IdentityResult();

            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: "
                    + errorFlag, ex);
            }

            return result;
        }
    }
}
