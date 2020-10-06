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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Yeet'h");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage();
            Debug.Log("Hit'h");
        }
    }
    IEnumerator DestroyOilcanRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
