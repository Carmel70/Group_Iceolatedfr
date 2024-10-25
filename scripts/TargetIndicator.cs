using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;
    public float HideDistance;
    public bool Value;
    public GameObject oldTarget;
    public GameObject newTarget;
    public GameObject oldArrow;
    public GameObject newArrow;
    public void Start()
    {
        Value = true;
    }
    
    void Update()
    {
        var dir = Target.position - transform.position;
        if (dir.magnitude < HideDistance)
        {
            Value = false;
            
            SetChildrenActive(false);
            
            
        }
        else
        {
            
            SetChildrenActive(true);
            
           
        }
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Value == false) 
        {
            oldTarget.SetActive(false);
            newTarget.SetActive(true);
            oldArrow.SetActive(false);
            newArrow.SetActive(true);
        }
       
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);

        }
    }
}
