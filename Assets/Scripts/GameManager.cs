using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject AudioObject;

    void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);
        // AudioObject = GameObject.Find("GameManager");
        // if(AudioObject)
        // {
        //     Destroy(AudioObject);
        // }
        // else
        // {
        //     DontDestroyOnLoad(this.gameObject);
        // }
//       Debug.Log ("Exists");
// }
//         if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
//         {
//             DontDestroyOnLoad(this.gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
