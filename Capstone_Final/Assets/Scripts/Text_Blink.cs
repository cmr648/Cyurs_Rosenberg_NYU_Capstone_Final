using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Blink : MonoBehaviour
{
    public float Blink_Delay;

    Text This_Text;

    // Start is called before the first frame update
    void Start()
    {
        This_Text = GetComponent<Text>();

        StartCoroutine("Blink_Text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink_Text()
    {
        while (true)
        {
            This_Text.enabled = true;
            yield return new WaitForSeconds(Blink_Delay);
            This_Text.enabled = false;
            yield return new WaitForSeconds(Blink_Delay);
        }
    }
}
