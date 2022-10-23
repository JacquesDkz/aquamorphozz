using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoissonMovement : MonoBehaviour
{
    public float speed;

    private bool b = false;

    private Animator animator;

    private bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if(Input.GetKey(KeyCode.UpArrow) && !b)
            {
                b = true;
                StartCoroutine(haut());
                animator.SetBool("Haut", true);
                Debug.Log("Haut");
            }
            if(Input.GetKey(KeyCode.RightArrow) && !b)
            {
                b = true;
                StartCoroutine(droite());
                animator.SetBool("Droite", true);
                Debug.Log("Droite");
            }
            if(Input.GetKey(KeyCode.LeftArrow) && !b)
            {
                b = true;
                StartCoroutine(gauche());
                animator.SetBool("Gauche", true);
                Debug.Log("Gauche");
            }
            if(Input.GetKey(KeyCode.DownArrow) && !b)
            {
                b = true;
                StartCoroutine(bas());
                animator.SetBool("Bas", true);
                Debug.Log("Bas");
            }
        }
    }

    IEnumerator haut()
    {
        while(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,speed * Time.deltaTime,0);
            yield return null;
        }
        b = false;
        animator.SetBool("Haut", false);
    }

    IEnumerator droite()
    {
        while(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
            yield return null;
        }
        b = false;
        animator.SetBool("Droite", false);
    }

    IEnumerator gauche()
    {
        while(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
            yield return null;
        }
        b = false;
        animator.SetBool("Gauche", false);
    }

    IEnumerator bas()
    {
        while(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
            yield return null;
        }
        b = false;
        animator.SetBool("Bas", false);
    }

    public void changeActive()
    {
        active = !active;
    }
}
