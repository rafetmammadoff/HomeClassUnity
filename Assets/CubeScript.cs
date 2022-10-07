using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Fire");
        StartCoroutine("Print", "Salam");
    }

    public IEnumerator Print(string a)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(a);

    }
}
