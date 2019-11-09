using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Author : Shohanur Rahaman 
/// </summary>
[CreateAssetMenu(fileName = "wave info", menuName = "Zombie/Wave", order = 1)]
public class WaveInfo_SO : ScriptableObject {
    
    [TextArea]
    public string name;
    public string saveKey;
   
    [Header("Zombie Properties")]
    public int totalWave = 1;
    public int zombiePerWave = 1;
    public int waveInterval = 2;
    public GameObject[] zombiePrefab;
    
    private void OnValidate(){
        if (saveKey.Equals("")) {
            saveKey = name;
        }
    }

    public GameObject GetZombie(){
        GameObject z = zombiePrefab[Random.Range(0, zombiePrefab.Length)];
        return z;
    }

    public void UpdateWaves(){
        totalWave -= 1;
    }

    public int GetWaveCount(){
        return totalWave;
    }

    private void OnEnable(){

            // get data 
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
            EditorJsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(saveKey), this);
            Debug.Log("overwrite data");
        
    }

    private void OnDisable(){
        // save data 
            if (saveKey.Equals("")) 
                saveKey = this.name;
            
            string jsonData = JsonUtility.ToJson(this, true);
            //Debug.Log(jsonData);
            PlayerPrefs.SetString(saveKey, jsonData);
            PlayerPrefs.Save();
        
    }
} 
