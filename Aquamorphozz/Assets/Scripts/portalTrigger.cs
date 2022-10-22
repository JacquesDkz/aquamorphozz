using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTrigger : MonoBehaviour
{   
    public GameObject Player;
    public GameObject cam;

    private Vector3 posCamSousMarin;
    private Vector3 posCamSubMarin;

    private Vector3 posPlayerSousMarin;
    private Vector3 posPlayerSubMarin;

    // Start is called before the first frame update
    void Start()
    {
        posCamSousMarin = new Vector3(-7.74f, 19.29f, cam.transform.position.z);
        posCamSubMarin  = new Vector3(12.12f  ,  37.86f   , cam.transform.position.z);

        posPlayerSousMarin = new Vector3(-7.74f, 19.29f, Player.transform.position.z);
        posPlayerSubMarin = new Vector3(12.12f  ,  37.86f   , Player.transform.position.z);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Perso"))
        {
            cam.transform.position = posCamSousMarin;
            Player.transform.position = posPlayerSousMarin;
        }
    }
}
