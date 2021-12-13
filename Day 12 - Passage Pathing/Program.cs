using System;
using System.Collections.Generic;
using System.Linq;

namespace Possible_Paths
{
    class Program
    {

        static void Main(string[] args)
        {
			string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Possible Paths\Paths.txt");
			Dictionary<string, List<string>> caveConnections = new Dictionary<string, List<string>>();
			List<List<string>> routes = new List<List<string>>();

			foreach (string path in rawData)
			{
				string[] data = path.Split('-');
				if (caveConnections.ContainsKey(data[0]) == false)
				{
					caveConnections[data[0]] = new List<string>();
				}
				if (caveConnections.ContainsKey(data[1]) == false)
				{
					caveConnections[data[1]] = new List<string>();
				}

				caveConnections[data[0]].Add(data[1]);
				caveConnections[data[1]].Add(data[0]);
			}
			
			List<string> startRoute = new List<String>() { "start" };

			Paths(startRoute, false);
			Console.WriteLine(routes.Count);

			void Paths(List<string> route, bool revisit)
			{
				if (route.Last() == "end")
				{
					routes.Add(route);
					return;
				}
				foreach (var direction in caveConnections[route.Last()])
				{
					if (!(route.Contains(direction) && direction == direction.ToLower()))
					{
						var newRoute = new List<string>(route) { direction };
						Paths(newRoute, revisit);
					}
					else if (route.Contains(direction) && direction == direction.ToLower() && !revisit && direction != "start")
					{
						var newRoute = new List<string>(route) { direction };
						Paths(newRoute, true);
					}
				}
			}
		}
    }
}
