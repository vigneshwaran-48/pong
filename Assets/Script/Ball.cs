using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null) {
            throw new MissingComponentException("Rigidbody2D is required for a Ball script");
        }
        float force = 300f;
        
        float directionX = Random.Range(0, 2) == 1 ? 1f : -1f;
        float directionY = Random.Range(0, 2) == 1 ? -0.5f : 0.5f;
        Vector2 direction = new(directionX, directionY);

        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void Update() {
        
    }
}
