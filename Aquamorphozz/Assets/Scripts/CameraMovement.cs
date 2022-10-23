using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public GameObject self; //On veut manipuler la caméra sans ambiguité

    //Variable qui contient le personnage sur lequel la caméra doit se centrer
    //Pour l'affectation dans Unity, on mettra le personnage dont on voudra qu'il soit suivi au début du jeu
    public GameObject perso;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        centrerCameraSurPerso();

    }


    /*Méthode qui suit le personnage courant dans le jeu*/
    void centrerCameraSurPerso()
    {
        self.transform.position = Vector3.SmoothDamp(self.transform.position, perso.transform.position + posOffset, ref velocity, timeOffset);
    }

    /*Méthode à appeler pour changer le personnage à focus*/
    void changerPersoCourant(GameObject nouveau_perso)
    {
        perso = nouveau_perso;
    }

    void OnKeyDown(KeyDownEvent ev)
    {
        print("KeyDown:" + ev.keyCode);
        print("KeyDown:" + ev.character);
        print("KeyDown:" + ev.modifiers);
    }
}
