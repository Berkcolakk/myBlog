1=) Core Katmanýmda  => Gerekli Olan BaseClass'larýmý Oluþturdum ve Core.Repository'de Bir Interface Oluþturup 'ICoreRepository' Adýnda Gerekli Methodlarýmý Yazdým.

2=) DAL Katmanýmda => FinalProjectContext Adý Altýnda DbSetlerimi ve Maplemelerimi Tanýmladým(Yoksa Veritabanýna Ulaþmaz.!)

3=) DTO Katmanýmda => Gerekli Propertylere Sahip DTOlarýmý Oluþturdum Bunlarý Service Katmanýnda Modellerimden DTO'ya Aktarýcam

4=) Mapping Kkatmanýmda => Core Katmanýmdaki Core.Map'ten Miras Almýþtýr ve Entity'lerime Gerekli Sýnýrlandýrmalar Getirdim

5=) Model Katmanýmda => Entitylerimi Oluþturdum ve CoreEntity'den Miras Aldým

6=) Repository Katmanýmda => Core Katmanýmdaki ICoreRepository'den Interface'imi Implemente Ettim ve Dal Katmanýmdan Reference Alarak Constructor(Yapýcý Method)umu Çaðýrýp Instance Aldým..

7=) Service Katmanýmda => Repository'nin Instance'ý Constructor'da Alýndý ve Methodlarýmý Tek Tek Çaðýrýp Entitylerimi DTO'ya Aktararak Methodlar Yazýldý. Kod Kalabalýðý Olmamasý Ýçin IDCHECK Methodu Yazýldý. AccountService Ýçerisinde UI.Attributes.RoleAttribute'un Ýçerisinde Role Tanýmlamalarý Ýçin Gereken Method Yazýldý.

8=) UI Katmanýmda => Service Katmanýmdan Instance Alýnarak Methodlarýma Gereken Parametreleri Verdim ve UI Web Projemin Ýçerisinde Kod Kalabalýðýný Önlemiþ Oldum Fakat Account Login ve Register Kýsmýnda Veritabanýma Gereksiz Query'ler Gönderiyor Bunun Çözümü Araþtýrýlacak.!!!

9=) Utility Katmanýmda => Image.Uploader ve IPRemote Adýnda Ýki Class'ýmý Oluþturdum Fotoðraf Yüklerkenki Methodlar ImageUploader'ýn Ýçerisindedir ve IPRemote'da Ziyaretçi veya Admin Tarafýnda Deðiþiklik veya Oluþturma Olduðubda IP Yakalama Methodlarý Yazýldý.

----------------Kullanýlan Teknolojiler--------------

1=)Ajax
=> Comment And Like 
2=)AngularJs
=> Only Used To List Blogs
3=)JavaScript
=> Only Used To Comment
4=)PagedList.Mvc
=> => Only Used To List Blogs
5=)HTML5
6=)CSS3
7=)Bootstrap
8=)Jquery
=> Only Used To Comment
9=)Entity Framework(Code First)


----------------------YAPILACAKLAR-------------------