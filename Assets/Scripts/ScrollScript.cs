using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    [SerializeField] private RawImage raw;
    [SerializeField] private float speedX, speedY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raw.uvRect = new Rect(raw.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, raw.uvRect.size);
    }
}
