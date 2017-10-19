using UnityEngine;
using System.Collections;

public class DartBoard : MonoBehaviour
{
    public string killerTag;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == killerTag)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
