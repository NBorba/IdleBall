using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBounce : MonoBehaviour
{ 
    private GameTransactions gameTransactions = new GameTransactions();

    private const float MAX_SPEED = 5f;
    private const int CHANGE_DIRECTION_THRESHOLD = 2;
    private const string WALL_TAG = "Wall";

    private int changeDirectionCount = 0;

    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private GameObject floatingMoneyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        floatingMoneyPrefab = (GameObject)Resources.Load("FloatingMoneyText");
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void  OnCollisionEnter2D(Collision2D collision)
    { 
        switch (collision.gameObject.tag)
        {
            case Tags.WALL: 
                OnCollidedWithWall(collision);
                break; 
            default:
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
                break;
        }
    }

    private void OnCollidedWithWall(Collision2D collision) 
    {
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        var angle = Vector3.Angle(lastVelocity.normalized, direction);
        if (angle == 180 || (angle > 80 && angle < 110) || hasReachedChangeDirectionThreshold()) {
            direction = Random.insideUnitCircle.normalized;
        }

        rb.velocity = direction * MAX_SPEED;

        if (hasReachedChangeDirectionThreshold()) {
            resetChangeDirectionCount();
        } else {
            incrementChangeDirectionCount();
        }

        var bounceData = gameTransactions.OnBallBounced();
        ShowFloatingMoneyText(transform.position, bounceData);
    }

    private bool hasReachedChangeDirectionThreshold() 
    {
        return changeDirectionCount == CHANGE_DIRECTION_THRESHOLD;
    }

    private void resetChangeDirectionCount() 
    {
        changeDirectionCount = 0;
    }

    private void incrementChangeDirectionCount() {
        changeDirectionCount += 1;
    }

    private void ShowFloatingMoneyText(Vector3 position, GameTransactions.BounceData bounceData) {
        var floatingMoneyGameObject = Instantiate(floatingMoneyPrefab, position, Quaternion.identity);
        var floatingMoneyText = floatingMoneyGameObject.GetComponentInChildren<TextMeshPro>();

        if (bounceData.IsCritical) {
            floatingMoneyText.color = new Color32(227, 172, 9, 255);
            floatingMoneyText.fontSize += 1;
        }
        floatingMoneyText.text = "+$" + bounceData.Reward;
        
        StartCoroutine(IntroFade(floatingMoneyGameObject, floatingMoneyText));
    }

    private IEnumerator IntroFade(GameObject gameObject, TextMeshPro textToUse) {
        //yield return FadeInText(2f, textToUse);
        yield return new WaitForSeconds(.5f);
        yield return FadeOutText(2f, textToUse);
        Destroy(gameObject);
    }

    private IEnumerator FadeInText(float timeSpeed, TextMeshPro text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }

    private IEnumerator FadeOutText(float timeSpeed, TextMeshPro text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
}
