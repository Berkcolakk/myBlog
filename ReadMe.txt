1=) Core Katman�mda  => Gerekli Olan BaseClass'lar�m� Olu�turdum ve Core.Repository'de Bir Interface Olu�turup 'ICoreRepository' Ad�nda Gerekli Methodlar�m� Yazd�m.

2=) DAL Katman�mda => FinalProjectContext Ad� Alt�nda DbSetlerimi ve Maplemelerimi Tan�mlad�m(Yoksa Veritaban�na Ula�maz.!)

3=) DTO Katman�mda => Gerekli Propertylere Sahip DTOlar�m� Olu�turdum Bunlar� Service Katman�nda Modellerimden DTO'ya Aktar�cam

4=) Mapping Kkatman�mda => Core Katman�mdaki Core.Map'ten Miras Alm��t�r ve Entity'lerime Gerekli S�n�rland�rmalar Getirdim

5=) Model Katman�mda => Entitylerimi Olu�turdum ve CoreEntity'den Miras Ald�m

6=) Repository Katman�mda => Core Katman�mdaki ICoreRepository'den Interface'imi Implemente Ettim ve Dal Katman�mdan Reference Alarak Constructor(Yap�c� Method)umu �a��r�p Instance Ald�m..

7=) Service Katman�mda => Repository'nin Instance'� Constructor'da Al�nd� ve Methodlar�m� Tek Tek �a��r�p Entitylerimi DTO'ya Aktararak Methodlar Yaz�ld�. Kod Kalabal��� Olmamas� ��in IDCHECK Methodu Yaz�ld�. AccountService ��erisinde UI.Attributes.RoleAttribute'un ��erisinde Role Tan�mlamalar� ��in Gereken Method Yaz�ld�.

8=) UI Katman�mda => Service Katman�mdan Instance Al�narak Methodlar�ma Gereken Parametreleri Verdim ve UI Web Projemin ��erisinde Kod Kalabal���n� �nlemi� Oldum Fakat Account Login ve Register K�sm�nda Veritaban�ma Gereksiz Query'ler G�nderiyor Bunun ��z�m� Ara�t�r�lacak.!!!

9=) Utility Katman�mda => Image.Uploader ve IPRemote Ad�nda �ki Class'�m� Olu�turdum Foto�raf Y�klerkenki Methodlar ImageUploader'�n ��erisindedir ve IPRemote'da Ziyaret�i veya Admin Taraf�nda De�i�iklik veya Olu�turma Oldu�ubda IP Yakalama Methodlar� Yaz�ld�.

----------------Kullan�lan Teknolojiler--------------

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