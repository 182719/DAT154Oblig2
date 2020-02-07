using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main() {
		//TODO: legge inn tall på måner
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Planet("Mercury", "Darkgrey", 2439, 57910, 88 * 24, 1416, 47, null),
			new Planet("Venus", "Beige", 6051, 108200, 225 * 24, 243, 35, null),
			new Planet("Earth", "Blue", 6371, 149600, 365 * 24, 24, 30,
				new List<Moon>(){ new Moon("Moon", "White",  3475 / 2, 384400 / 1000, 30 * 24, 27 * 24 , 1, null)}),
			new Planet("Mars", "Red", 3389, 227940, 687 * 24, 25, 24,
				new List<Moon>()
				{
					new Moon("Phobos", "Grey", 22 / 2, 9378 / 1000, 8, (int)(0.3 * 24),  2),
					new Moon("Deimos", "Off-white", 23 / 2, 9376 / 1000, 30, (int)(1.2 * 24), 1)
				}),
			new Planet("Jupiter", "Beige Red", 69911, 778330, 4333, 10, 13,
				new List<Moon>()
				{
					new Moon("Metris", "", 0, 0, 0, 0, 0),
					new Moon("Metris", "", 0, 0, 0, 0, 0),

				}),
			new Planet("Saturn", "Eggshell", 58232, 1429400, 10760, 11, 10,
				new List<Moon>()
				{
					new Moon("Pan", "", 0, 0, 0, 0, 0),
					new Moon("Atlas", "", 0, 0, 0, 0, 0),

				}),
			new Planet("Uranus", "Pale blue", 25362, 2870990, 30685, 17, 7,
				new List<Moon>()
				{
					new Moon("Cordelia", "", 0, 0, 0, 0, 0),
					new Moon("Ophelia", "", 0, 0, 0, 0, 0),

				}),
			new Planet("Neptune", "Blue", 24622, 4504300, 60190, 16, 5,
				new List<Moon>()
				{
					new Moon("Naiad", "", 0, 0, 0, 0, 0),
					new Moon("Thalassa", "", 0, 0, 0, 0, 0),

				}),
			new DwarfPlanet("Pluto", "Steel Red", 1188, 5913520, 90550, 6387 * 24, 4743,
				new List<Moon>()
				{
					new Moon("Charon", "", 0, 0, 0, 0, 0),
					new Moon("Nix", "", 0, 0, 0, 0, 0),

				}),
			new AsteroidBelt("The asteroid belt", "Grey Rock", 69420),
			new Asteroid("243 Ida", "Grey", 16, 4280, 1767, 5, 420, null)


		};

		foreach (SpaceObject obj in solarSystem) {
			obj.Draw();
			
		}
		Moon m = new Moon("Moon", "White", 3475 / 2, 384400 / 1000, 30 * 24, 27 * 24, 1, null);
		

		Console.ReadLine();
		
	}
}