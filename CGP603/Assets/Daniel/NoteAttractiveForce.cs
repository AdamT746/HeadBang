using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NoteAttractiveForce : MonoBehaviour
{
    public Vector3 _attractiveTarget;
    public float _attractionSpeed;
    // Start is called before the first frame update
    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        _attractiveTarget.y -= _attractionSpeed * Time.deltaTime;
        this.gameObject.GetComponent<VisualEffect>().SetVector3("Attractive Target", _attractiveTarget);
    }
}
