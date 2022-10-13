using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class Fonksiyonlar : MonoBehaviourPunCallbacks
{

    void Start()
    {
        //sunucuya baðlan
        //lobiye baðlan
        //odaya baðlan

    //    PhotonNetwork.ConnectUsingSettings(); //seervera baðlanma isteði yapýldý
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
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye baðlanýldý");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya baðlanýldý");
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
