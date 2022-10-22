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
            GameObject g = Instantiate(coeur, transform);
            g.transform.Translate(-i, 0, 0);
            coeurs.Push(g);
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
