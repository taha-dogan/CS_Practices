using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekUygulama2.Models;
using System.Collections.Generic;

namespace OrnekUygulama2.Controllers
{
    public class ProductController : Controller
    {
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

        #region 1.1 - Id Taşıma (Default Hal İle)

        //Yakalanmasını istediğimiz parametreye uygun action metod parametresi ile yakalarız.
        //Türü int, string veya object olabilir. Önemli olan ismidir.
        //"https://localhost:44305/product/verial/5" urlsini örnek olarak girelim (breakpoint ile)
        //object boxing yapar veri görünmez. Türü string (veya int) yaparsak görülür.


        //6:40
        public IActionResult GetProducts()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult VeriAl(string id)
        {
            return View();
        }

        #endregion 1.1 Bitiş

        #region 1.2 - Özel Rota İle Değer Taşıma
        #endregion 1.2 Bitiş

        #endregion 1 Bitiş


        #endregion







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

        //Veri Gönderim Tipleri
        //public IActionResult Index()
        //{
        //    //seed data
        //    var products = new List<Product>
        //    {
        //        new Product {Name="a", Quantity = 10},
        //        new Product {Name="b", Quantity = 20},
        //        new Product {Name="c", Quantity = 30},
        //        new Product {Name="d", Quantity = 40}
        //    };

        //    #region Veri Gönderim Tipleri
        //    #region Model Bazlı Veri Gönderimi

        //    //return View(products);

        //    #endregion

        //    #region ViewBag
        //    //Boxing işlemi yoktur. Data runtime'da şekillenir. Yani dinamiktir.

        //    //ViewBag.ListOfProducts  = products;
        //    //return View();

        //    #endregion

        //    #region ViewData

        //    //İlgili datayı boxing işlemine tabi tutar öyle taşır.
        //    //Dolayısıyla view tarafında unboxing edilmesi gereklidir.

        //    //ViewData["ListOfProducts"] = products;
        //    //return View();

        //    #endregion

        //    #region TempData
        //    //Boxing uygular, unboxing bekler.
        //    //Ek olarak action arası yönlendirmeye olanak tanır.
        //    //Veriler cookie ile taşınır.

        //    TempData["ListOfProducts"] = products;
        //    return RedirectToAction("ActionForTempData", "Product" /*Controller ismi*/);


        //    #endregion
        //    #endregion


        //    #region Tuple

        //    #endregion
        //}

    }
}
