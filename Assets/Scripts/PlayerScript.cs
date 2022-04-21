using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 moveVector;

    float hAxis;
    float vAxis;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVector = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVector * PlayerManager.Instance.speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        rigidbody.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("END"))
        {
            Debug.Log("Stage1 Clear!");
        }
    }
}
