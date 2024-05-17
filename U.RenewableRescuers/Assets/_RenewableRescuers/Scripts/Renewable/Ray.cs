using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Ray : MonoBehaviour
{
    [SerializeField] private Transform spriteTransform;
    public LayerMask layerToCollide;

    private void Start()
    {
        Physics2D.queriesHitTriggers = false;
        if (spriteTransform == null)
            throw new NullReferenceException();
    }

    private void Update()
    {
        // shoot out a ray down the x-axis
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, float.MaxValue, layerToCollide);
        if (hit)
        {
            // end level if ray meets renewable target
            if (hit.transform.tag == Utils.TAG_RENEWABLE_TARGET)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

            // update ray render
            float dist = Mathf.Abs(transform.position.x - hit.point.x);
            float half_way = transform.position.x + dist / 2 ;
            spriteTransform.position = new Vector3(half_way, spriteTransform.position.y, 0f);
            spriteTransform.localScale = new Vector3(dist, 1f, 1f);
        }
    }
}
