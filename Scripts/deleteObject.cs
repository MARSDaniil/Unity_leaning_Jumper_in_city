using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float xCoordinatsToDelete = -14;
    private Vector3 coordinatsToDelete;
    void Start()
    {
       coordinatsToDelete = new Vector3(xCoordinatsToDelete, 0, 0);
}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < coordinatsToDelete.x)
        {
            Destroy(gameObject);
        }
    }
}
