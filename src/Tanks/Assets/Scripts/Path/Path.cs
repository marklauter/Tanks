using System;
using System.Collections.Generic;
using System.Linq;

public static class Path
{
    public static List<Point> Find(Grid grid, Point origin, Point destination)
    {
        var open = new HashSet<Node>();
        var closed = new HashSet<Point>();

        var currentNode = new Node(origin, destination, null, origin);
        _ = open.Add(currentNode);

        while (currentNode.Target != destination)
        {
            var minFCost = open.Any() 
                ? open.Min((n) => n.FCost)
                : -1;
            currentNode = open.FirstOrDefault(n => n.FCost == minFCost);
            if (currentNode == null)
            {
                return new List<Point>();
            }

            _ = open.Remove(currentNode);
            _ = closed.Add(currentNode.Target);

            for (var j = 0; j < 8; ++j)
            {
                var neighbor = currentNode.Target
                    .GetNeighbor((Neighbor)j);

                if (!closed.Contains(neighbor) && grid.IsTraversable(neighbor))
                {
                    var neighborNode = new Node(origin, destination, currentNode, neighbor);
                    if (open.Contains(neighborNode))
                    {
                        var previousCost = open.First(c => c.Target == neighbor);
                        if (neighborNode.FCost < previousCost.FCost)
                        {
                            _ = open.Remove(previousCost);
                        }
                    }

                    _ = open.Add(neighborNode);
                }
            }
        }

        return ResolvePath(currentNode);
    }

    private static List<Point> ResolvePath(Node node)
    {
        var path = new List<Point>();
        while (node.Parent != null)
        {
            path.Add(node.Target);
            node = node.Parent;
        }

        path.Add(node.Target);

        path.Reverse();

        return path;
    }
}
