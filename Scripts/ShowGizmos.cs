using System.Collections;
using UnityEngine;


// there are objects to pool
[System.Serializable]
public class GizmosColor{
	public Color color;
}


public class ShowGizmos : MonoBehaviour {

	private bool showGizmos = true;
	// Icon to draw Gizmos
	public string gizmoIcon = string.Empty;

	[Range(1,100)]
	public float Range = 5f;


	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		if(!showGizmos){ return;}

		// draw icon 
		Gizmos.DrawIcon(transform.position,gizmoIcon,true);

		// draw color sphere
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position,Vector3.one*Range);

		// draw forward direction 
		Gizmos.color = Color.black;
		
		if(Range!=1)
			Gizmos.DrawLine(transform.position, transform.position + transform.forward*Range);
		else
			Gizmos.DrawLine(transform.position, transform.position + transform.forward*Range*2f);	

	}
	
}
