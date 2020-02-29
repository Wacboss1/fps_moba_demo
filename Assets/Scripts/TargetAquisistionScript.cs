using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAquisistionScript : MonoBehaviour
{
    GameObject currentTarget = null;
    TargetScript myTargetScript;
    TargetScript.Team myTeam;
    TargetScript.Team otherTeam;
    private void Start()
    {
        myTargetScript = gameObject.GetComponent<TargetScript>();
        myTeam = myTargetScript.getTeam();
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
        //TODO find a good way of checking that things are not null
        if (other.gameObject.GetComponent<TargetScript>() != null)
        {
            otherTeam = other.GetComponent<TargetScript>().getTeam();
        }
        if (currentTarget == null) //targets first person to enter
        {
            if (myTeam != otherTeam) //if they are on the opposite team
            {
                currentTarget = other.gameObject;
                print("target is : " + other.gameObject.name);
            }
        }
        else if (other.gameObject && currentTarget)
        {
            if (Vector3.Distance(this.transform.position, other.gameObject.transform.position) < Vector3.Distance(this.transform.position, currentTarget.transform.position))
            {
                //targets whoever is closest to the middle gameObject
                if (myTeam != otherTeam)
                {
                    currentTarget = other.gameObject;
                }
            }
        }
    }
    public GameObject getCurrentTarget() { return currentTarget; }
}
