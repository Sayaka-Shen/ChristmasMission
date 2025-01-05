using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundLoop : MonoBehaviour
{
    [Header("Loop Settings")]
    [SerializeField] private GameObject[] backgroundElements;
    [SerializeField] private float backgroundChoke;
    [SerializeField] private float tileMapChoke;
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    private float _objectWidth = 0f;
    private float _halfObjectWidth = 0f;

    private void Start()
    {
        // Camera Parameter
        _mainCamera = gameObject.GetComponent<Camera>();
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));

        foreach (GameObject obj in backgroundElements)
        {
            LoadChildObjects(obj);
        }
    }

    private void LateUpdate()
    {
        foreach (GameObject obj in backgroundElements)
        {
            RepositionChildObjects(obj);
        }
    }

    private void LoadChildObjects(GameObject obj)
    {
        if (obj.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            _objectWidth = spriteRenderer.bounds.size.x - backgroundChoke;
        }
        else if (obj.TryGetComponent<TilemapRenderer>(out TilemapRenderer tilemapRenderer))
        {
            _objectWidth = tilemapRenderer.bounds.size.x - tileMapChoke;
        }
        
        int childNecessary = (int)Mathf.Ceil(_screenBounds.x * 2 / _objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;

        for (int i = 0; i <= childNecessary; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(_objectWidth * i, obj.transform.position.y, obj.transform.position.z);
        }
        
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
        Destroy(obj.GetComponent<TilemapRenderer>());
    }

    private void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            
            if (lastChild.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            {
                _halfObjectWidth = spriteRenderer.bounds.extents.x - backgroundChoke;
            }
            else if (lastChild.TryGetComponent<TilemapRenderer>(out TilemapRenderer tilemapRenderer))
            {
                _halfObjectWidth = tilemapRenderer.bounds.extents.x - tileMapChoke;
            }

            if (transform.position.x + _screenBounds.x > lastChild.transform.position.x + _halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + _halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
            else if (transform.position.x - _screenBounds.x < firstChild.transform.position.x - _halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - _halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
        }
    }
}
