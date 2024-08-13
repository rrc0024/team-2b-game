using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceFromObjective : MonoBehaviour
{
    private TMP_Text text;
    public GameObject objective;
    public GameObject player;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
       text = GetComponent<TMP_Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float a = Mathf.Abs(objective.transform.position.x - player.transform.position.x);
        float b = Mathf.Abs(objective.transform.position.y - player.transform.position.y);
        distance = Mathf.Round(Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2)));
        text.text = distance + "";
        Debug.Log(transform.position.x);
    }
}
