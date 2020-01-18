﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] float range = 100f;
    [SerializeField] float gunDamage = 10f;

    TargetScript myTargetScript;
    TargetScript.team myTeam;

    private void Start()
    {
        myTargetScript = GetComponent<TargetScript>();
        myTeam = myTargetScript.getTeam();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            //TODO make this a list that hits objects that are not triggers
            if(hit.collider.isTrigger == false)
            {
                if (hit.transform.gameObject.GetComponent<TargetScript>())
                {
                    TargetScript hitTargetScript = hit.transform.gameObject.GetComponent<TargetScript>();

                    if (hitTargetScript.getTeam() != myTeam)
                    {
                        hitTargetScript.TakeDamage(gunDamage);
                        print(hit.transform.gameObject.name + " was hit");
                    }
                }
            }
        }
    }


}
