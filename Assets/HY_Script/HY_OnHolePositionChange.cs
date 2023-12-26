using UnityEngine;

public class HY_OnHolePositionChange : MonoBehaviour
{
    [SerializeField]
    PolygonCollider2D hole2dCollider;
    [SerializeField]
    PolygonCollider2D ground2dCollider;
    [SerializeField]
    MeshCollider generateLinkCollider;
    [SerializeField]
    float initialScale = 0.5f;
    Mesh generateMesh;
    Vector2[] pointPos;
    private void FixedUpdate()
    {
        if(transform.hasChanged==true)
        {
            transform.hasChanged = false;
            hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2dCollider.transform.localScale = transform.localScale*initialScale;
            MakeHole2D();
            Make3dMeshCollider();
        }
    }
    void MakeHole2D()
    {
        pointPos = hole2dCollider.GetPath(0);
        for(int i = 0; i < pointPos.Length;i++)
        {
            pointPos[i] = hole2dCollider.transform.TransformPoint(pointPos[i]);
        }
        ground2dCollider.pathCount = 2;
        ground2dCollider.SetPath(1, pointPos);
    }
    void Make3dMeshCollider()
    {
        if(generateMesh!=null)
        {
            Destroy(generateMesh);
        }
        generateMesh = ground2dCollider.CreateMesh(true,true);
        generateLinkCollider.sharedMesh = generateMesh;
    }
}
