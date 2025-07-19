using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Worlds
{
    public class LocationFactory : MonoBehaviour
    {
        private Boot _boot;
        private World _world;

        public void Init(Boot boot, World world) {
            _boot = boot;
            _world = world;
        }

        public List<Location> FindPath(Location start, Location target) {
            List<Location> path = new List<Location>();
            if (start == null || target == null) return path;
            if (TryDirectPath(start, target, path)) return path;
            FindPathBreadthFirstSearch(start, target, path);
            return path;
        }

        private bool TryDirectPath(Location start, Location target, List<Location> path) {
            if (start.connectedLocations.Contains(target)) {
                path.Add(target);
                return true;
            }
            return false;
        }

        private void FindPathBreadthFirstSearch(Location start, Location target, List<Location> path) {
            Queue<Location> queue = new Queue<Location>();
            Dictionary<Location, Location> prev = new Dictionary<Location, Location>();
            queue.Enqueue(start);
            prev[start] = null;
            bool found = false;
            while (queue.Count > 0 && !found) {
                Location current = queue.Dequeue();
                foreach (Location neighbor in current.connectedLocations) {
                    if (!prev.ContainsKey(neighbor)) {
                        prev[neighbor] = current;
                        queue.Enqueue(neighbor);
                        if (neighbor == target) {
                            found = true;
                            break;
                        }
                    }
                }
            }
            if (found) {
                RestorePathFromPredecessors(start, target, prev, path);
            }
        }

        private void RestorePathFromPredecessors(Location start, Location target, Dictionary<Location, Location> prev, List<Location> path) {
            List<Location> revPath = new List<Location>();
            Location step = target;
            while (step != null && step != start) {
                revPath.Add(step);
                step = prev[step];
            }
            revPath.Reverse();
            path.AddRange(revPath);
        }
    }
} 