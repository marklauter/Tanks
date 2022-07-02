using UnityEngine;

public class Board : MonoBehaviour
{
    public int height;
    public int width;
    public int tileSize;
    public GameObject tile;
    public GameObject piece;

    private Grid grid;
    private GameObject[] tiles;

    private void Awake()
    {
        grid = new Grid(this.width, this.height);
        tiles = new GameObject[grid.Span];

        for (var x = 0; x < this.width; x++)
        {
            for (var y = 0; y < this.height; y++)
            {
                var t = Instantiate(this.tile, new Vector3Int(x, 0, y), Quaternion.identity);
                //var tileBehavior = t.GetComponent<TileBehavior>();
                //tileBehavior.X = x;
                //tileBehavior.Y = y;
                tiles[y * this.width + x] = t;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //var mb = Input.GetMouseButton(0);
        //if (mb)
        //{
        //    Debug.Log($"mb: {mb}");

        //    var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Debug.Log($"wp: {worldPosition.x}, {worldPosition.y}, {worldPosition.z}");
        //    Debug.Log($"mp: {Input.mousePosition.x}, {Input.mousePosition.y}, {Input.mousePosition.z}");

        //    var mouseX = Mathf.RoundToInt(worldPosition.x);
        //    var mouseY = Mathf.RoundToInt(worldPosition.y);
        //    Debug.Log($"pos: x: {mouseX}, y: {mouseY}, z: {worldPosition.z}");

        //    var pieceX = Mathf.RoundToInt(this.piece.gameObject.transform.position.x);
        //    var pieceY = Mathf.RoundToInt(this.piece.gameObject.transform.position.y);

        //    var origin = new Point(pieceX, pieceY);
        //    var destination = new Point(mouseX, mouseY);

        //    Debug.DrawLine(origin.ToVector3(), destination.ToVector3(), Color.blue);
        //}

        //if (origin != destination)
        //{
        //    var path = Path.Find(this.grid, origin, destination);

        //    for (var i = 1; i < path.Count; ++i)
        //    {
        //        var point1 = path[i - 1];
        //        var point2 = path[i];
        //        Debug.DrawLine(point1.ToVector2(), point2.ToVector2(), Color.green);
        //    }
        //}
    }
}
