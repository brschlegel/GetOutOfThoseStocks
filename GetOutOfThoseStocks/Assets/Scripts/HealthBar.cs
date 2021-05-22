using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScale(float current, float max)
    {
        float ratio = current/max;
        Vector3 scale = new Vector3(transform.localScale.x * ratio, transform.localScale.y, transform.localScale.z);
        transform.localScale =scale;
    }
}
