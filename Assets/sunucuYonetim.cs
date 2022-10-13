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


       PhotonNetwork.ConnectUsingSettings(); //seervera ba�lanma iste�i yap�ld�


        //    PhotonNetwork.JoinLobby();  //Lobiye ba�lan
        //    PhotonNetwork.JoinRoom("oda ismi"); //oda_isimli odaya ba�lan
        //    PhotonNetwork.JoinRandomRoom(); //rastgele bir odaya ba�lan
        //    PhotonNetwork.CreateRoom("oda_ismi", oda_ayarlari); //oda olu�turma
        //    PhotonNetwork.JoinOrCreateRoom("oda_ismi", oda_ayarlari, TypedLobby.Default); //giri� yap oda yoksa kur
        //    PhotonNetwork.LeaveRoom(); //odadan ��k
        //    PhotonNetwork.LeaveLobby(); //lobiden ��k
        InvokeRepeating("isimBilgiKontrol", 0, 1f); //belirtilen fonks, 0 -> bekleme s�resi, .5f saniyede bir tekrar �al�� (repeaing: tekrarlamal� bir �a��rma sa�lar)
    }

    public override void OnConnectedToMaster()//Sunucuya ba�lan�nca �al��an fonks
    {
        Debug.Log("Sunucuya ba�lan�ld�");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye ba�lan�ld�");
        PhotonNetwork.JoinOrCreateRoom("Udemy_Ali", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);//bir oda olu�tur ve �zellikleri �unlar olsun
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya ba�lan�ld�");
        string oyuncuad = Random.Range(1, 100) + ". Misafir"; //Random isim atama (1. Misafir, 55. Misafir ...)
        GameObject objem = PhotonNetwork.Instantiate("Oyuncu", Vector3.zero, Quaternion.identity, 0, null); //odaya oyuncuuyu ekledik
        objem.GetComponent<PhotonView>().Owner.NickName = oyuncuad; //oyuncuya nickName verme i�lemi
        
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)//Herhangi bir oyuncu oyunu terk ederse
    {
        
        InvokeRepeating("isimBilgiKontrol", 0, .5f);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden ��k�ld�");
    }

    public override void OnLeftRoom()//script sahibi odadan ��karsa
    {
        Debug.Log("Odadan ��k�ld�");
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
        Debug.Log("Oda olu�turulamad�");
    }


    void isimBilgiKontrol()//odaya giren oyuncular�n nickName de�erlerini set ettik.
    {

        if (PhotonNetwork.PlayerList.Length == 2)//isimbilgi fonksiyonu start metodu i�erisinde tekrarl� olarak �al���yor;
                                                 
        {
            oyuncuBekleniyor.text = ""; //ikinci oyuncu da odaya dahil oldu�unda bekleniyor yaz�s� s�f�rlans�n
            birincioyuncuAd.text = PhotonNetwork.PlayerList[0].NickName;
            ikincioyuncuAd.text = PhotonNetwork.PlayerList[1].NickName;
            CancelInvoke("isimBilgiKontrol");//iki oyuncununda odaya dahil oldu�undan emin olduktan sonra fonksiyonun tekrarl� �al��mas�n� kapatmam�z gerekir.
        }
        else
        {
            oyuncuBekleniyor.text = "Oyuncu Bekleniyor...";
            birincioyuncuAd.text = PhotonNetwork.PlayerList[0].NickName; //PlayerList odaya giren oyuncular�n listesi (0 -> ilk giren)
            ikincioyuncuAd.text = "...";
        }


        
    }


    void Update()
    {
        
    }
}
