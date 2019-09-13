using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseIfModelChanges
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>
            {

                new Category(){Name="Ceket",Description="ceket Urunleri"},
                new Category(){Name="Eldiven",Description="eldiven Urunleri"},
                new Category(){Name="Kask",Description="kask Urunleri"},
                new Category(){Name="Yedek Parca",Description="yedek parca Urunleri"},
                new Category(){Name="Motosiklet",Description="motosiklet"}
            };
            List<Product> products = new List<Product>()
            {

              
                new Product(){Name="Tracer 900 GT",Description="Tracer 900GT, en üst düzey uzun yol deneyimini yaşamak üzere serinin en iyisi bir Sport Tourer isteyen sürücüler için tasarlanmıştır. ",CategoryId=5,Price=86750,IsApproved=true,Stock=10,IsHome=true,Image = "m3.jpg"},
                new Product(){Name="NIKEN GT",Description="Şimdi Yamaha bu yeni cesur konsepti NIKEN GT ile bir sonraki adıma taşıyor. Yükseltilmiş cam, konfor sele, yan çantalar, elcik ısıtıcıları ve daha fazlası ile hava koşullarına karşı daha fazla koruma sunan bu üst düzey Sport Touring aracı en zorlu yol koşullarıyla başa çıkmanızı ve kötü hava koşullarında konfordan taviz vermemenizi sağlar. ",CategoryId=5,Price=116700,IsApproved=true,Stock=10,IsHome=true,Image = "m1.jpg"},
                new Product(){Name="Tracer 900",Description="Sürüş, dünyayı tamamen kavramanızı ve nereye giderseniz gidin yeni yerleri farklı bir perspektiften görmenizi sağlayan bir yaşam biçimidir.Her açıdan gör",CategoryId=5,Price=73500,IsApproved=true,Stock=10,IsHome=true,Image = "m4.jpg"},
                new Product(){Name="Tracer 700",Description="Heyecan verici, çevik bir platformla başlangıç yaparak çok yönlü bir Sport Tourer yarattık: Tracer 700. Bu arka plan nedeniyle çok özel bir model beklemekte haklısınız.",CategoryId=5,Price=59700,IsApproved=true,Stock=10,IsHome=true,Image = "m5.jpg"},
                new Product(){Name="Vexo Motosiklet Eldiveni - Retro Kahverengi",Description="Dört mevsim kullanım, Kolayca çıkarılabilir tamamen su geçirmez hydratex malzemeden yapılmış termal içlik, , Su geçirmeye karşı dayanıklıdır. ",CategoryId=2,Price=305,IsApproved=true,Stock=100,IsHome=true,Image = "e1.jpg"},
                new Product(){Name="VEXO SR-X BLACKFLASH KASK",Description="VEXO SR-X Çeneden Açılır Kask Dıştan açılıp kapanabilen iç güneş vizör, Çizilmeye dayanıklı ön cam, Önde ve tepede havalandırma kanalları, Çıkarılabilir ve yıkanabilir yanak padler, Orjinal kumaş taşıma kılıfı, Ağırlık : 1500 gr.  ",CategoryId=3,Price=250,IsApproved=true,Stock=100,IsHome=true,Image = "k4.jpeg"},
                new Product(){Name="REVIT LEVANTE MONT SIYAH",Description="Touring ve Enduro motosiklet kullanıcıları için tasarlanmış 4 mevsim üstün koruma sağlayar, Hydratex su geçirmez iç astar, Soğuk havalarda üstün koruma sağlayan çıkarılabilir termal içlik, Üzerindeki havalandırma giriş ve çıkışlar sayesinde sıcak havalarda rahat kullanım, Bel, kol ve bilek bölgelerinde vücuda göre ayarlama kayışları, Yaka bölgesinde raylı ve rahat kapatma sistemi, Ön bölgede hem cırtlı hem fermuarlı üstün korumları kapatma sistemi, Revit Connector yeleği ile birleştirme için hazır kancalar, Yüksek yansıtıcı özelliğe sahip reflekte şeritler, Motosiklet pantolonlarıyla sabitleme yapılabilmesi, pantolon fermuarı, 2 dış bir iç su geçirmez cep, VCS fermuarlar ( ön ve arka havalandırma kanalları ), Erkek ve Bayan kesim özel kalıpları mevcuttur. ",CategoryId=1,Price=1902.95,IsApproved=true,Stock=480,IsHome=true,Image = "c3.jpeg"},
                new Product(){Name="REVIT LEVANTE MONT GRI",Description="REVİT LEVANTE MONT Şık, konforlu ve güvenli tasarım, Dört mevsim kullanım, Kolayca çıkarılabilir tamamen su geçirmez hydratex malzemeden yapılmış termal içlik, İçliği çıkartıldığında yazlık file mont haline gelir, CE onaylı omuz ve dirsek koruması, Reflektif şeritler , Bel ve kol bölgesinde ayarlanabilir daraltma , Pantolon ile kombine fermuarı , Su geçirmeye karşı dayanıklıdır. ",CategoryId=1,Price=1992.95,IsApproved=true,Stock=480,IsHome=true,Image = "c3.jpeg"},

                new Product(){Name="Free-M 601 Rose Açık Motosiklet Kaskı",Description="Free-M 661 Açık Motosiklet Kaskı Açılıp kapanabilen Uzun Ön Cam Açılıp kapanabilen Uzun Ön Cam Tepede hava almayı sağlayan havalandırma kanalları Arkada kullanılan havanın dışarı çıkmasını sağlayan hava çıkış kanalları ",CategoryId=3,Price=174,IsApproved=true,Stock=100,IsHome=true,Image = "k1.jpg"},
                new Product(){Name="VEXO SR-X BEYAZ KASK",Description="Kask ",CategoryId=3,Price=250,IsApproved=true,Stock=100,IsHome=true,Image = "k2.jpeg"},
                new Product(){Name="VEXO SR-X PHARMACIST KASK ",Description="VEXO SR-X Çeneden Açılır Kask Dıştan açılıp kapanabilen iç güneş vizör, Çizilmeye dayanıklı ön cam, Önde ve tepede havalandırma kanalları, Çıkarılabilir ve yıkanabilir yanak padler, Orjinal kumaş taşıma kılıfı, Ağırlık : 1500 gr.  ",CategoryId=3,Price=271,IsApproved=true,Stock=100,IsHome=true,Image = "k3.jpeg"},

                new Product(){Name="VEXO SR-X BLACKFLASH KASK",Description="VEXO SR-X Çeneden Açılır Kask Dıştan açılıp kapanabilen iç güneş vizör, Çizilmeye dayanıklı ön cam, Önde ve tepede havalandırma kanalları, Çıkarılabilir ve yıkanabilir yanak padler, Orjinal kumaş taşıma kılıfı, Ağırlık : 1500 gr.  ",CategoryId=3,Price=250,IsApproved=true,Stock=100,IsHome=true,Image = "k5.jpeg"},
                new Product(){Name="REVIT VOLTIAC MONT BAYAN SIYAH",Description="Touring ve Enduro motosiklet kullanıcıları için tasarlanmış 4 mevsim üstün koruma sağlayar, Hydratex su geçirmez iç astar, Soğuk havalarda üstün koruma sağlayan çıkarılabilir termal içlik, Üzerindeki havalandırma giriş ve çıkışlar sayesinde sıcak havalarda rahat kullanım, Bel, kol ve bilek bölgelerinde vücuda göre ayarlama kayışları, Yaka bölgesinde raylı ve rahat kapatma sistemi, Ön bölgede hem cırtlı hem fermuarlı üstün korumları kapatma sistemi, Revit Connector yeleği ile birleştirme için hazır kancalar, Yüksek yansıtıcı özelliğe sahip reflekte şeritler, Motosiklet pantolonlarıyla sabitleme yapılabilmesi, pantolon fermuarı, 2 dış bir iç su geçirmez cep, VCS fermuarlar ( ön ve arka havalandırma kanalları ), Erkek ve Bayan kesim özel kalıpları mevcuttur. ",CategoryId=1,Price=1702.15,IsApproved=true,Stock=20,IsHome=true,Image = "c1.jpeg"},
                new Product(){Name="REVIT VOLTIAC MONT BAYAN KIRMIZI",Description="Touring ve Enduro motosiklet kullanıcıları için tasarlanmış 4 mevsim üstün koruma sağlayar, Hydratex su geçirmez iç astar, Soğuk havalarda üstün koruma sağlayan çıkarılabilir termal içlik, Üzerindeki havalandırma giriş ve çıkışlar sayesinde sıcak havalarda rahat kullanım, Bel, kol ve bilek bölgelerinde vücuda göre ayarlama kayışları, Yaka bölgesinde raylı ve rahat kapatma sistemi, Ön bölgede hem cırtlı hem fermuarlı üstün korumları kapatma sistemi, Revit Connector yeleği ile birleştirme için hazır kancalar, Yüksek yansıtıcı özelliğe sahip reflekte şeritler, Motosiklet pantolonlarıyla sabitleme yapılabilmesi, pantolon fermuarı, 2 dış bir iç su geçirmez cep, VCS fermuarlar ( ön ve arka havalandırma kanalları ), Erkek ve Bayan kesim özel kalıpları mevcuttur. ",CategoryId=1,Price=1702.15,IsApproved=true,Stock=450,IsHome=true,Image = "c2.jpeg"},
               
           
                new Product(){Name="Dainese Tempest Unisex D-Dry Uzun Eldiven Siyah Sarı - Retro Kahverengi",Description=" Sol baş parmağındaki Visor Wiper'den dokunmatik ekranlarla kullanılmak üzere Smart Touch parmak uçlarına ve elbette Dainese'nin kendi D-Dry® zarına sahip olan eldiven yağmurluğa hazır olduğu için yenilikçi özellikler bol miktarda bulunur., , Su geçirmeye karşı dayanıklıdır. ",CategoryId=2,Price=305,IsApproved=true,Stock=100,IsHome=true,Image = "e2.jpg"},

                new Product(){Name="Dainese Tempest Unisex D-Dry Uzun Eldiven Siyah",Description="Tempest Unisex D-Dry® Eldiven'den daha fazla yönlü bir eldiven bulamazsınız. Sol baş parmağındaki Visor Wiper'den dokunmatik ekranlarla kullanılmak üzere Smart Touch parmak uçlarına ve elbette Dainese'nin kendi D-Dry® zarına sahip olan eldiven yağmurluğa hazır olduğu için yenilikçi özellikler bol miktarda bulunur. Dört mevsim kullanım, Kolayca çıkarılabilir tamamen su geçirmez hydratex malzemeden yapılmış termal içlik, , Su geçirmeye karşı dayanıklıdır. ",CategoryId=2,Price=683,IsApproved=true,Stock=100,IsHome=true,Image = "e3.jpg"},
                new Product(){Name="Five Gloves Yazlık Bayan Motosiklet Eldiveni - RS3 Replica Leo Gri",Description="Dört mevsim kullanım, Kolayca çıkarılabilir tamamen su geçirmez hydratex malzemeden yapılmış termal içlik, , Su geçirmeye karşı dayanıklıdır. ",CategoryId=2,Price=271,IsApproved=true,Stock=100,IsHome=true,Image = "e4.jpg"},
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();
            foreach (var item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}