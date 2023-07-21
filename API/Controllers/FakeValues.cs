using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeValues : ControllerBase
    {
        public FakeValues(Asp2023DbContext context)
        {
            Context = context;
        }
        private Asp2023DbContext Context { get; }


        // POST api/<FakeValues>
        /// <summary>
        ///  GENERISANJE INICIJALNIH PODATAKA 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     POST /api/FakeValues
        ///     {
        ///          
        ///         
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpPost]

        public IActionResult Post()
        {
/*
             Context.AllUserUseCases.AsNoTracking().FirstOrDefault();
             Context.ArticleUserEmotions.AsNoTracking().FirstOrDefault();*/

            var roles = new List<Role>
            {
                new Role
                {
                    NameRole= "Korisnik"     //Obavezno ovaj naziv 
                },
                new Role
                {
                    NameRole= "Administrator"  //Obavezno ovaj naziv*
                }
            };

            var companies = new List<Company>
            {
                new Company
                {
                    NameCompany="Kompanija 1",
                    Discount= 5,
                },
                new Company
                {
                    NameCompany="Kompanija 2",
                    Discount= 3,
                },
            };

            var countries = new List<Country>
            {
                new Country
                {
                    NameCountry="Srbija",
                },
                new Country
                {
                    NameCountry="Bosna",
                },
                new Country
                {
                    NameCountry="Crna Gora",
                },
            };

            var townships = new List<Township>
            {
                new Township
                {
                    NameTownship="Palilula",
                    Country=countries.ElementAt(0)
                },
                new Township
                {
                    NameTownship="Obrenovac",
                    Country=countries.ElementAt(0)
                },
                new Township
                {
                    NameTownship="Opstina Bosna",
                    Country=countries.ElementAt(1)
                }
            };

            var stickers = new List<Sticker>
            {
                new Sticker
                {
                    NameSticker="Smesan Stiker",
                    StickerPath="Path1"
                },
                new Sticker
                {
                    NameSticker="Tuzan Stiker",
                    StickerPath="Path1"
                }
            };

            var catDimension = new List<CategoryDimension>
            {
                new CategoryDimension
                {
                    Dimension="full screen",
                    Price=50,
                },
                new CategoryDimension
                {
                    Dimension="half screen",
                    Price=10,
                },
            };

            var catComments = new List<CategoryComment>
            {
                new CategoryComment
                {
                    NameCategoryComment="komentar 16:9",
                    Price=50,
                    StylePath="Path Comment 1"
                },
                new CategoryComment
                {
                    NameCategoryComment="komentar 1:2",
                    Price=10,
                    StylePath="Path Comment 2"
                },
            };

            var catDesignArt = new List<CategoryDesignArticle>
            {
                new CategoryDesignArticle
                {
                    NameDesign="Srednji Dizajn",
                    Price=50,
                    DesignPath="Path 1"
                },
                new CategoryDesignArticle
                {
                    NameDesign="Visoki Dizajn",
                    Price=10,
                    DesignPath="Path 2"
                },
            };

            var noRegUser = new List<NonRegisteredUser>
            {
                new NonRegisteredUser
                {
                    FirstName="Mika",
                    LastName ="Mikic",
                    Email="mikaanonym@gmail.com",
                    PhoneNumber="100000",
                },
                new NonRegisteredUser
                {
                    FirstName="Pera",
                    LastName ="Peric",
                    Email="peraaanonym@gmail.com",
                    PhoneNumber="100000",
                }
            };


            var users = new List<User>
            {
                new User
                {
                    FirstName="Lazar",
                    LastName="Galic",
                    Email="galic.lazar@gmail.com",
                    Password="$2a$11$.3RTp6plepU23UYgtQBv1uGYx/cQhCjhdrbiUMaB07tOOF1Xg3FS.",
                    IdentityNumber="12412412",
                    PhoneNumber="1412121",
                    Role=roles.ElementAt(1)
                },
                new User
                {
                    FirstName="Mirko",
                    LastName="Mirkovic",
                    Email="mirkovicc@gmail.com",
                    Password="$2a$11$.3RTp6plepU23UYgtQBv1uGYx/cQhCjhdrbiUMaB07tOOF1Xg3FS.",
                    IdentityNumber="12412412",
                    PhoneNumber="1412121",
                    Role=roles.ElementAt(0)
                },
                new User
                {
                    FirstName="Milenko",
                    LastName="Mirkovic",
                    Email="milenkomirkovicc@gmail.com",
                    Password="$2a$11$.3RTp6plepU23UYgtQBv1uGYx/cQhCjhdrbiUMaB07tOOF1Xg3FS.",
                    IdentityNumber="12412412",
                    PhoneNumber="1412121",
                    Role=roles.ElementAt(0)
                },
            };





            var regUserRoles = new List<int> { 9, 10, 11, 14, 16, 19, 22, 26, 27, 20, 21, 23, 24, 29, 28 , 31 };
            var adminUserRoles = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 ,30, 31}; 
            var usecaseRoles = new List<UseCaseRole>();

            foreach(var r in regUserRoles)
            {
                usecaseRoles.Add(new UseCaseRole
                {
                    Role = roles.ElementAt(0),
                    UseCaseId= r
                });
            }
            foreach (var a in adminUserRoles)
            {
                usecaseRoles.Add(new UseCaseRole
                {
                    Role = roles.ElementAt(1),
                    UseCaseId = a
                });
            }



            var articles = new List<Article>
            {
                new Article
                {
                    NameArticle="Kuvanje",
                    Description="Krenite na kulinarsko putovanje i zadovoljite svoje čulo ukusa. Naš blog prikazuje raznovrsna kulinarska iskustva i pruža inspiraciju za sve ljubitelje hrane. Otkrijte nove recepte, naučite korisne kuhinjske trikove i istražite različite kuhinje širom sveta. ",
                    AdditionalDescription="Kuvanje je mnogo više od jednostavnog postupka pripreme hrane. Ono je umetnost koja spaja ukuse, mirise i teksture, a rezultat su jela koja donose radost i zadovoljstvo. Bilo da ste strastveni kuvar ili početnik u kuhinji, ova divna aktivnost nudi neograničene mogućnosti za kreativnost i eksperimentisanje. U ovom članku istražićemo čarobni svet kuvanja i otkriti zašto je ono mnogo više od pukog zadovoljenja osnovnih prehrambenih potreba.",
                    Quote="Kuvanje je umetnost",
                    Beggin=DateTime.Now.AddDays(-20),
                    End=DateTime.Now.AddDays(20),
                    User=users.ElementAt(0),
                    MainPicturePath="posts_main1.jpg",
                    CategoryDimension=catDimension.ElementAt(0),
                    CategoryDesignArticle=catDesignArt.ElementAt(0),
                    MainContent="Kuvanje je poput slikanja na praznom platnu ili pisanja pesme. Svaki kuvar koristi sastojke kao boje na svojoj paleti i stvara ukusne kompozicije koje su jedinstvene za njegov ili njen stil. Kreativnost se ogleda u kombinovanju različitih ukusa i tekstura, osmišljavanju novih recepata ili davanju ličnog pečata tradicionalnim jelima. U kuhinji se otvara prostor za eksperimentisanje i izražavanje individualnosti, bez ikakvih granica. Kuvanje može biti terapeutsko iskustvo koje pomaže da se oslobodimo stresa i anksioznosti. Uzimanje vremena da se posvetimo pripremi hrane može biti meditativno, umirujuće i opuštajuće. Proces se odvija korak po korak, omogućavajući nam da se fokusiramo na trenutak i budemo prisutni u sadašnjem trenutku. Miris sveže iseckanih začina, zvukovi hrskanja povrća na tavi i zadovoljstvo koje donosi isprobavanje novog recepta sve zajedno stvaraju jedinstveno iskustvo koje oslobađa um od svakodnevnih briga.",
                    Township=townships.ElementAt(0),
                },
                new Article
                {
                    NameArticle="Unapredite svoj nacin zivota",
                    Description="Pronađite savete i smernice za unapređenje fizičkog i mentalnog blagostanja. Naš blog vam pruža informacije o zdravom načinu života, vežbanju, ishrani i tehnika za opuštanje. Otkrijte kako da postignete balans i blagostanje u svakodnevnom životu.",
                    AdditionalDescription="Napredak u životu nije rezervisan samo za neke privilegovane pojedince. Svako od nas može unaprediti svoj način života i postići veće blagostanje. Evo nekoliko korisnih saveta koji vam mogu pomoći da započnete svoje putovanje ka poboljšanju kvaliteta života.",
                    Quote="U zdravom telu zdrav duh.",
                    Beggin=DateTime.Now.AddMonths(-20),
                    End=DateTime.Now.AddDays(50),
                    User=users.ElementAt(0),
                    MainPicturePath="posts_main2.jpg",
                    CategoryDimension=catDimension.ElementAt(1),
                    CategoryDesignArticle=catDesignArt.ElementAt(0),
                    MainContent="Postavite ciljeve: Definišite jasne i dostižne ciljeve koje želite postići. Bez ciljeva, teško je pratiti napredak i održati motivaciju. Podelite svoje ciljeve na manje korake kako biste ih lakše ostvarili. Vodite zdrav način života: Zdravlje je temelj kvalitetnog života. Vodite računa o svom fizičkom zdravlju redovnim vežbanjem, zdravom ishranom i dovoljnim odmorom. Pronađite aktivnost koja vam prija i uključite je u svoju svakodnevicu. Učite i razvijajte se: Nastavite sa učenjem i razvijanjem svojih veština. To može biti kroz formalno obrazovanje, čitanje knjiga, pohađanje radionica ili online kurseva. Održavanje uma aktvnim pomaže vam da ostanete angažovani i motivisani. Upravljajte vremenom: Efikasno upravljanje vremenom ključno je za postizanje uspeha. Napravite planove, organizujte svoje obaveze i prioritizujte važne zadatke. Eliminišite vreme koje provodite na nebitnim aktivnostima i fokusirajte se na ono što je zaista važno. Negujte pozitivne odnose: Kvalitetni odnosi sa porodicom, prijateljima i kolegama mogu značajno uticati na našu sreću i blagostanje. Negujte te odnose, budite podrška drugima i izbegavajte negativne ljude koji vam crpe energiju. Pomažite drugima: Nesebično pružanje pomoći drugima može doneti veliku radost i zadovoljstvo. Volontirajte u lokalnoj zajednici, pružite podršku onima kojima je potrebna i budite oslonac za druge ljude. Praktikujte samorefleksiju: Redovno izdvajajte vreme za samorefleksiju i razmišljanje o svom životu. Razmislite o svojim postignućima, vrednostima i ciljevima. Identifikujte oblasti u kojima želite da se poboljšate i pronađite",
                    Township=townships.ElementAt(1),
                },
                new Article
                {
                    NameArticle="Putovanja",
                    Description="Istražite svet putovanja i otkrijte fascinantna odredišta širom sveta. Naš blog vam donosi inspirativne priče, putopise i savete za planiranje savršenog putovanja. Uronite u različite kulture, upoznajte nove ljude i stvorite nezaboravne uspomene.",
                    AdditionalDescription="Proširuje vidike: Putovanje nas izvlači iz naše svakodnevice i uvodi nas u nove kulture, jezike, tradicije i načine razmišljanja. Susret sa različitim načinima života podstiče našu kreativnost i otvara nove perspektive, pomažući nam da shvatimo širu sliku sveta.",
                    Quote="Svi putevi vode u Rim.",
                    Beggin=DateTime.Now.AddMonths(-1),
                    End=DateTime.Now.AddDays(-5),
                    User=users.ElementAt(1),
                    MainPicturePath="posts/posts_main3.jpg",
                    CategoryDimension=catDimension.ElementAt(0),
                    CategoryDesignArticle=catDesignArt.ElementAt(0),
                    MainContent="Razvija toleranciju i razumevanje: Kroz putovanja se suočavamo sa različitostima i upoznajemo ljude sa drugačijim pozadinama i vrednostima. To nam pomaže da razvijemo toleranciju, empatiju i razumevanje za druge kulture. Kroz te interakcije, učimo da cenimo različitosti i gradimo mostove među ljudima. Podstiče samostalnost: Putovanje je prilika da preuzmemo odgovornost za organizaciju svog vremena, budžeta i rasporeda. Moramo donositi odluke, suočavati se sa izazovima i snalaziti se u nepoznatim situacijama. Ova iskustva jačaju našu samostalnost i samopouzdanje. Inspirira kreativnost: Putovanje je izvor inspiracije za umetnost, pisanje, fotografiju i mnoge druge oblasti izražavanja. Novi pejzaži, arhitektura, boje i mirisi mogu podstaći našu kreativnost i otvoriti vrata za nove ideje. Donosi nova saznanja: Putovanje je prilika da steknemo nova znanja o istoriji, geografiji, umetnosti, religiji i drugim oblastima. Muzeji, spomenici i lokalne priče nam pružaju uvid u bogatu baštinu sveta i proširuju naše obrazovanje. Ohrabruje izlazak iz zone komfora: Putovanje često zahteva da izađemo iz svoje zone komfora. Susret sa nepoznatim jezicima, hranom, transportom i kulturom može biti izazovno, ali nas istovremeno podstiče na rast, prilagođavanje i razvoj novih veština. Osnažuje sećanja i iskustva: Putovanja stvaraju nezaboravne uspomene koje ćemo nositi sa sobom zauvek.",
                    Township=townships.ElementAt(1),
                },
                new Article
                {
                    NameArticle="Web razvoj",
                    Description="Otkrijte najnovije trendove u web razvoju i naučite kako iskoristiti konkurentske partnerske odnose kako biste stvorili efikasne i korisnički prijateljske veb sajtove. Ostanite korak ispred sa našim informativnim člancima i budite u toku sa najnovijim scenarijima u industriji.",
                    AdditionalDescription="Web razvoj je dinamična i kreativna oblast koja omogućava kreiranje interaktivnih i funkcionalnih veb stranica. Kroz web razvoj, možete ostvariti sledeće koristi: 1. Kreiranje profesionalne online prisutnosti: Web razvoj vam omogućava da izgradite profesionalnu online prisutnost za vašu kompaniju, projekat ili lični brend.",
                    Quote="Citaj danas i znaces sutra vise",
                    Beggin=DateTime.Now.AddMonths(-11),
                    End=DateTime.Now.AddDays(-15),
                    User=users.ElementAt(2),
                    MainPicturePath="posts_main4.jpg",
                    CategoryDimension=catDimension.ElementAt(1),
                    CategoryDesignArticle=catDesignArt.ElementAt(0),
                    MainContent="Interaktivnost i angažovanje korisnika: Web razvoj vam omogućava da stvorite interaktivne veb stranice sa funkcionalnostima koje korisnicima pružaju bogato iskustvo. To može uključivati obrasce za kontakt, korpu za kupovinu, animacije ili druge interaktivne elemente koji poboljšavaju angažovanje posetilaca. 4. Prilagođavanje mobilnim uređajima: Web razvoj omogućava da vaše veb stranice budu optimizovane za prikaz na mobilnim uređajima. Mobilna prilagodljivost je ključna u današnjem svetu, jer većina ljudi koristi pametne telefone i tablete za pristup internetu. 5. Skalabilnost i fleksibilnost: Web razvoj vam omogućava da skalirate vaše veb stranice prema rastućim potrebama. Bez obzira da li želite dodavati nove funkcionalnosti, sadržaj ili proširiti svoj posao, web razvoj vam pruža fleksibilnost da se prilagodite promenama. 6. Analitika i praćenje performansi: Kroz web razvoj možete implementirati analitičke alate koji vam omogućavaju praćenje performansi vaših veb stranica. Možete dobiti uvid u broj poseta, konverzije, ponašanje korisnika i druge metrike koje vam pomažu da optimizujete svoje veb stranice i postignete željene rezultate. 7. Unapređenje korisničkog iskustva: Web razvoj vam omogućava da stvorite veb stranice koje su korisnički prijateljske i jednostavne za navigaciju.",
                    Township=townships.ElementAt(0),
                },
                new Article
                {
                    NameArticle="Citanje knjiga",
                    Description="Dublje se uronite u svet knjiga i otkrijte nove avanture kroz stranice. Naš blog vam donosi preporuke za čitanje, književne recenzije i uvid u svet književnosti. Zajedno ćemo otkrivati najnovije naslove i deliti strast prema pisanoj reči.",
                    AdditionalDescription="Citanje knjiga je obogaćujuće iskustvo koje nosi brojne prednosti: 1. Proširuje horizonte: Citanje knjiga otvara vrata ka novim svetovima, idejama i perspektivama. Putujete kroz vreme i prostor, istražujete različite kulture i upoznajete se sa različitim likovima. Ovo vam omogućava da proširite svoje znanje i razumete različite aspekte sveta. 2. Razvija kreativnost.",
                    Quote="Kuvanje je umetnost",
                    Beggin=DateTime.Now.AddMonths(-11),
                    End=DateTime.Now.AddDays(-15),
                    //User=users.ElementAt(2),
                    NonRegisteredUser=noRegUser.ElementAt(0),
                    MainPicturePath="posts_main5.jpg",
                    CategoryDimension=catDimension.ElementAt(1),
                    CategoryDesignArticle=catDesignArt.ElementAt(0),
                    MainContent="Poboljšava kognitivne sposobnosti: Citanje knjiga zahteva fokus, pažnju i koncentraciju. Ove mentalne veštine se razvijaju kroz redovno čitanje. Citanje takođe poboljšava memoriju, logičko razmišljanje i sposobnost analize. 4. Smanjuje stres: Citanje knjiga može biti odličan način da se opustite i smanjite stres. Gubite se u priči i zaboravljate na svakodnevne brige. Citanje takođe može imati terapeutski efekat, pomažući vam da se suočite sa svojim emocijama i razumete ih bolje. 5. Poboljšava vokabular i jezičke veštine: Citanje knjiga vam omogućava da proširite svoj vokabular i poboljšate jezičke veštine. Susrećete nove reči, idiome i načine izražavanja koji će obogatiti vašu komunikaciju. Takođe, čitanje knjiga na stranom jeziku može vam pomoći da poboljšate svoje jezičko znanje. 6. Pruža emocionalnu povezanost: Knjige često opisuju ljudska iskustva, emocije i dileme sa kojima se možemo identifikovati. Čitanje vam omogućava da se povežete sa likovima, saosećate sa njima i razumete njihove perspektive. Ovo može pomoći u razvijanju empatije i razumevanja prema drugima. 7. Oslobađa maštu i podstiče introspekciju: Knjige vas mogu odvesti na putovanje mašte i fantazije. Izazivaju vašu kreativnost i podstiču vas da razmišljate o dubljim pitanjima. Takođe, mogu vam pružiti priliku za introspekciju i samorefleksiju, pomažući vam da bolje razumete sebe i svoje životne vrednosti.",
                    Township=townships.ElementAt(0),
                },
            };




            var allUsersUseCase = new List<AllUserUseCase>();

            foreach (var r in regUserRoles)
            {
                allUsersUseCase.Add(new AllUserUseCase
                {
                    User = users.ElementAt(1),
                    UseCaseId = r
                });

            }

            foreach (var r in regUserRoles)
            {
                allUsersUseCase.Add(new AllUserUseCase
                {
                    User = users.ElementAt(2),
                    UseCaseId = r
                });
            }


            foreach (var a in adminUserRoles)
            {
                allUsersUseCase.Add(new AllUserUseCase
                {
                    User = users.ElementAt(0),
                    UseCaseId = a
                });
            }



            var emotions = new List<Emotion>
            {
                new Emotion
                {
                    NameEmotion="Funny and lol",
                    Price = 100,
                    ImagePath="Pathh funny"
                },
                new Emotion
                {
                    NameEmotion = "Love",
                    Price = 200,
                    ImagePath="Pathh love"
                },
                new Emotion
                {
                    NameEmotion = "Scary",
                    Price = 150,
                    ImagePath="Pathh scary"
                }
            };



            var articleImages = new List<ArticleImage>()
            {
                new ArticleImage
                {
                    Article=articles.ElementAt(1),
                    ImagePath="putanjaa11",
                },
                new ArticleImage
                {
                    Article=articles.ElementAt(1),
                    ImagePath="putanjaa22",
                },
                new ArticleImage
                {
                    Article=articles.ElementAt(3),
                    ImagePath="putanjaaaaaaaaaa",
                },
            };



            var artUsEmot = new List<ArticleUserEmotion>
            {
                new ArticleUserEmotion
                {
                    Article=articles.ElementAt(0),
                    Emotion=emotions.ElementAt(0),
                    User=users.ElementAt(0)
                },
                new ArticleUserEmotion
                {
                    Article=articles.ElementAt(1),
                    Emotion=emotions.ElementAt(2),
                    User=users.ElementAt(2)
                },
                new ArticleUserEmotion
                {
                    Article=articles.ElementAt(4),
                    Emotion=emotions.ElementAt(1),
                    User=users.ElementAt(2)
                },


            };



            var usercomp = new List<UserCompany>()
             {
                 new UserCompany
                 {
                     User=users.ElementAt(0),
                     Company=companies.ElementAt(0)
                 }
             };


            var articleComments = new List<CommentArticle>()
            {
                new CommentArticle
                {
                    Content="Vauuu",
                    User=users.ElementAt(1),
                    Article=articles.ElementAt(0),
                    Sticker=stickers.ElementAt(0),
                    CategoryComment=catComments.ElementAt(0),
                    CategoryDimension=catDimension.ElementAt(0),
                },
                new CommentArticle
                {
                    Content="Svaka Cast",
                    User=users.ElementAt(2),
                    Article=articles.ElementAt(0),
                    CategoryComment=catComments.ElementAt(0),
                    CategoryDimension=catDimension.ElementAt(1),
                },
               new CommentArticle
                {
                    Content="Bravoooo ",
                    User=users.ElementAt(2),
                    Article=articles.ElementAt(0),
                    CategoryComment=catComments.ElementAt(0),
                    CategoryDimension=catDimension.ElementAt(0),
                },
                new CommentArticle
                {
                    Content="Ja ne verujem",
                    User=users.ElementAt(1),
                    Article=articles.ElementAt(0),
                    CategoryComment=catComments.ElementAt(0),
                    CategoryDimension=catDimension.ElementAt(0),
                },
                new CommentArticle
                {
                    Content="To je to",
                    User=users.ElementAt(1),
                    Article=articles.ElementAt(3),
                    CategoryComment=catComments.ElementAt(0),
                    CategoryDimension=catDimension.ElementAt(0),
                },
            };

            articleComments.Add(new CommentArticle
            {
                ParentComment = articleComments.ElementAt(0),
                Content = "Mislis? ",
                User = users.ElementAt(2),
                Article = articles.ElementAt(0),
                CategoryComment = catComments.ElementAt(0),
                CategoryDimension = catDimension.ElementAt(0),
            });


            articleComments.Add(new CommentArticle
            {
                ParentComment = articleComments.ElementAt(0),
                Content = "Otkud ti znas ?! ",
                User = users.ElementAt(1),
                Article = articles.ElementAt(0),
                CategoryComment = catComments.ElementAt(1),
                CategoryDimension = catDimension.ElementAt(0),
            });

            articleComments.Add(new CommentArticle
            {
                ParentComment = articleComments.ElementAt(2),
                Content = "Ne lupaj",
                User = users.ElementAt(2),
                Article = articles.ElementAt(0),
                CategoryComment = catComments.ElementAt(1),
                CategoryDimension = catDimension.ElementAt(0),
            });

            articleComments.Add(new CommentArticle
            {
                ParentComment = articleComments.ElementAt(4),
                Content = "Boze me oprosti",
                User = users.ElementAt(2),
                Article = articles.ElementAt(3),
                CategoryComment = catComments.ElementAt(0),
                CategoryDimension = catDimension.ElementAt(0),

            });



            Context.Companies.AddRange(companies);
            Context.Countries.AddRange(countries);
            Context.Townships.AddRange(townships);
            Context.Stickers.AddRange(stickers);
            Context.CategoryDimensions.AddRange(catDimension);
            Context.CategoryComments.AddRange(catComments);
            Context.CategoryDesignArticles.AddRange(catDesignArt);
            Context.NonRegisteredUsers.AddRange(noRegUser);
            Context.UseCaseRoles.AddRange(usecaseRoles);
            
            Context.Articles.AddRange(articles);
            Context.Emotions.AddRange(emotions);

            Context.ArticleImages.AddRange(articleImages);
            Context.CommentArticles.AddRange(articleComments);
            Context.Users.AddRange(users);

            Context.UserCompanies.AddRange(usercomp);


            Context.AllUserUseCases.AddRange(allUsersUseCase);
            ///
            Context.ArticleUserEmotions.AddRange(artUsEmot);


            Context.SaveChanges();

            return StatusCode(201);


        }
        



    }
}
