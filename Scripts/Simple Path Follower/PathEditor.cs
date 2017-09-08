using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour {

	public Color lineColor = Color.white;
	public List<Transform> nodes = new List<Transform>();
	private int segmentCount = 10;
	
	
	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.color = lineColor;

		Transform[] pathsTransform = GetComponentsInChildren<Transform>();
		nodes = new List<Transform>();

		foreach(Transform item in pathsTransform){
			if(item!=transform){
				nodes.Add(item);
			}
		}
/*
		Vector3 p0 = nodes[0].position;

		for(int i=1; i<nodes.Count; i +=2){
			
			Vector3 p1 = nodes[i].position;
			Vector3 p2 = nodes[i+1].position;

//		print(i);

				for(int j=1; j<=segmentCount; j++){
					float t = j/(float) segmentCount;
		
					Vector3 newPos = GetPoint(p0, p1, p2, t);
					//print(endPos);
				//	Gizmos.DrawWireSphere(newPos, 0.5f);
					//Gizmos.DrawLine(p0, newPos);
					p0 = newPos;
				}

				
		} // loop end 
*/
		drawAllNodes();

	} // end 

	void drawAllNodes()
	{
			for(int i=0; i<nodes.Count; i++){

			Vector3 currentNode = nodes[i].position;
			Vector3 previousNode = Vector3.zero;

				if(i>0){  // previous node 
					previousNode = nodes[i-1].position;
				}
				else if(i==0 && nodes.Count>1){ // last node 
					previousNode = nodes[nodes.Count - 1].position;
				}

				Gizmos.DrawLine(previousNode, currentNode);
				Gizmos.DrawWireSphere(currentNode, 0.5f);
			}
	}


	 Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
		 // B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			oneMinusT * oneMinusT * p0 +
			2f * oneMinusT * t * p1 +
			t * t * p2;
	}

}
