using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] float range = 100f;
    [SerializeField] float gunDamage = 10f;

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
            Debug.DrawRay(transform.position, transform.forward, Color.red);;
            if(hit.transform.gameObject.GetComponent<TargetScript>())
            {
                hit.transform.gameObject.GetComponent<TargetScript>().TakeDamage(gunDamage);
                print(hit.transform.gameObject.name + " was hit");
            }
        }
    }


}
