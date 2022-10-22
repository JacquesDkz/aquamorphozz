using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public Player p;
    public GameObject coeur;
    private Stack<GameObject> coeurs;
    private int nb = 0;
    // Start is called before the first frame update
    void Start()
    {
        coeurs = new Stack<GameObject>();
        for(int i = 0; i < p.nbCoeur; i++)
        {
            coeurs.Push(Instantiate(coeur, new Vector3(-i + (float)9.42, (float)4.44, 0), new Quaternion(0,0,0,0), transform));
            nb++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(p.nbCoeur < nb)
        {
            Destroy(coeurs.Pop());
            nb--;
        }
    }

    
}
