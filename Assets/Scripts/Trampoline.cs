using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

    public bool state;
    ParticleSystem pe;

    void Start()
    {
        state = true;
        pe = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (state == true && pe.isPlaying == false)
        {
            pe.Play();
        }

        if (state == false && pe.isPlaying)
        {
            pe.Stop();
        }

    }
}
