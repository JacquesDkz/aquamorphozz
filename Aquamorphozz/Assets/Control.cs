using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject player;

    public GameObject poisson;

    public Transform camera;

    private int j = 1;

    public float x1;
    public float x2;

    public float cy1;
    public float cy2;

    public CameraFollow c;

    private bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMovement>().ChangeActive();
        c.transformG = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(j == 1)
        {
            if(Input.GetKey(KeyCode.Tab) && player.transform.position.x >= x1 && player.transform.position.x <= x2 && !b)
            {
                j = 2;
                player.GetComponent<PlayerMovement>().ChangeActive();
                b = true;
                StartCoroutine(lerp(cy2));
            }
        }

        if(j == 2)
        {
            if(Input.GetKey(KeyCode.Tab) && !b)
            {
                j = 1;
                poisson.GetComponent<PoissonMovement>().ChangeActive();
                b = true;
                StartCoroutine(lerp(cy1));
            }
        }

        if(!Input.GetKey(KeyCode.Tab))
        {
            b = false;
        }
    }

    IEnumerator lerp(float end)
    {
        var t = 0f;
        var start = camera.position;
        var target = new Vector3(camera.position.x, end, camera.position.z);

        while (t < 1)
        {
            t += Time.deltaTime / 3;

            if (t > 1) t = 1;

            camera.position = Vector3.Lerp(start, target, t);

            yield return null;
        }
        if(j == 1)
        {
            player.GetComponent<PlayerMovement>().ChangeActive();
            c.transformG = player.transform;
        }
        else
        {
            poisson.GetComponent<PoissonMovement>().ChangeActive();
            c.transformG = poisson.transform;
        }
    }
}
