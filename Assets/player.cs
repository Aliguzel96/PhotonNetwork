using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    PhotonView pw;
    int saglik = 100;
    public GameObject[] noktalar;

    void Start()
    {
        pw = GetComponent<PhotonView>();
        


        if (pw.IsMine)
        {
            GetComponent<Renderer>().material.color = Color.blue; //her oyuncu ekranda kendini mavi, di�er oyuncular� ise olduklar� renkte g�recektir.

            if(PhotonNetwork.IsMasterClient)//Oday� kuran ben isem (oday� ilk olu�turan, ilk giren, playe'e ilk basan)
            {
                //transform.position = new Vector3(3, 0, 3); manuel olarak koord. verilmesi
                transform.position = noktalar[0].transform.position;//d��ar�dan bir pos verilmesi
            }
            else
            {
                //transform.position = new Vector3(-3, 0, 3);
                Debug.Log("ben client degilim");
                transform.position = noktalar[1].transform.position;
            }
        }

       
    }

    // Update is called once per frame
    void Update()
    {

        if(pw.IsMine)//kullan�c� ben miyim (bu �ekilde benim yapm�� oldu�um hareketlerden di�er oyuncu etkilenmeyecek)
                     //ayn� scripti ta��salar bile oyuncular� birbirlerinden ay�rm�� olduk
        {
            hareket();
            zipla();
            atesEt();

        }

    }

    void atesEt()
    {
        if(Input.GetMouseButtonDown(0))//mouse sol tu�u ile ate� ettirme
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                hit.collider.gameObject.GetComponent<PhotonView>().RPC("darbever", RpcTarget.All, 20);//�arpt���n nesnenin Photon View comp. al ve RPC uygula(fonks_adi, hedef, parametre)
            }

        }

    }

    [PunRPC]//RPC sisteminde kullan�lan fonksiyonlar� olu�tuturken bu �n �zelli�i eklemek zorunday�z; bu normal bir fonks de�il, bir RPC fonksiyonu (server tabanl� bir fonks)
    void darbever(int darbegucu)
    {
        saglik -= darbegucu;
        Debug.Log("Kalan Saglik: " + saglik);

        if(saglik <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
        
    }

    void hareket()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * 20f);//anl�k hareket sa�lama
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * 20f);
    }

    void zipla()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }

    }
}
