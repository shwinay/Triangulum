using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    public float fireRate = .25f;
    public float remoteRange = 10f;
    public Transform remoteEnd;

    Camera cam;
    WaitForSeconds shotDuration = new WaitForSeconds(.02f);
    LineRenderer laserLine;
    float nextFire;
    public int ammo;
    
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ammo > 0)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(shotEffect());

            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            laserLine.SetPosition(0, remoteEnd.position);

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, remoteRange))
            {
                laserLine.SetPosition(1, hit.point);

                //Change state of trampoline and teleporter to on or off
                if (hit.transform.gameObject.tag == "Trampoline")
                {
                    hit.transform.GetComponent<Trampoline>().state = !hit.transform.GetComponent<Trampoline>().state;
                }

                if (hit.transform.gameObject.tag == "Teleporter")
                {
                    hit.transform.GetComponent<Teleporter>().state = !hit.transform.GetComponent<Teleporter>().state;
                }
                if (hit.transform.gameObject.tag == "Moving Platform")
                {
                    hit.transform.GetComponent<MovingPlatform>().state = !hit.transform.GetComponent<MovingPlatform>().state;
                }

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + cam.transform.forward * remoteRange);
            }

            ammo--;
        }
    }

    private IEnumerator shotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}
