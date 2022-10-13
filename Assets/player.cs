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
            GetComponent<Renderer>().material.color = Color.blue; //her oyuncu ekranda kendini mavi, diðer oyuncularý ise olduklarý renkte görecektir.

            if(PhotonNetwork.IsMasterClient)//Odayý kuran ben isem (odayý ilk oluþturan, ilk giren, playe'e ilk basan)
            {
                //transform.position = new Vector3(3, 0, 3); manuel olarak koord. verilmesi
                transform.position = noktalar[0].transform.position;//dýþarýdan bir pos verilmesi
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

        if(pw.IsMine)//kullanýcý ben miyim (bu þekilde benim yapmýþ olduðum hareketlerden diðer oyuncu etkilenmeyecek)
                     //ayný scripti taþýsalar bile oyuncularý birbirlerinden ayýrmýþ olduk
        {
            hareket();
            zipla();
            atesEt();

        }

    }

    void atesEt()
    {
        if(Input.GetMouseButtonDown(0))//mouse sol tuþu ile ateþ ettirme
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                hit.collider.gameObject.GetComponent<PhotonView>().RPC("darbever", RpcTarget.All, 20);//çarptýðýn nesnenin Photon View comp. al ve RPC uygula(fonks_adi, hedef, parametre)
            }

        }

    }

    [PunRPC]//RPC sisteminde kullanýlan fonksiyonlarý oluþtuturken bu ön özelliði eklemek zorundayýz; bu normal bir fonks deðil, bir RPC fonksiyonu (server tabanlý bir fonks)
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
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * 20f);//anlýk hareket saðlama
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
