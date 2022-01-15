using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Small,
    Big
}

public enum BlockColor
{
    Blue,
    Brown,
    Cyan,
    DarkGreen,
    Green, 
    Grey,
    Orange,
    Purple,
    Red,
    Yellow
}

public class BlockTile : MonoBehaviour
{

    private int _id;

    private const string BLOCK_BIG_PATH = "Sprites/BlockTiles/Big/Big_{0}_{1}";

    [SerializeField]
    private BlockColor _color = BlockColor.Blue;

    [SerializeField]
    private BlockType _type = BlockType.Big;

    private SpriteRenderer _renderer;
    private Collider2D _collider2D;

    private int _totalHits = 1;
    private int _currentHits = 0;

    [SerializeField]
    private int _score = 10;

    public int Score => _score;

    // Start is called before the first frame update

    public void Init()
    {
        _currentHits = 0;
        _totalHits = _type == BlockType.Big ? 2 : 1;

        _collider2D = GetComponent<Collider2D>();
        _collider2D.enabled = true;

        _renderer = GetComponentInChildren<SpriteRenderer>();

        _renderer.sprite = GetBlockSprite(_type, _color, 0);
    }

    public void OnHitCollision(ContactPoint2D contactPoint)
    {
        _currentHits++;
        if(_currentHits >= _totalHits)
        {
            _collider2D.enabled = false;
            gameObject.SetActive(false);

            ArkanoidEvent.OnBlockDestroyedEvent?.Invoke(_id);
        }
        else
        {
            _renderer.sprite = GetBlockSprite(_type, _color, _currentHits);
        }
    }

    public void SetData(int id, BlockColor color)
    {
        _id = id;
        _color = color;
    }

    static Sprite GetBlockSprite(BlockType type, BlockColor color, int state)
    {
        string path = string.Empty;
        if (type == BlockType.Big)
        {
            path = string.Format(BLOCK_BIG_PATH, color, state);
        }

        if (string.IsNullOrEmpty(path))
        {
            return null;
        }

        return Resources.Load<Sprite>(path);
    }

    

}
