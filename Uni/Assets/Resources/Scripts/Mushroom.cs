using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private bool stepped = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
