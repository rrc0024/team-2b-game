using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateTowards(obj.transform.position);
    }

    protected void rotateTowards(Vector3 to) {

	Quaternion _lookRotation = 
		Quaternion.LookRotation((to - transform.position).normalized);
	
	//over time
	transform.rotation = 
		Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime);
	
	//instant
	transform.rotation = _lookRotation;
}
}
