using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 moveVector;

    float hAxis;
    float vAxis;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVector = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVector * PlayerManager.Instance.speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        rigid.angularVelocity = Vector3.zero;
    }   
}
