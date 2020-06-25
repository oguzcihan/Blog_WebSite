using BlogSite.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                
                new Category(){KategoriAdi="Blog"},              
                new Category(){KategoriAdi="C# Programlama"},
                new Category(){KategoriAdi="Java"},
                new Category(){KategoriAdi="Python"},
                new Category(){KategoriAdi="Asp.Net Mvc"},
               

            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }

            context.SaveChanges();
            List<Blog> bloglar = new List<Blog>()
            {
                new Blog(){Baslik="Scrum nedir nasıl uygulanır?", Icerik=" Scrum Ken Scwaber ve Jeff Sutherland tarafından küçük şirketlerin ve büyük şirketlerin proje üretirken ortaya çıkan karmaşık ürünlerden daha çok verim almak ürünlerin daha başarılı kolay bir şekilde yapılmasını aynı zamanda projede süreklilik sağlamak için geliştirilmiştir.Bu yöntem proje geliştirme ve alıcı isteğine göre projeyi düzenleme, yönetim için geliştirildi. Dünya çapında yaygın olarak kullanılan yöntemin bazı kullanım alanları şöyledir. Geçerli proje satış pazarları, teknoloji ile alakalı ve proje yeteneklerini araştırma tanımlama Proje ile ilgili geliştirmeler ve çeşitli iyileştirmeler yapmak. Proje ile başka bir geliştirme yapma ve bu geliştirmeleri yayınlamak, Bulut ortamlarından birçoğunun geliştirilmiş ve kullanılması, Projede bulunan sürekli geliştirme olanağı Scrum günlük hayatımızda birey ve toplum olarak kullandığımız her şeyi geliştirmek için kullanılmaktadır. Günlük hayattan örnek verecek olursak, yazılım, donanım, gömülü sistemler, otonom araçlar, pazarlama ve organizasyonel tüm işlerde rahatlıkla kullanılabilmektedir. Scrum aslında küçük takımlarla çok daha başarılı bir şekilde uygulanmaktadır. Bir veya birden fazla takımile de Scrum uygulayıp aynı ortamda çalışılabilir, hatta bu takımlar kendi aralarında birbiriyle bilgi alışverişi yapıp sorunları daha kolay ve hızlı bir şekilde çözebilir."
                ,altBaslik="Sonuç olarak...",Sonuc="Scrum ile geliştirme yapmak ekipler açısından büyük bir ayrıcalık olmaktadır. Ekibin başarı yüzdesini artırmak için Scrum ile geliştirme yöntemi kullanılabilir.Scrum büyük şirketlerin karmaşık olan proje üretim aşamalarını biraz daha düzene sokmak için geliştirilmiş bir yazılım süreci metodolojisidir. Scrum yöntemi genel olarak büyük projelerde kullanılır. Günümüzde en yaygın metotlardan birisidir. Agile yöntemlerini uygulayan firmalar yaptıkları projelerde başarılı olma seviyesini büyük oranda artırmışlardır.Scrum karmaşık yapılı projeleri basit hale getirmek için bazı kurallar belirlemiştir. Şeffaflık, gözlem ve adaptasyon üst safhada olmalıdır. Kendine has beş değeri vardır. Açıklık, bağlılık, cesaret, odak ve saygıdan oluşmaktadır. Raporda bu özellikler ayrıntılı olarak ele alındı. Bu yöntemde her şey takım üzerine kurulmuştur. En öncelik bir takım olmaktır. Daha sonra proje sahibi gelmektedir. Proje sahibi olmadan Scrum olmayacağı için mutlaka ortada bir proje veya ürün sahibi olması gerekir. Geliştirme takımı ve proje sahibi karakterleri ayrıntılı olarak anlatıldı. Bu yöntemi diğer yöntemlerden ayıran projede bir master olmasıdır. Master bizim takımımızda projeye başkanlık eden kişidir. Bu karakterin projeye büyük katkısı vardır. Master özellikleri ürün sahibine ve geliştirme takımına hizmetleri de ayrıntılı olarak anlatıldı. Sonrasında scrumda en önemli özellik olan olmazsa olmazlardan sprint olayı gelmektedir. Sprint olayında takım içinde projeye dair yapılacak iş listeleri, değerlendirmeler, toplantılar gibi projeyi oluşturan durumlar ele alındı. En son olarak bitti durumu yani proje sonlandıktan sonra tüm takımın ortak bir bitti tanımında birleşmesi gerekir. Scrum özet olarak uygulaması bu şekildedir.",EklemeTarih=DateTime.Now,Resim="scrum.jpg",CategoryId=1,Anasayfa=true},

                new Blog(){Baslik="Bilgisayar Mühendisleri ne iş yapar?", Icerik="Bilgisayar mühendisi çip, analog sensör, devre kartı, klavye, modem ve yazıcılar dahil olmak üzere bilgisayar donanım ve ekipmanlarının araştırılması, tasarlanması, geliştirilmesi ve test edilmesinden sorumludur.Temel olarak yazılım, programlama ve algoritma ile ilgilenir.Bilgisayar mühendisliğinden mezun olan birine çoğu zaman boş kalmaz hemen iş bulur gibi cümleler kurulmaktadır. Bunlar son derece yanlış yaklaşımlardır. Bilgisayar mühendisliğinden mezun olup iş bulamayıp başka alanlara yönelen bir sürü insan vardır. Buradaki amaç kendini geliştirmektir. Kendinizi geliştirip sürekli yeni bilgilere açık olduğunuz sürece güzel bir hayatınız olabilir. Bilindiği üzere teknoloji çağında olduğumuz için Bilgisayar mühendisliği bölümü bir çok insan tarafından tercih edilmektedir. O kadar çok insan tercih ediyor ki sınıflarda bilgisayardan hiç anlamayan öğrenciler bile olabiliyor. Bu yüzden Bilgisayar mühendisliği bölümü yazarken derslerine bakıp yazmak gerekir. Gerçekten bu işi yapmak isteyen insanların gelmesi gelecekteki hayatınız için bir hayli önem taşımaktadır.",altBaslik="Özet olarak...",Sonuc="Bilgisayar mühendisliği çok özel bir meslektir. Derslerini geçmek bile büyük bir çaba istemektedir. Bu bölümden mezun olduğunuzda kendi başınıza program yazabilir hale gelmeniz gerekmektedir. Algoritma mantığını bir kere öğrendiğinizde diğer programlama dillerinin syntax'ları zor gelmeyecektir. Bu yüzden çok çalışıp iyi bir mühendis olmak gerekmektedir.",EklemeTarih=DateTime.Now.AddDays(-10),Resim="bilgisayar.jpg",CategoryId=2,AnasayfaSag=true},
                new Blog(){Baslik="Oracle nedir?", Icerik="Oracle ABD’ de nin Kaliforniya eyaletinde ortaya çıkmış dünyanın Microsoft’tan sonra gelen ikinci büyük yazılım firmalarından birisidir. 1997 yılında kurulmuş ve günümüze kadar başarılı bir şekilde gelmişlerdir. Java programlama dilinin şu andaki halinin mimarisinden Oracle sorumludur. 145 ülke de bir sürü yazılım aracı sunmuşlardır ve hizmet etmeye devam etmektedirler. Oracle bir şirket ismi değildir aynı zamanda ilişkisel veri tabanı yönetim sistemleridir. Oracle veri tabanı ile büyük verileri güvenle bir sunucuda tutmak için bulut sistemleri kurmuştur ki günümüzde big data konusuna bir hayli önem verilmektedir. Hatta günümüzde son gelişmelerden biri Oracle’ın kendi kendine yöneten veri tabanı yaptığı bilgisidir. Şirket 2018 yılında sektörde kendi kendine yama yapabilen, kendi kendine ayarlama yapabilen ve kendini yöneten ilk veri tabanı olan Oracle Autonomous Database’i piyasaya sürmüştür.Oracle şirketinin ilgilendiği birçok alan vardır. Bu alanlardan rakiplerine fark attığı en önemlisi veri tabanı yönetim sistemleridir. Veri tabanı yönetim sistemlerinde bu kadar iyi olmalarının sebebi işlerini ve şirketlerini eksiksiz verilen sorumlulukları harfiyen yerine getirmeleri ile sağlanmıştır. 1986 yılında Oracle NASDAQ borsasında işlem gören, halka açık bir şirket haline geldi. Halka açılması aslında insanların hangi konularda eksik olduğu ne gibi teknolojik çıkışlara ihtiyacı olduğunu belirlemesine yol açtı. 1987 yılında No Contest dergisinde dünyanın en büyük veri tabanı yönetim şirketi olarak servis edildi. O dönemde 55 ülkede 4.500 son kullanıcı ile dünyanın en büyük veri tabanı yönetim şirketi seçildiler. Piyasada veri tabanı yönetimi sunan birçok şirket bulunmasına rağmen Oracle müşterilerin kendilerini tercih etmesini sağlamıştır. Bu tercihin sebebi yapılan işlemlerin boyutunun fazla olmasına rağmen günümüzde buna big data deniyor bu big data çok aşır büyük boyutlarda olan bir veridir. Örneğin twitter uygulamasında arka planda o kadar büyük veriler vardır ki veri tabanlarına sığmayacak kadar bunların çözümünü Oracle büyük boyutlu verileri hızlı bir şekilde bulut sistemlerine atabilmesi ve orada saklayabilmesidir. Bu işlemlerde sürekli aktif olarak rol alması Oracle’ın diğer yazılım firmalardan en büyük farkıdır. Oracle yüksek kalitede hizmet verdiği gibi ekonomik ve düşük maliyetle de önce çıkmaktadır. Yaptığı işlerde kalite ön plandadır alanında en iyi olduklarını piyasaya kanıtlamışlardır. Bu özellikler düşük maliyet ve ekonomik paketlerle desteklendiğinde Oracle tercih etmemek için ortada hiçbir sebep kalmamaktadır. ",altBaslik="Özet olarak...",Sonuc=" Özellikle kurumsal şirketler için yapılan çalışmalarda veri tabanındaki hız, güvenilirlik ve ölçeklendirilebilirlik çok yüksektir. Firmaların programlarını kullanılabilirlik düzeylerini yükseltmek ve bunu özel bulutlar kümeleme konsolide etme olarak işleme alırlar. Boşta kalan verileri ortadan kaldırdıkları gibi bütün yedeklerini de ortadan kaldırma işlemleri hız ve destek açısından en yüksek safhadadır. Kurumsal şirketlerde tüm verileri düşül maliyetli depolama birimleri ile sıkıştırarak genel performansı hızlandırmak için otomatik yapılan işlemleri sıraya koyar. Bu verilerin güvenliği için tüm yazılımı baştan aşağıya tarama yapar ve tüm standartları harfiyen uygular. Oracle tercih edilme sebebi ve diğer firmalardan farkı kurumsal şirketlerin çalışanlarına yük bırakmamak ve çalışanların mutlu, istekli çalışmasını sağlamaktır. Büyük şirketler büyük projelere girerken çalışanlarından tam anlamıyla yararlanmak ister Oracle veri tabanı yönetim sistemleri ile büyük şirketlere tam olarak bunu vaat etmiştir. Personellerinin hızlı ve yeterli bir performans içinde çalışması, onların kafasını yoracak sorunların çıkmaması gerekir. Her personelin ne yaptığını ne yapacağı kaydını tutmak için Oracle sistemleri kullanmak gerekir.",EklemeTarih=DateTime.Now.AddDays(-10),Resim="oracle.jpg",CategoryId=3,AnasayfaSag=true}

            };
            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();
            List<Projeler> Projeler = new List<Projeler>()
            {
                new Projeler(){ ProjeAdi="StockR", ProjeDili="C#", Resim="stok.jpg", Detay="C# dilinde 2019 yılında yaz stajında yazılmış bir otomasyondur. Stok takip etmek için kullanılmaktadır.Projeyi github adresinden inceleyebilirsiniz.", Url="https://github.com/oguzcihan/StockR",EklemeTarih=DateTime.Now,ProjelerSag=true},
                 new Projeler(){ ProjeAdi="Araç Satış Otomasyonu", ProjeDili="C#", Resim="aracsatis.jpg", Detay="C# dilinde 2019 yılında ekip halinde yazılmış bir otomasyondur. Ayrıntılı olarak Githubtan inceleyebilirsiniz.", Url="https://github.com/oguzcihan/Arac-Satis-Otomasyon",EklemeTarih=DateTime.Now,ProjelerSol=true},
                  new Projeler(){ ProjeAdi="Mini Oyun", ProjeDili="Java", Resim="oyun.jpg", Detay="Android Studio ile java dilinde yazılmış mini bir oyun uygulaması", Url="https://github.com/oguzcihan/Mini-Oyun",EklemeTarih=DateTime.Now,ProjelerSol=true}
            };
            foreach (var item in Projeler)
            {
                context.Projeler.Add(item);
            }
            context.SaveChanges();

           
            //roller

            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "yönetici" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "kullanıcı" };
                manager.Create(role);
            }
            //user
            if (!context.Users.Any(i => i.Name == "oguzcihan"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "oguz",
                    Surname = "cihan",
                    UserName = "oguzcihan",
                    Email = "oguzcihan12@gmail.com"
                };

                manager.Create(user, "Oguz.chn1905");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}