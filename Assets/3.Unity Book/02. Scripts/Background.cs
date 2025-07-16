using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial;
    public float scrollSpeed = 0.2f;
    private void Update()
    {
    Vector2 direction = Vector2.up;
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
