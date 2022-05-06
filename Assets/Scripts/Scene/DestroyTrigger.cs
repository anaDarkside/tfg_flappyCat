using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Cat")
        {
            Collider2D collider = GetComponent<Collider2D>();
            Destroy(collider);
        }
    }
}
