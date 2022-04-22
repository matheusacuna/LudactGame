using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector3.up * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "col")
        {
            gameObject.SetActive(false);
        }
    }
}
