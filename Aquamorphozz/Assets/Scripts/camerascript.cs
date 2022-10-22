using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{   
    public GameObject Player;
    public GameObject cam;

    private float px, py, cz;

    private int posCam = 0;
    private Vector3 posCamSousMarin;
    private Vector3 posCamSubMarin;
    private bool clicked = false;
    //private float moveSpeed = 0.1f;
    //private float scrollSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        posCamSousMarin = new Vector3(-7.74f, 19.29f, cam.transform.position.z);
        posCamSubMarin  = new Vector3(12.12f  ,  37.86f   , cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKey(KeyCode.UpArrow) && !clicked)
        {   
            clicked = true;
            posCam = (posCam + 1) % 2;

            switch (posCam)
            {
                case 0:
                
                    transform.position = posCamSubMarin;
                    break;

                case 1:
                    transform.position = posCamSousMarin;
                    break;
 
            }

            Player.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Player.transform.position.z);
        }
        else
        {   
            px = Player.transform.position.x;
            py = Player.transform.position.y;
            cz = cam.transform.position.z;

            transform.position = new Vector3(px, py, cz);

        }

        if (!Input.GetKey(KeyCode.UpArrow))
        {
            clicked = false;
        }

        /*cam.transform.position.x = px;
        cam.transform.position.y = py;*/

    }
}
