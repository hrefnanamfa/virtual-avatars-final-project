using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMirror : MonoBehaviour
{
    public Transform objectToFollow;
    public Transform mirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 objectToFollowLocal = mirror.InverseTransformPoint(objectToFollow.position);
        Camera cameraComponent = GetComponent<Camera>();
        float distanceOnZ = Mathf.Abs(mirror.position.z - objectToFollow.position.z);
        cameraComponent.fieldOfView = distanceOnZ;


        // Project the objectToFollow position onto the XY plane (ignoring the y-component)
        Vector3 projectedPosition = Vector3.ProjectOnPlane(objectToFollow.position - mirror.position, Vector3.up);

        // Calculate the new position based on the projected position and distance
        Vector3 newPosition = mirror.position + projectedPosition.normalized * distanceOnZ;

        // Set the new position for the current transform
        transform.position = newPosition;


        //transform.position = mirror.TransformPoint(new Vector3(mirror.position.x, mirror.position.y, -objectToFollowLocal.z));




        //transform.position = mirror.TransformPoint(new Vector3(objectToFollowLocal.x, objectToFollowLocal.y, -objectToFollowLocal.z ));

        //transform.localRotation = objectToFollow.localRotation;
    }
}
