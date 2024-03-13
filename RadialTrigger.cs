using System.Collections;
using System.Collections.Generic;

//need an ifdef to use unity editor if we are using handles
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.UI;



public class RadialTrigger : MonoBehaviour
{
    public Transform player;
	public Transform trigger;
	
	public float radius = 2;
	public Text triggeredText;
	
	public float dotValue;
	
	//using unity editor to pound define this out. 
	#if UNITY_EDITOR
    //will be called in the editor, do not need to press play
    //draws in the scene view
    void OnDrawGizmos()
    {
		
		
		Vector2 triggerPos = trigger.position;
		

		Vector2 playerPos = player.position;

        //Vector2 distanceVector = triggerPos - playerPos;
        double distance = Vector3.Distance(triggerPos, playerPos); //<--built in function, fewest lines of code. 
        
        //distanceVector.magnitude; //built in property but requires us to instantiate a distanceVector variable. 
        //Mathf.Sqrt(distanceVector.x * distanceVector.x + distanceVector.y * distanceVector.y); //most computationally efficient. 
		
		//Gizmos.color = Color.red;
		//Gizmos.DrawLine(aPos, b);
		
		//ADD ANOTHER TEXT FIELD TO DISPLAY DISTANCE
		//ADD A RADIUS VARIABLE
		//SET TRIGGERED TEXT TO INSIDE RADIUS OR OUTSIDE RADIUS
		//DEPENDING ON IF DISTANCE IS > or < RADIUS. 

		if (distance <= radius){
			triggeredText.text = "In Radius";
            Gizmos.color = Color.red;
		} else {
			triggeredText.text = "Outside Radius";
            Gizmos.color = Color.white;
		}

        Gizmos.DrawWireSphere(triggerPos, radius);

    }
	#endif




}
