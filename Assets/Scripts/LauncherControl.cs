using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    //[SerializeField] private float screenWidthUnit = 16f;
    [SerializeField] private float screenMin = -6f;
    [SerializeField] private float screenMax = 6f;
   
    //we calculate screen min and max by substracting half of launcher's length(unitwise)
    //from half of horizontal game length( camera size )

    // Start is called before the first frame update
    void Start()
    {
    }
    

    // Update is called once per frame
    void Update()
    {
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseX = Mathf.Clamp(mouseX, screenMin, screenMax); //limits the variable
        Vector2 location = new Vector2(mouseX, transform.position.y);        
        transform.position = location;

        
        //Input.mousePosition.x / Screen.width * screenWidthUnit;
        //you can use the above code if u make camera x y = 8 6 

        //Debug.Log(mouseX + " " + Input.mousePosition.x / Screen.width * screenWidthUnit);
        //in above debug both statements are world space (ınput.mouseposition is screen space)
        //but second one is proportional to camera position
        
        //Debug.Log(transform.position.x + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition).x);  
        // world space is unit system in unity we're changing pixels to units in this game since camera
        // size(length) is 6 and our game is 4:3 width is 16 unit
    }

    public void setMinMax(float limit)
    {
        screenMax = limit;
        screenMin = -1*limit;
    }
}
