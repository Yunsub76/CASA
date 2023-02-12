using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedStop : MonoBehaviour {

	void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ground")
        {
            if (this.transform.position.y <= 0)
            {
                Debug.Log("도착!!");
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.gameObject.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }
}
