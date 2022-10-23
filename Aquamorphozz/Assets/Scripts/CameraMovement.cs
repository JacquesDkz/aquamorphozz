using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject self; //On veut manipuler la caméra sans ambiguité

    //Variable qui contient le personnage sur lequel la caméra doit se centrer
    //Pour l'affectation dans Unity, on mettra le personnage dont on voudra qu'il soit suivi au début du jeu
    public GameObject player;
    public GameObject hyene;
    private int idPerso;
    private GameObject persoCourant;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    private float lastTimeEventWereCalled;
    private float currentTimeEventIsCalled;
    private static float minTimeBetweenEvents = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        persoCourant = player;
        idPerso = 0;
        lastTimeEventWereCalled = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        centrerCameraSur(persoCourant);

        //Exemple avec un changement de camera sur la hyène si 'tab' est pressé

        currentTimeEventIsCalled = Time.realtimeSinceStartup;
        
        if (Input.GetKey(KeyCode.Tab) && (currentTimeEventIsCalled - lastTimeEventWereCalled > minTimeBetweenEvents))
        {   
            //print(currentTimeEventIsCalled);
            lastTimeEventWereCalled = currentTimeEventIsCalled;

            if (idPerso == 0)
            {
                idPerso = 1;
                changerPersoCourant(hyene);
            }
            else if (idPerso == 1)
            {
                idPerso = 0;
                changerPersoCourant(player);
            }

            /*if ( persoCourant == player)
            {
                

            }
            //print(persoCourant == hyene);
            print(persoCourant == player);

            if (persoCourant == hyene)
            {
                changerPersoCourant(player);
            }*/
        }


    }

    /*Méthode qui suit le gameobject perso dans le jeu*/
    void centrerCameraSur(GameObject perso)
    {
        self.transform.position = Vector3.SmoothDamp(self.transform.position, perso.transform.position + posOffset, ref velocity, timeOffset);
        //print(perso.transform.position);
    }

    /*Méthode à appeler pour changer le personnage à focus*/
    void changerPersoCourant(GameObject persoSuivant)
    {
        persoCourant = persoSuivant;
    }

}
