using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        #region Ders 29 - Ajax Tabanlı Veri Alma

        //Ajax, client tabanlı istek yapmamızı sağlayan ve bu isteklerin sonucunu almamızı sağlayan JavScript tabanlı bir mimaridir. Bunun için JQuery kullanılacak.
        /*ProductController içerisindeki CreateProduct action metodunun view'inden Ajax tabanlı işlemler gerçekleştirilecek ve istek ProductController içerisindeki
        *VeriAl action metodu tarafından gönderilecektir. Veri gönderimi için Post kullanacağımızı unutmamak gerekir.
        *
        * Şimdi CreateProduct.cshtml içerisini client tabanlı işlem yapabilecek hale getirelim.
        *
        */


        #endregion

        #region Ders 28 - Header Üzerinden Veri Alma

        /* Burada header içine verinin nasıl yerleştirildiğini, gönderilen verinin nasıl yakalandığını inceleyeceğiz.
         * Kullanıcıdan veri alabilmek için kullanıcı tarafından request almamız gereklidir. Kullanıcının yapmış olduğu request ile, QueryString, RouteParameter veya Form ile
         * değerler taşıyabiliyoruz. Ek olarak headerlar ile de veriler taşınabilmektedir. Kullanıcının göndermiş olduğu request'de (HTTP isteğinde) bulunan veridir.
         * İlgili istek ile alakalı nitelikleri barındırır. Hatta ileride autherization gibi işlemlerde headerları kullanacağız.
         * Dolayısıyla headerlar isteklerde belirli verileri taşımamıza olanak sağlayan nitelendirici kalıplardır. Burada da custom header tanımlayabiliyoruz.
         * Headerlar ile ilgili örneklendirme için şuan tarayıcı kullanılamayacaktır. Tarayıcılar headerları manuel olarak doldurmamıza müsaade etmiyor.
         * Bu sebeple Postman ile endpointlere request gerçekleştireceğiz. URL yazıp, Header kısmından müdahale edeceğiz ve yakalayacağız.
         */

        /* "endpoints.MapDefaultControllerRoute();" ve "endpoints.MapControllerRoute("CustomRoute", "{controller=Home}/{action=Index}/{a}/{b}/{id}");"
         * rotalarını kullanarak ilgili sunucuya belirli headerlarımız ile istekte bulunacağız ve yakalamaya çalışacağız.
         */

        #region 1 - Request Üzerinden Header Yakalama

        //Başka yöntemler de vardır ancak genel olarak headerlar Request üzerinden yakalanır. Bu şekilde daha temiz çalışma yapılır.

        public IActionResult GetProducts()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult VeriAl() //İster Put, ister Get, ister Post türünden yap; headerda bir data var ise buraya taşınacaktır. Daha hızlı istek için get seçildi.
        {
            var headers = Request.Headers.ToList();
            return View();
        }
        #endregion

        #endregion Ders 28 Bitiş

        #region Ders 27 - Route Parameter Üzerinden Veri Alma

        /*
         Route denilen şey MVC uygulamalarında rota belirlemek için Startup.cs içerisinde tanımlanan middleware
         içerisinde endpointlerdir. Bu rota parametreleri ile (aynı QueryString gibi ) değerler taşınabilmektedir.
         Custom parametreler tanımlayacağız.

        QueryString'den farkı;
        
                                                                QueryString:                    /user?name=value
                                                                Route Parametreleri :           /user/value
        rotalara parametreler gömülür ve güvenlik artırılır.
         */


        #region 1 - Rota Parametreleri İle Veri Taşıma

        //Taşıyabilmek için ilgili veriyi karşılayabileceği bir parametreye ihtiyacı vardır.
        //Default olarak id'ye karşılık herhangi bir değer taşınabilir.
        //Id dışında bir değer taşımak için custom route oluşturmak şarttır.
        //Birden fazla rota aynı anda kullanılabilir. (Örneğin default ile custom aynı anda kullanılabilir.)
        //QueryString ile RouteParameters arasındaki fark: Route hangi isim ile URL parametresini karşıladığınızı gizlerken QueryString gizlemez.

        #region 1.1 - Id Taşıma Durumu (Default Hal İle Taşınabilir)

        //Yakalanmasını istediğimiz parametreye uygun action metod parametresi ile yakalarız.
        //Türü int, string veya object olabilir. Önemli olan ismidir.
        //"https://localhost:44305/product/verial/5" urlsini örnek olarak girelim (breakpoint ile)
        //object boxing yapar veri görünmez. Türü string (veya int) yaparsak görülür.


        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string id)
        //{
        //    return View();
        //}

        #region 1.1.1 -  Request Üzerinden (Parametre Varken) Yakalama

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string id)
        //{
        //    var values = Request.RouteValues; //Route parametrelerini ValueDictionary olarak getirir. Controller, action ve değer yakalanır, değişkene atanır.
        //    return View();
        //}

        #endregion 1.1.1 Bitiş

        #endregion 1.1 Bitiş

        #region 1.2 - Özel Rota İle Değer Taşıma

        //Startup.cs içerisinde app.UseEndpoints içerisinde endpoints.MapDefaultControllerRoute() denilirse sistem tarafından default olarak tanımlanmış rota kullanılır.
        //Eğer endpoints.MapControllerRoute() dersek custom rota oluşturulabilir. Şimdi Startup.cs içerisine git ve endpoints.MapControllerRoute() tanımlamasına bak
        //"endpoints.MapControllerRoute("CustomRoute", "{controller=Home}/{action=Index}/{a}/{b}/{id}");" tanımlaması yapılmıştır. (Boşluk kullanma, çalışmaz.)
        //Burada sırasının önemi vardır. Her bir parametre kendisine denk gelen veriyi karşılar.
        //Controller dosyası içerisindeki action metod parametreleri için sıralama önemli değildir. URL'deki sıralaması önemlidir.
        //Şimdi bu rotaya istek gönderelim.

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string a, string b, string id)
        //{
        //    return View();
        //}

        #region 1.2.1 - Custom URL'deki Parametre Değerlerini Yakalama

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string a, string b, string id)
        //{
        //    var values = Request.RouteValues; //Girilen URL'deki parametreleri yakalar ve values içerisine atar.
        //    return View();
        //}

        #endregion

        #endregion 1.2 Bitiş

        #region 1.3 - Tür Üzerinden URL Parametresini Yakalama

        //"https://localhost:44361/product/verial/3/mehmet/743563" isteği yapıldığında VeriAl action metodunun datas parametresinin verileri yakaladığı breakpoint yardımı ile görülür.

        //public class RouteData //Yakalama için tanımlanan tür
        //{
        //    public int A { get; set; }
        //    public string B { get; set; }
        //    public string Id { get; set; }
        //}

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(RouteData datas) //Tür şeklindeki paratmetre ile gelecek olan endpoint verilerinin yakalanması
        //{
        //    return View();
        //}


        #endregion 1.3 Bitiş

        #region 1.4 - Oluşturulan URL'lerdeki Route ve QueryString Değerlerine TagHelper Yardımı ile Değer Atama

        //Custom Route'umuzu ve Default Route'umuzu kullanacağız.
        //CreateProduct.cshtml içerisinde bir "<a asp-action="Index" asp-controller="Home" asp-route-a="ahmet" asp-route-b="mehmet" asp-route-id="123"></a>" tag'i oluşturalım (formun dışında, alta)
        //Yukarıda "a" tag'ı ve "asp-action-..." ile tanımlanan değerler rotada parametre olarak tanımlandığından dolayı URL içerisinde yerleştirilecektir.
        //Ayriyetten (örneğin "asp-route-x="...." şeklinde bir şey ekledik varsayalım) rotada yoksa (Startup.cs içerisindeki custom rotamızda) QueryString olarak yerleştirilir.



        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl()
        //{
        //    return View();
        //}




        #endregion 1.4 Bitiş

        #endregion 1 Bitiş




        #endregion Ders 27 Bitiş

        #region Ders 26 - QueryString Üzerinden Veri Alma


        #region 5 - Parametrelere Karşılık Gelecek Property İsimlerini İçeren Tür İle QueryString Değerini Okuma

        //Gelecek olan dataları karşılamak için bir model oluşturulur.
        //QueryString olarak "https://localhost:44305/product/verial?a=5&b=10&c=15&d=20" kullanıldı.

        //public class GelenQueryData
        //{
        //    public string A { get; set; }
        //    public string B { get; set; }
        //}

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(GelenQueryData data) //parametrelere uygun değerler model tarafından eşleştirilir.
        //{
        //    return View();
        //}

        #endregion

        #region 4 -  Genel Request İçine Girerek QueryString Değerlerini Okuma

        //Request içerisine girmek için base classdan gelen Request veya HttpContext.Request property'si kullanılabilir.
        //"Request." dendiğinde Query ve QueryString geldiği görülür.
        //"https://localhost:44305/product/verial?a=5&b=10&c=15&d=20" adresine gidip, breakpoint koyup queryString, a ve b'nin değişken değerlerini inceleyin.


        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl()
        //{
        //    var queryString = Request.QueryString; //true döner ve query var mı yok mu kontrol edebilirsin
        //    var a = Request.Query["a"].ToString();
        //    var b = Request.Query["b"].ToString();
        //    return View();
        //}
        #endregion


        #region 3 - QueryString'e Birden Fazla Veri Girme (& operatörü)

        //"https://localhost:44305/product/verial?a=5&b=10&c=15&d=20" urlsini girdik
        //a'yı karşılayan bir parametre olduğu için a değeri tutuldu ama diğerleri karşılanmadığından tutulmadı
        //eğer b de tutulmak isteniyorsa parametre olarak "string b" eklenmelidir.
        //aynı url girildiğinde b değerinin de ilgili parametrede tutulduğu görülür.

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string a, string b)
        //{

        //    return View();
        //}

        #endregion


        #region 2 - QueryString Değerlerini Yakalama (VeriAl(string a))

        //Parametre üzerinden ilgili QueryString'e karşılık gelen bir parametre tanımlanabilir.
        //a örneğinden devam edelim.
        //Default değer gerektirmeksizin yalnızca parametre girerek QueryString değerlerini yakalayabiliriz.
        //"https://localhost:44305/product/verial?a=5" urlsine gidilirse verial breakpointi tetiklenir ve a verisi gelir.

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl(string a)
        //{

        //    return View();
        //}

        #endregion


        #region 1 - Genel Giriş
        //Bazı veriler gizli değildir ve UI üzerinde taşınabilir.
        //Hedef endpoint'e güvenlik gerektirmeyen verileri QueryString yapılanması ile taşıyabiliyoruz.
        // Örneğin "https:/......com/sehir/ankara?ilce=2" tanımlanması gibi.
        // Yukarıdaki örnek querystring örneğidir.
        //QueryString hem kullanıcılardan veri alma hem de yazılımsal operasyonlar arasında iletişim için kullanılır.
        //Bu derste kullanıcıdan veri alma için kullanılacaktır.
        //QueryString request'inin türü her ne olursa olsun (get, post, put, delete)  QueryString değeri taşınabilir.

        /*
        Şimdi VeriAl isimli get türünden action metoduna breakpoint koyup tarayıcı üzerinden get isteğinde bulunalım.
        İstekte bulunurken QueryString değerlerini ilgili URL'e yerleştirelim.
        Bu örnekte "https://localhost:44305/product/verial?a=5" URL'sini kullandık.
        VeriAl için konulan endpoint adrese gittikten sonra tetiklendi.
        Request'teki QueryString değerleri tetiklendiği için action metoda ulaştı anlamını taşır.
        Dolayısıyla istediğimiz gibi bu QueryString değerlerini istediğimiz şekilde tüketebiliriz.
        */


        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //public IActionResult VeriAl()
        //{

        //    return View();
        //}
        #endregion


        #endregion

        #region Ders 25 - Form Üzerinden Veri Alma

        #region Form Üzerinden Bind Edilmiş Veriyi Alma

        ////İlgili view'de input işlemine karşılık bir bind işlemi gerçekleştirmek gereklidir.
        ////Bunun için view içerisinde model belirlemek gerekir.
        ////Burada Product model olarak kullanılacaktır.
        ////View içerisinde her bir bileşen "asp-for" TagHelper'ı ile işaretlenir
        ////Bind işlemi asp-for ile gerçekleştirilmiş olunur.

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult VeriAl(Product product)
        //{
        //    var nameProduct = product.Name;
        //    var quantityProduct = product.Quantity;
        //    return View();
        //}
        #endregion


        #region Veriyi Karşılayabilecek Bir TÜR İle Veri Alma
        //Formdan gelecek olan değerlerin "name" etiketlerine karşılık gelen bir class tanımlıyoruz.
        //public class GelenModel
        //{
        //    public string Name { get; set; }
        //    public string Quantity { get; set; }
        //}

        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult VeriAl(GelenModel model)
        //{
        //    return View();
        //}
        #endregion


        #region Veriyi Karşılayabilecek Bir Parametre İle Veri Alma
        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult VeriAl(string Name, string Quantity) //Formdaki ismi Name olan Name parametresi ile bind edilecek demektir.
        //{
        //    return View();
        //}
        #endregion


        #region IFormCollection ile Kullanıcıdan Veri Alma


        //public IActionResult GetProducts()
        //{
        //    return View();
        //}

        //public IActionResult CreateProduct()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult VeriAl(IFormCollection datas)
        //{
        //    var name = datas["Name"];
        //    var quantity = datas["Quantity"];

        //    return View();
        //}


        #endregion

        #endregion

        #region Ders 17 - View Yapılanması ve View'e Veri Taşıma Kontrolleri(ViewBag,ViewData,TempData)

        //public IActionResult Index()
        //{
        //    var products = new List<Product>
        //    {
        //        new Product {Name="a", Quantity = 10},
        //        new Product {Name="b", Quantity = 20},
        //        new Product {Name="c", Quantity = 30},
        //        new Product {Name="d", Quantity = 40}
        //    };

        //    #region 1 - Model Bazlı Veri Gönderimi

        //    //return View(products);

        //    #endregion

        //    #region 2 - ViewBag
        //    //Boxing işlemi yoktur. Data runtime'da şekillenir. Yani dinamiktir.

        //    //ViewBag.ListOfProducts  = products;
        //    //return View();

        //    #endregion

        //    #region 3 - ViewData

        //    //İlgili datayı boxing işlemine tabi tutar öyle taşır.
        //    //Dolayısıyla view tarafında unboxing edilmesi gereklidir.

        //    //ViewData["ListOfProducts"] = products;
        //    //return View();

        //    #endregion

        //    #region 4 - TempData
        //    //Boxing uygular, unboxing bekler.
        //    //Ek olarak action arası yönlendirmeye olanak tanır.
        //    //Veriler cookie ile taşınır.

        //    TempData["ListOfProducts"] = products;
        //    return RedirectToAction("ActionForTempData", "Product" /*Controller ismi*/);


        //    #endregion

        //}


        #endregion

    }
}
