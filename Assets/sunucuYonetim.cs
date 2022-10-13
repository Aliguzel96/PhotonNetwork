using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class sunucuYonetim : MonoBehaviourPunCallbacks
{

    void Start()
    {
        //sunucuya baðlan
        //lobiye baðlan
        //odaya baðlan

       PhotonNetwork.ConnectUsingSettings(); //seervera baðlanma isteði yapýldý


    //    PhotonNetwork.JoinLobby();  //Lobiye baðlan
    //    PhotonNetwork.JoinRoom("oda ismi"); //oda_isimli odaya baðlan
    //    PhotonNetwork.JoinRandomRoom(); //rastgele bir odaya baðlan
    //    PhotonNetwork.CreateRoom("oda_ismi", oda_ayarlari); //oda oluþturma
    //    PhotonNetwork.JoinOrCreateRoom("oda_ismi", oda_ayarlari, TypedLobby.Default); //giriþ yap oda yoksa kur
    //    PhotonNetwork.LeaveRoom(); //odadan çýk
    //    PhotonNetwork.LeaveLobby(); //lobiden çýk
    
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
        GameObject objem = PhotonNetwork.Instantiate("Oyuncu", Vector3.zero, Quaternion.identity, 0, null); //odaya oyuncuuyu ekledik
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden çýkýldý");
    }

    public override void OnLeftRoom()
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





    void Update()
    {
        
    }
}
