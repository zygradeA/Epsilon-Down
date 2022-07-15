using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    //private Transform size;
    private GameObject sphere;
    private Vector3 scaleChange;
    public Transform sphereTransform;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //sphere.transform.localScale += scaleChange;
        sphereTransform.localScale += scaleChange;
    }
}
