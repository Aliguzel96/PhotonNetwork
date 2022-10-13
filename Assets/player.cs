using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    PhotonView pw;


    void Start()
    {
        pw = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if(pw.IsMine)//kullan�c� ben miyim (bu �ekilde benim yapm�� oldu�um hareketlerden di�er oyuncu etkilenmeyecek)
                     //ayn� scripti ta��salar bile oyuncular� birbirlerinden ay�rm�� olduk
        {
            hareket();
            zipla();

        }

    }

    void hareket()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 20f;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 20f;

        transform.Translate(x, y, 0);
    }

    void zipla()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }

    }
}
