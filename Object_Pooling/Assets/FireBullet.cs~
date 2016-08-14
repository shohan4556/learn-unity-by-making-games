using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space)){
            // check the poolist if any gameObject is inactive
            for(int i=0;i<PoolManager.Instance.BulletList.Count;i++){
                
                if(PoolManager.Instance.BulletList[i].activeInHierarchy == false){
                    PoolManager.Instance.BulletList[i].SetActive(true);
                    PoolManager.Instance.BulletList[i].transform.position = Vector3.zero;
                    break;
                }
            }
        }

	}
}
