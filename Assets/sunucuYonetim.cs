using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;


public class sunucuYonetim : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI birincioyuncuAd;
    public TextMeshProUGUI ikincioyuncuAd;
    public TextMeshProUGUI oyuncuBekleniyor;

    void Start()
    {


       PhotonNetwork.ConnectUsingSettings(); //seervera baðlanma isteði yapýldý


        //    PhotonNetwork.JoinLobby();  //Lobiye baðlan
        //    PhotonNetwork.JoinRoom("oda ismi"); //oda_isimli odaya baðlan
        //    PhotonNetwork.JoinRandomRoom(); //rastgele bir odaya baðlan
        //    PhotonNetwork.CreateRoom("oda_ismi", oda_ayarlari); //oda oluþturma
        //    PhotonNetwork.JoinOrCreateRoom("oda_ismi", oda_ayarlari, TypedLobby.Default); //giriþ yap oda yoksa kur
        //    PhotonNetwork.LeaveRoom(); //odadan çýk
        //    PhotonNetwork.LeaveLobby(); //lobiden çýk
        InvokeRepeating("isimBilgiKontrol", 0, 1f); //belirtilen fonks, 0 -> bekleme süresi, .5f saniyede bir tekrar çalýþ (repeaing: tekrarlamalý bir çaðýrma saðlar)
    }

    public override void OnConnectedToMaster()//Sunucuya baðlanýnca çalýþan fonks
    {
        Debug.Log("Sunucuya baðlanýldý");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye baðlanýldý");
        PhotonNetwork.JoinOrCreateRoom("Udemy_Ali", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);//bir oda oluþtur ve özellikleri þunlar olsun
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya baðlanýldý");
        string oyuncuad = Random.Range(1, 100) + ". Misafir"; //Random isim atama (1. Misafir, 55. Misafir ...)
        GameObject objem = PhotonNetwork.Instantiate("Oyuncu", Vector3.zero, Quaternion.identity, 0, null); //odaya oyuncuuyu ekledik
        objem.GetComponent<PhotonView>().Owner.NickName = oyuncuad; //oyuncuya nickName verme iþlemi
        
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)//Herhangi bir oyuncu oyunu terk ederse
    {
        
        InvokeRepeating("isimBilgiKontrol", 0, .5f);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden çýkýldý");
    }

    public override void OnLeftRoom()//script sahibi odadan çýkarsa
    {
        Debug.Log("Odadan çýkýldý");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Herhangi bir odaya girilemedi");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Rastgele bir odaya girilemedi");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Oda oluþturulamadý");
    }


    void isimBilgiKontrol()//odaya giren oyuncularýn nickName deðerlerini set ettik.
    {

        if (PhotonNetwork.PlayerList.Length == 2)//isimbilgi fonksiyonu start metodu içerisinde tekrarlý olarak çalýþýyor;
                                                 
        {
            oyuncuBekleniyor.text = ""; //ikinci oyuncu da odaya dahil olduðunda bekleniyor yazýsý sýfýrlansýn
            birincioyuncuAd.text = PhotonNetwork.PlayerList[0].NickName;
            ikincioyuncuAd.text = PhotonNetwork.PlayerList[1].NickName;
            CancelInvoke("isimBilgiKontrol");//iki oyuncununda odaya dahil olduðundan emin olduktan sonra fonksiyonun tekrarlý çalýþmasýný kapatmamýz gerekir.
        }
        else
        {
            oyuncuBekleniyor.text = "Oyuncu Bekleniyor...";
            birincioyuncuAd.text = PhotonNetwork.PlayerList[0].NickName; //PlayerList odaya giren oyuncularýn listesi (0 -> ilk giren)
            ikincioyuncuAd.text = "...";
        }


        
    }


    void Update()
    {
        
    }
}
