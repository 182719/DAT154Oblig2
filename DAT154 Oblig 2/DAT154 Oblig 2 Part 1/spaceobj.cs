using System;

namespace SpaceSim
{
    public class SpaceObject
    {
        public String name { get; set; }
        public String color { get; set; }
        public int radius { get; set; } //represented i km

        public SpaceObject(String name, String color, int radius)
        {
            this.name = name;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

    }

    public class Star : SpaceObject
    {
        public int orbitalRadius { get; set; } //represented in (000 km)
        public int orbitalPeriod { get; set; } //represented in hours
        public int rotationalPeriod { get; set; } // represented in hours

        public Star(String name, String color, int radius) : base(name, color, radius) { }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public int orbitalRadius { get; set; } // represented in (000 km)
        public int orbitalPeriod { get; set; } //represented in hours
        public int orbitalSpeed { get; set; } // represented in km/s
        public int rotationalPeriod { get; set; } // represented in hours
        public double[] position { get; set; } = new double[2];


        public Planet(String name, String color, int radius, int orbitalRadius, int orbitalPeriod, int rotationalPeriod, int orbitalSpeed) 
            : base(name, color, radius) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
        public virtual double[] calPosition(int time)
        {   
            this.position[0] = Math.Cos(time * orbitalSpeed * 3.1416 / 180) * orbitalRadius;
            this.position[1] = Math.Sin(time * orbitalSpeed * 3.1416 / 180) * orbitalRadius;
            return this.position;
        }

    }

    public class Moon : Planet
    {
        public Planet planet { get; set; }
        public Moon(String name, String color, int radius, int orbitalRadius, int orbitalPeriod, int rotationalPeriod, int orbitalSpeed)
            : base(name, color, radius, orbitalRadius, orbitalPeriod, rotationalPeriod, orbitalSpeed) { }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
        public override double[] calPosition(int time)
        {
            this.position[0] = planet.position[0] + Math.Cos(time * orbitalSpeed * 3.1416 / 180) * orbitalRadius;
            this.position[1] = planet.position[1] + Math.Sin(time * orbitalSpeed * 3.1416 / 180) * orbitalRadius;
            return this.position; ;
        }

    }
    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String name, String color, int radius, int orbitalRadius, int orbitalPeriod, int rotationalPeriod, int orbitalSpeed)
            : base(name, color, radius, orbitalRadius, orbitalPeriod, rotationalPeriod, orbitalSpeed) { }
        public override void Draw()
        {
            Console.Write("Dwarf planet : ");
            base.Draw();
        }
    }


    public class Comet : SpaceObject
    {
        public int orbitalRadius { get; set; }
        public int orbitalPeriod { get; set; }
        public int rotationalPeriod { get; set; }

        public Comet(String name, String color, int radius) : base(name, color, radius) { }
        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }
    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name, String color, int radius) : base(name, color, radius) { }
        public override void Draw()
        {
            Console.Write("Asteroid belt : ");
            base.Draw();
        }
    }
    public class Asteroid : Planet
    {
        public Asteroid(String name, String color, int radius, int orbitalRadius, int orbitalPeriod, int rotationalPeriod, int orbitalSpeed)
            : base(name, color, radius, orbitalRadius, orbitalPeriod, rotationalPeriod, orbitalSpeed) { }
        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }
}

