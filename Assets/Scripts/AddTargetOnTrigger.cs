using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTargetOnTrigger : MonoBehaviour {

    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    void Awake()
    {
        //Move and reduce size of cube
        transform.position = new Vector3(0, 0.25f, 0.75f);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;

        moveSpeed = 1.0f;

        //Creates sphere for cube to interact with
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.gameObject.transform.position = new Vector3(0, 0, 0);
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        sphere.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }


	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("Entered");
        }
    }
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
                Debug.Log("staying");
                stayCount = stayCount - 0.25f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("Exit");
        }
    }

}
