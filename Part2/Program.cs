namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int[][] map = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                map[i] = lines[i].ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
            }

            Console.WriteLine(Dijkstra(map, new Coord(0, 0), new Coord(map.Length - 1, map[0].Length - 1)));
        }

        public static int Dijkstra(int[][] map, Coord start, Coord end)
        {
            var Q = new PriorityQueue<Node, int>();
            var visited = new HashSet<Node>();
            Node? finish = null;

            var initDirs = new Coord[]
            {
                new Coord(0, 1),
                new Coord(1, 0)
            };
            foreach (var dir in initDirs)
            {
                int dist = 0;
                for (int i = 1; i <= 10; i++)
                {
                    var loc = start + dir * i;
                    dist += map[loc.Y][loc.X];
                    if (i < 4)
                        continue;
                    var node = new Node()
                    {
                        Loc = loc,
                        LastDir = dir,
                        Dist = dist,
                    };
                    Q.Enqueue(node, node.Dist);
                }
            }

            while (Q.Count > 0)
            {
                var cur = Q.Dequeue();
                if (visited.Contains(cur))
                    continue;
                visited.Add(cur);

                if (cur.Loc == end)
                {
                    finish = cur;
                    break;
                }

                foreach (var neighbour in GetNeighbours(map, cur))
                {
                    if (visited.Contains(neighbour))
                        continue;

                    Q.Enqueue(neighbour, neighbour.Dist);
                }
            }

            if (finish == null)
                return -1;

            return finish.Dist;
        }

        private static List<Node> GetNeighbours(int[][] map, Node cur)
        {
            var ret = new List<Node>();
            var dirs = new Coord[]
            {
                cur.LastDir.TurnLeft(),
                cur.LastDir.TurnRight(),
            };
            foreach (var dir in dirs)
            {
                int dist = cur.Dist;
                for (int i = 1; i <= 10; i++)
                {
                    var loc = cur.Loc + (i * dir);
                    if (!loc.IsOnMap(map))
                        break;

                    dist += map[loc.Y][loc.X];

                    if (i < 4)
                        continue;

                    ret.Add(new Node()
                    {
                        Loc = loc,
                        LastDir = dir,
                        Dist = dist,
                    });
                }
            }

            return ret;
        }
    }
}
