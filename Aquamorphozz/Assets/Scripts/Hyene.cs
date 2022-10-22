using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hyene : MonoBehaviour
{
    public float tailleDeplacement;

    Animator animator;

    public float walkSpeed;

    private float x;

    private int i = 1000;

    private bool col = false;

    private bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform.Rotate(0, 180, 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if(!b && !col)
        {
            if(walkSpeed < 0)
            {
                transform.rotation = new Quaternion(0,0,0,0);
            }
            else{
                transform.rotation = new Quaternion(0,180,0,0);
            }
            if(i == 1000)
            {
                if(x + walkSpeed * Time.deltaTime < tailleDeplacement && x + walkSpeed * Time.deltaTime > -tailleDeplacement)
                {
                    animator.SetBool("walk", true);
                    x += walkSpeed * Time.deltaTime;
                    transform.Translate(-1*Math.Abs(walkSpeed) * Time.deltaTime, 0, 0);
                }
                else
                {
                    i = 0;
                }
            }
            else
            {
                animator.SetBool("walk", false);
                i++;
                if(i == 1000)
                {
                    walkSpeed = -walkSpeed;
                    transform.Rotate(0, 180, 0, Space.World);
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Perso"))
        {
            animator.SetBool("Combat", true);
            animator.SetBool("walk", false);
            if(other.gameObject.transform.position.x < transform.position.x)
            {
                transform.rotation = new Quaternion(0,0,0,0);
            }
            else{
                transform.rotation = new Quaternion(0,180,0,0);
            }
            if(!b)
                StartCoroutine(wait());
            col = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        col = false;
    }

    IEnumerator wait()
    {
        b = true;
        yield return new WaitForSeconds((float)1);
        animator.SetBool("Combat", false);
        if(col)
        {
            Debug.Log("Hit");
        }
        b = false;
    }
}
