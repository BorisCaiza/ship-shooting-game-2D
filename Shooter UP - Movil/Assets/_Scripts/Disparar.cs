using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    
    public float speed;

    public Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desplazamiento = new Vector3(transform.position.x , speed*Time.deltaTime,transform.position.z);
        //mover.DoMove(desplazamiento);
    }
}
