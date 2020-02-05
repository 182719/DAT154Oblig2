using System;

namespace SpaceSim
{
    public class SpaceObject
    {
        public String name { get; set; }
        public String color { get; set; }
        public int radius { get; set; } 

        public SpaceObject(String name)
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
        public int orbitalRadius { get; set; }
        public int orbitalPeriod { get; set; }
        public int rotationalPeriod { get; set; }

        public Star(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public int orbitalRadius { get; set; }
        public int orbitalPeriod { get; set; }
        public int orbitalSpeed { get; set; }
        public int rotationalPeriod { get; set; }
        public double[] position { get; set; } = new double[2];


        public Planet(String name) : base(name) { }
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
        public Moon(String name) : base(name) { }
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
        public DwarfPlanet(String name) : base(name) { }
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

        public Comet(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }
    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name) :base(name) { }
        public override void Draw()
        {
            Console.Write("Asteroid belt : ");
            base.Draw();
        }
    }
    public class Asteroid : Planet
    {
        public Asteroid(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }
}

