using UnityEngine;

public class ClickController : MonoBehaviour
{
    private ConstructionArea lastTileHit = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    if (hit.collider.gameObject.GetComponent<ConstructionArea>() == lastTileHit)
                    {
                        lastTileHit.DeactiveUI();
                        lastTileHit = null;
                    }
                    else
                    {
                        if (lastTileHit != null)
                        {
                            lastTileHit.DeactiveUI();
                        }
                        lastTileHit = hit.collider.gameObject.GetComponent<ConstructionArea>();
                        lastTileHit.ActiveUI();
                    }
                }
                else if (hit.collider.CompareTag("TileButton"))
                {
                    lastTileHit.DeactiveUI();
                    hit.collider.gameObject.GetComponent<TileButton>().Action();
                    lastTileHit = null;
                }
            }
            else
            {
                if (lastTileHit != null)
                {
                    lastTileHit.DeactiveUI();
                    lastTileHit = null;
                }

            }
        }
    }
}
