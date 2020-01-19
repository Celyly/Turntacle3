using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Transform bar;
    public bool isReversed;
    public float valueBar;
    public float maxValue;
    public float minValue;

    // Start is called before the first frame update
    private void Start()
    {
    
        valueBar = maxValue;
       

        if(bar != null){
            bar.localScale = new Vector3(valueBar, 1f);
        }

    }

    public void setValue(float value, bool isReversed)
    {
        this.isReversed = isReversed;

       

        if (isReversed)
        {
            //valueBar = -value;
        }
        bar.localScale = new Vector3(value, 1f);

    }


    // Update is called once per frame
    private void Update()
    {
        // Update value
        


        // Set max and min
       

            if(valueBar < minValue){
                valueBar = minValue;
            }
            if(valueBar > maxValue){
                valueBar = maxValue;
            }
 
        


    }
}
