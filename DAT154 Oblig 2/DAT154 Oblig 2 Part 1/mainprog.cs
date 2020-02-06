using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main() {
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Planet("Mercury", "Darkgrey", 2439, 57910, 88 * 24, 1416, 47),
			new Planet("Venus", "Beige", 6051, 108200, 225 * 24, 243, 35),
			new Planet("Earth", "Blue", 6371, 149600, 365 * 24, 24, 30),
			new Planet("Mars", "Red", 3389, 227940, 687 * 24, 25, 24),
			new Planet("Jupiter", "Beige Red", 69911, 778330, 4333, 10, 13),
			new Planet("Saturn", "Eggshell", 58232, 1429400, 10760, 11, 10),
			new Planet("Uranus", "Pale blue", 25362, 2870990, 30685, 17, 7),
			new Planet("Neptune", "Blue", 24622, 4504300, 60190, 16, 5),
			new DwarfPlanet("Pluto", "Steel Red", 1188, 5913520, 90550, 6387 * 24, 4743),
			new AsteroidBelt("The asteroid belt", "Grey Rock", 69420),
			new Asteroid("243 Ida", "Grey", 16, 4280, 1767, 5, 420)


		};

		foreach (SpaceObject obj in solarSystem) {
			obj.Draw();
			
		}

		Console.ReadLine();
		
	}
}