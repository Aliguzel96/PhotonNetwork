### PhotonNetwork


Photon motoru, çok oyunculu oyun geliştirmede uzmanlaşmış bir oyun motorudur. Çevrimiçi oyuna müthiş hız, performans ve daha fazlasını getiren bir dizi ürün, yazılım, teknoloji ve ağ bileşenidir.

Genellikle 20.000.000’dan fazla çevrimiçi kullanıcıya sahip geniş bir ağa sahip olan Photon motoru, çok oyunculu oyun geliştirme için harikadır. Photon motoru Unity ile de son derece iyi çalışır ve oyun geliştirme yöntemlerini daha da kapsamlı hale getirir.

Photon’un repertuarında bazı Real Time ve PUN gibi bazı etkileyici ürünler vardır. Bu ürünlerin neler sunduğuna kısaca bakalım.


## Real Time Ürünü

![photon-motoru-coklu-oyunlar-icin-3dmadmax](https://user-images.githubusercontent.com/56971277/195547326-6ff3563c-e0dd-4dc6-afd8-e39701882734.jpg)

Real Time yani gerçek zamanlı ürünü, öncelikle düşük gecikmeli oyunlarla ilgili sorunları çözmek için çalışan bir ağ oluşturma motorudur. Çapraz platformdur ve Fortnite, Rocket League ve Smite ile aynı kapasitede ki oyunlar için kullanılabilir.

Düşük gecikme çevrimiçi oyunları etkiler ve Photon Realtime, tüm yaygın hızlı tempolu çevrimiçi oyun sorunlarını ortadan kaldırmayı amaçlar.


## PUN (Photon Unity)


![Screen-Shot-2019-02-05-at-3 03 37-PM-650x328](https://user-images.githubusercontent.com/56971277/195548046-4e194e8e-02f2-42f3-9e05-373851eb90d3.png)

- PUN, ‘Photon Unity Networking’in kısaltmasıdır. Oyuncuların ve oyun geliştiricilerin Unity çerçevesini Photon ile kolayca entegre etmelerinin bir yoludur. Bunu yapmak, yüksek sunucu hızları, gecikmesiz odalar ve uyumlu bir ağ için bileşenler oluşturmaya yardımcı olur.

Realtime ile birlikte PUN, oyunların sorunsuz çalışmasına olanak tanıyan sunucuları, odaları ve diğer işlevleri değiştirmenin harika ve hızlı bir yoludur.

## Photon Motoru Kurma ve Unity Oyun Motoruna Bağlama

İlk adım, ücretsiz bir Photon Unity (PUN) hesabına kaydolmak ve oturum açmaktır. Photon Unity Networking’in (PUN) kurulumu gerçekten çok kolaydır.

PUN’u yeni bir projeye aktardığınızda PUN Sihirbazı açılır. Alternatif olarak Window > Photon Unity Networking menüsünden de açabilirsiniz.

Siteye giriş yaptıktan sonra Create New App deyip burada bulunan APP ID'yi Pun Sihirbazına vermek gerekli tüm bağlantıları sağlayacaktır.


ref: https://www.3dmadmax.com/oyun_motor/cok-oyunculu-oyunlar-yapmak-icin-photon-motoru-sizi-bekliyor/#:~:text=PUN%20(Photon%20Unity),i%C3%A7in%20bile%C5%9Fenler%20olu%C5%9Fturmaya%20yard%C4%B1mc%C4%B1%20olur.


## (&#x1F535;) Player Prefab'ının gerektirdiği özellikler ve özelliklerin sahneler arasında oyuncular bazında aktarılması;

(&#x1F53D;)Oyuncuya manuel olarak eklenen scriptler dışında Photon sınıfından türeyen ön tanımlı bazı scriptlerinden eklenmesi gerekmektedir.
- Bu özel scriptler sayesinde bir oyuncuda bulunan özellikler diğer oyuncunun sahnesi tarafından da görüntülenebilmektedir.
     (&#x1F536;)Photon View (Temel script)
     (&#x1F536;)Photon Transform View (Transform işlemlerinin diğer oyuncularda görüntülenebilmesi için)
     (&#x1F536;)Photon Rigidbody View ..... ve bunun gibi özel scriptler
     

(&#x1F53D;)Bu scriptler dışında sahnede yer alacak oyuncuları da özel bir şekilde aktarıp görüntülememiz gerekmektedir.
    Örneğin sahnemizde bulunan bir oyuncuyu baz alacak olursak bu oyuncunun da diğer oyuncular tarafından görüntülenebilmesi gerekir.
Bunu sağlamak için Assets kök dizini içerisine "Resources" isimli bir klasör oluşturuyor ve kullanmak istediğimiz "Player" objesini buraya sürükleyip bırakarak bir prefab sağlamış oluyoruz. Bu oyuncuyu script üzerinde rahatlıkla Instantiate edebilir durumu gelmiş oluyoruz. 


(&#x1F534;)Not: Script tarafında oyuncu ile ilgili bazı işlemler yaparken, özellikle fizik işlemleri gibi, PhotonView'in o objeye olan aidiyetini belirtmezsek sahnede bulunan bir oyuncunun yaptığı işlemler aynı odada ancak başka bir sahnede bulunan bir oyuncu tarafından yakalanır ve aynı komutlar onun için de işlenir. Bunun önüne geçebilmek için script tarafında "IsMine" sorgusunu yapmamız gerekmektedir.



