using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField, Range(3, 100)] private int levelLength = 50;
    [SerializeField, Range(1, 50)] private float xMultiplayer = 2;
    [SerializeField, Range(1, 50)] private float yMultiplayer = 2;
    [SerializeField, Range(0, 1)] private float curveSmoothness = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10;
    private Vector3 lastPos;

    private void OnValidate()
    {
        spriteShapeController.spline.Clear();

        for (int i = 0; i < levelLength; i++)
        {
            lastPos = transform.position + new Vector3(i * xMultiplayer, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplayer);
            spriteShapeController.spline.InsertPointAt(i, lastPos);

            if (i != 0 && i != levelLength - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, curveSmoothness * xMultiplayer * Vector3.left);
                spriteShapeController.spline.SetRightTangent(i, curveSmoothness * xMultiplayer * Vector3.right);

            }

        }

        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));

    }

}