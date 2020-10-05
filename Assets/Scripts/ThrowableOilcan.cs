using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableOilcan : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyOilcanRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyOilcanRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
