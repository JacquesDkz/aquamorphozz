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

    private int anim = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform.Rotate(0, 180, 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.GetBool("Combat"))
        {
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
            anim++;
            animator.SetBool("Combat", true);
            if(other.gameObject.transform.position.x < transform.position.x)
            {
                transform.rotation = new Quaternion(0,0,0,0);
            }
            else{
                transform.rotation = new Quaternion(0,180,0,0);
            }
            StartCoroutine(wait(anim));
        }
    }

    IEnumerator wait(int i)
    {
        yield return new WaitForSeconds((float)1);
        if(anim == i)
        {
            animator.SetBool("Combat", false);
            if(walkSpeed < 0)
            {
                transform.rotation = new Quaternion(0,0,0,0);
            }
            else{
                transform.rotation = new Quaternion(0,180,0,0);
            }
        }
    }
}
