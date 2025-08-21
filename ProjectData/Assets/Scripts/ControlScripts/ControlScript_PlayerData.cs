using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript_PlayerData : MonoBehaviour
{
    public static List<int> playerfolder = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerfolder.Count);
    }
}
