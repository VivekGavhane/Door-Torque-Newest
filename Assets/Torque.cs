using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torque : MonoBehaviour
{

    [SerializeField] float force = 10f;
    Rigidbody rbd;
    public Text TorqueText;

    void Start()
    {
        rbd = this.GetComponent<Rigidbody>();
        //TorqueText = gameObject.AddComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Door")
                {
                    Debug.Log("This is a Door");
                    //Debug.Log(Input.mousePosition.x);
                    float xIs = Input.mousePosition.x;               // Need to convert to local input position of x
                    float LengthFromPivot = (xIs-198);              // Need to convert to local coordinate of door
                    float torque = force * LengthFromPivot;
                    Debug.Log(LengthFromPivot);
                    Debug.Log(torque);

                    rbd.AddForce(transform.forward * LengthFromPivot * force);
                    TorqueText.text = "Torque is" + " " + torque + " " + "N.m";
                    
                 }
            }
        }
    }
}
