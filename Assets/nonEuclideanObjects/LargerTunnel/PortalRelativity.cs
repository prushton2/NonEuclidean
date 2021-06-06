using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRelativity : MonoBehaviour
{

    //allows an object to stay relative to another object with a set distance

    // center of the portal that will display what the attached camera is watching
    public GameObject inputPortal;
    // center of the the other portal
    public GameObject outputPortal;
    // the object defining the an, the player's camera in most cases
    public GameObject relativeObject;

    //holds the distance between the relativeObject and the inputPortal
    private Vector3 deltaPos;
    public Vector3 deltaAngle;

    void Start()
    {
        
    }


    void Update()
    {
        deltaPos = inputPortal.transform.position - relativeObject.transform.position;
        this.transform.position = outputPortal.transform.position - deltaPos;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(inputPortal.transform.rotation, outputPortal.transform.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * relativeObject.transform.forward;
        this.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}
