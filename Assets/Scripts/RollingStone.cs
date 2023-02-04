using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour {
    [SerializeField] SpriteRenderer rendrr;
    [SerializeField] float distance;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] bool isResetting;
    float distanceTravel = 0;
    float xMovement = 0;
    float yMovement = 0;
    Vector3 startPos;
    Vector3 currPos;

    bool isColliding;

    // Start is called before the first frame update
    void Start() {
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update() {

        if (distanceTravel < distance) {
            xMovement = xSpeed * Time.deltaTime;
            yMovement = ySpeed * Time.deltaTime;
            currPos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(currPos.x += xMovement, currPos.y += yMovement, currPos.z);
            distanceTravel += Mathf.Sqrt(Mathf.Pow(xMovement, 2) + Mathf.Pow(yMovement, 2));
        } else if (isResetting) {
            distanceTravel = 0;
            gameObject.transform.position = startPos;
        } else {
            xSpeed *= -1;
            ySpeed *= -1;
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
