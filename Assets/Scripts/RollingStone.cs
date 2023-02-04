using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour {
    [SerializeField] SpriteRenderer rendrr;
    [SerializeField] float distance;
    [SerializeField] float speed;
    float distanceTravel = 0;
    float movement = 0;
    Vector3 currPos;

    bool isColliding;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (distanceTravel < distance) {
            movement = speed * Time.deltaTime;
            currPos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(currPos.x += movement, currPos.y, currPos.z);
            distanceTravel += Mathf.Abs(movement);
        } else {
            speed *= -1;
            distanceTravel = 0;
            rendrr.flipX = !rendrr.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D _collision) {
        Debug.Log("yo");
        if (_collision.collider.TryGetComponent(out IDamageable isDamageable)) {
            isDamageable.TakeDamage(1);
        }
    }
}
