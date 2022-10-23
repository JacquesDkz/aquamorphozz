using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public GameObject self; //On veut manipuler la caméra sans ambiguité

    //Variable qui contient le personnage sur lequel la caméra doit se centrer
    //Pour l'affectation dans Unity, on mettra le personnage dont on voudra qu'il soit suivi au début du jeu
    public GameObject player;
    public GameObject hyene;
    private GameObject persoCourant;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        persoCourant = player;
    }

    // Update is called once per frame
    void Update()
    {
        centrerCameraSur(persoCourant);

        //Exemple avec un changement de camera sur la hyène si 'tab' est pressé
        if (Input.GetKey(KeyCode.Tab) && (persoCourant == player))
        {
            changerPersoCourant(hyene);

        }
        print(persoCourant == hyene);
        print(persoCourant == player);

        if (Input.GetKey(KeyCode.Tab) && (persoCourant == hyene))
        {
            changerPersoCourant(player);
        }


    }

    /*Méthode qui suit le gameobject perso dans le jeu*/
    void centrerCameraSur(GameObject perso)
    {
        self.transform.position = Vector3.SmoothDamp(self.transform.position, perso.transform.position + posOffset, ref velocity, timeOffset);
    }

    /*Méthode à appeler pour changer le personnage à focus*/
    void changerPersoCourant(GameObject persoSuivant)
    {
        persoCourant = persoSuivant;
    }

    void OnKeyDown(KeyDownEvent ev)
    {
        print("KeyDown:" + ev.keyCode);
        print("KeyDown:" + ev.character);
        print("KeyDown:" + ev.modifiers);
    }
}
