using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private Animator LoadingAni;
    

    // Start is called before the first frame update
    void Start()
    {
        LoadingAni = GameObject.Find("LoadingAni").GetComponent<Animator>();

        switch (Random.Range(0, 2))
        {
            case 0:
                LoadingAni.SetBool("AniType", true);
                break;
            case 1:
                LoadingAni.SetBool("AniType", false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
