using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour
{

    public Transform target; //what camera is following
    public float smoothing; //how quickly follows , how quickly the camera it eases out its following (dampening effect)

    Vector3 offset;

    float lowY; //lowest point the camera can go


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = target.position;
        offset = transform.position - target.position;

        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null) { // this IF STATEMENT was NOT mentioned in the video, but the content inside it was, I added the if null filter and placed the 2 lines in because unity gave an error when the character died
                              //saying the 29th line kept requesting target position when he was dead

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z); // if transp.y goes below the low value we want it to pop back up
    }
}
