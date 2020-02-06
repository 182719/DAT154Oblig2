using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main() {
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Planet("Mercury", "Darkgrey", 2439, 57910, 2112, 1416, 47)
		};

		foreach (SpaceObject obj in solarSystem) {
			obj.Draw();
			
		}

		Console.ReadLine();
		
	}
}