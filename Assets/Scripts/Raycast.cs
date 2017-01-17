using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    public float fireRate = .25f;
    public float remoteRange = 10f;
    public Transform remoteEnd;
    public int ammo = 2;

    Camera cam;
    WaitForSeconds shotDuration = new WaitForSeconds(.02f);
    LineRenderer laserLine;
    float nextFire; 

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
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + cam.transform.forward * remoteRange);
            }

        }
    }

    private IEnumerator shotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}
