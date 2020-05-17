using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAquisistionScript : MonoBehaviour
{
    private GameObject currentTarget = null;
    private TargetScript myTargetScript;
    private TargetScript othersTargetScript;
    private TargetScript.Team myTeam;
    TargetScript.Team otherTeam;
    private void Start()
    {
        myTargetScript = gameObject.GetComponent<TargetScript>();
        myTeam = myTargetScript.getTeam();
    }

    private void Update()
    {
        if (!currentTarget.activeSelf)
        {
            print("unlocking");
            currentTarget = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        AquireTarget(other);
    }
    
    //Stops Targeting when player leaves tower range
    private void OnTriggerExit(Collider other)
    {
        UnaquireTarget(other);
    }

    //checks if the object leaving the range is the current target
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
        if (other.gameObject.layer == 9)
        {
            othersTargetScript = other.GetComponent<TargetScript>();
            otherTeam = other.GetComponent<TargetScript>().getTeam();

            if (currentTarget == null) //targets first person to enter
            {
                if (myTeam != otherTeam) //if they are on the opposite team
                {
                    currentTarget = other.gameObject;
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
    }
    public GameObject getCurrentTarget() { return currentTarget; }

/*    public TargetScript.Team getOtherTeam()
    {
        if(myTeam == TargetScript.Team.Red)
        {
            return TargetScript.Team.Blue;
        }
        return TargetScript.Team.Red;
    }*/
}
