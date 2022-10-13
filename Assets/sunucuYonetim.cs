using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class sunucuYonetim : MonoBehaviourPunCallbacks
{

    void Start()
    {
        //sunucuya ba�lan
        //lobiye ba�lan
        //odaya ba�lan

       PhotonNetwork.ConnectUsingSettings(); //seervera ba�lanma iste�i yap�ld�


    //    PhotonNetwork.JoinLobby();  //Lobiye ba�lan
    //    PhotonNetwork.JoinRoom("oda ismi"); //oda_isimli odaya ba�lan
    //    PhotonNetwork.JoinRandomRoom(); //rastgele bir odaya ba�lan
    //    PhotonNetwork.CreateRoom("oda_ismi", oda_ayarlari); //oda olu�turma
    //    PhotonNetwork.JoinOrCreateRoom("oda_ismi", oda_ayarlari, TypedLobby.Default); //giri� yap oda yoksa kur
    //    PhotonNetwork.LeaveRoom(); //odadan ��k
    //    PhotonNetwork.LeaveLobby(); //lobiden ��k
    
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
        GameObject objem = PhotonNetwork.Instantiate("Oyuncu", Vector3.zero, Quaternion.identity, 0, null); //odaya oyuncuuyu ekledik
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden ��k�ld�");
    }

    public override void OnLeftRoom()
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





    void Update()
    {
        
    }
}
