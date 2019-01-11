using UnityEngine;
using UnityEngine.Serialization;

public class CompleteCameraController : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 _offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        _offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset y value.
        transform.position = player.transform.position + new Vector3(0, _offset.y, 0);
        
        //Set rotation of camera to car rotation, only y
        Quaternion rotation = player.transform.rotation;
        //Set x to 0
        rotation[0] = 0;
        //Set y to 0
        rotation[2] = 0;
        transform.rotation = rotation;
        
        //Transform camera to to be behind car by offset x
        transform.position += transform.forward * -1 * _offset.x;
    }
}