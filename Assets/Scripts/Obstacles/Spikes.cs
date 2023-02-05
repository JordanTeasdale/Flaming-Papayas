using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D _collision) {
        Debug.Log("yo");
        if (_collision.collider.TryGetComponent(out IDamageable isDamageable)) {
            isDamageable.TakeDamage(1);
        }
    }
}
