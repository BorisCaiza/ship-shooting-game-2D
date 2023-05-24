using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameController.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            
        {
            var targetPosition = target.position;
            Vector3 diff = targetPosition - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z -90);
        }
        
    }
}
