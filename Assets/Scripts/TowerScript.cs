using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] float towerDamage = 5;

    GameObject currentTarget;
    Transform[] transforms;
    Transform turrent;
    TargetScript myTargetScript;
    TargetScript.team myTeam;
    // Start is called before the first frame update
    void Start()
    {
        myTargetScript = this.GetComponent<TargetScript>();
        myTeam = myTargetScript.getTeam();
        transforms = this.GetComponentsInChildren<Transform>();
        turrent = transforms[1];
    }


    // Update is called once per frame
    void Update()
    {
        if(currentTarget)
        {
            currentTarget.GetComponent<TargetScript>().TakeDamage(towerDamage);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        AquireTarget(other);
    }

    private void OnTriggerExit(Collider other)
    {
        UnaquireTarget(other);
    }

    //Stops Targeting when player leaves tower range
    private void UnaquireTarget(Collider other)
    {
        if (other.gameObject == currentTarget)
        {
            currentTarget = null;
        }
    }

    //targets the closet player to the tower center
    private void AquireTarget(Collider other)
    {
        TargetScript.team otherTeam = other.GetComponent<TargetScript>().getTeam();
        if (currentTarget == null) //targets first person to enter
        {
            if(myTeam != otherTeam) //if they are on the opposite team
            {
                currentTarget = other.gameObject;
            }
            
        }
        else if ((Vector3.Distance(transform.position, other.gameObject.transform.position) < Vector3.Distance(transform.position, currentTarget.transform.position))) //targets whoever is closest to the middle of the tower
        {
            if(myTeam != otherTeam)
            {
                currentTarget = other.gameObject;
            }
        }
    }
}
