using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

    private static PoolManager _instace;

    // property
    public static PoolManager Instance{
        get{
            
            if(_instace == null){
                GameObject go = new GameObject("Pool_Manager");
                go.AddComponent<PoolManager>();
            }
            //if it is not null
            return _instace;
        }
    } // end property

    public GameObject bulletPreFabs;
    public GameObject objectHolder;
    public int numberOfSpwan = 20;
    // create a list
    public List<GameObject> BulletList = new List<GameObject>();

    void Awake(){
        _instace = this;
        //print("this "+this.name);
        //print("_instance : "+_instace.name);
    }

    void Start(){
        
        for(int i=0;i<numberOfSpwan;i++){
            GameObject bullet = Instantiate(bulletPreFabs, Vector3.zero, Quaternion.identity) as GameObject; 
            bullet.transform.parent = objectHolder.transform;
            bullet.SetActive(false);

            // add them into the List
            BulletList.Add(bullet);
        }
    }

}







