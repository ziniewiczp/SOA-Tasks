using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Circus cyrk = new Circus() { Name = "Super Cyrk" };
            Zoo zoo = new Zoo() { Name = "Ekstra Zoo" };

            Console.WriteLine("Wybierz jedną z poniższych opcji: ");
            Console.WriteLine("a) Prezentacja zwierząt w cyrku");
            Console.WriteLine("b) Obejrzenie programu cyrku Super Cyrk");
            Console.WriteLine("c) Posłuchanie dźwięków w zoo Ekstra Zoo");
            Console.WriteLine("d) Wyświetlenie imienia pierwszego znalezionego w zoo futrzaka");
            Console.WriteLine("e) Wyświetlenie imion wszystkich zwierząt w cyrku");

            var input = Console.ReadKey();

            while (input.Key != ConsoleKey.Escape)
            {
                Console.WriteLine();
                Console.WriteLine();

                switch (input.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine(cyrk.AnimalsIntroduction());
                        break;

                    case ConsoleKey.B:
                        Console.WriteLine(cyrk.Show());
                        break;

                    case ConsoleKey.C:
                        Console.WriteLine(zoo.Sounds());
                        break;

                    case ConsoleKey.D:
                        var futrzak = zoo.Animals.FirstOrDefault(x => x.HaveFur == true);

                        if( futrzak != null)
                        {
                            Console.WriteLine(futrzak.Name);
                        }
                        else Console.WriteLine("Niestety nie znaleziono żadnego futrzaka w zoo");
                        break;

                    case ConsoleKey.E:
                        foreach(Animal animal in cyrk.Animals)
                        {
                            Console.WriteLine(animal.Name);
                        }
                        break;

                    default:
                        Console.WriteLine("Nacisnąłeś zły klawisz...");
                        break;
                }

                Console.WriteLine("Wybierz jeszcze raz lub naciśnij ESC aby zakończyć");
                input = Console.ReadKey();
            }
        }
    }

    public class Animal
    {
        public string Name;
        public float Weight;
        public bool HaveFur;

        public virtual string Sound() { return "Some animal sound"; }
        public virtual string Trick() { return "Sleeping"; }
        public virtual int CountLegs() { return 0; }
    }

    public class Circus : ICircus
    {
        public List<Animal> Animals;
        public string Name;

        public Circus()
        {
            Animals = new List<Animal>();

            Animals.Add(new Cat() { Name = "cat1", Weight = 5.4F, HaveFur = true, Color = "white" });
            Animals.Add(new Pony() { Name = "pony1", Weight = 50.2F, HaveFur = false, IsMagic = true });
            Animals.Add(new Ant() { Name = "ant1", Weight = 0.01F, HaveFur = false, IsQueen = false });
            Animals.Add(new Ant() { Name = "ant2", Weight = 0.01F, HaveFur = false, IsQueen = false });
            Animals.Add(new Elephant() { Name = "elephant1", Weight = 2500.4F, HaveFur = false });
            Animals.Add(new Giraffe() { Name = "giraffe1", Weight = 800.3F, HaveFur = true });
            Animals.Add(new Giraffe() { Name = "giraffe2", Weight = 850.3F, HaveFur = true });
        }

        public string AnimalsIntroduction()
        {
            string animalsIntroduction = "";

            foreach(Animal animal in Animals)
            {
                animalsIntroduction = String.Format("{0}, {1}", animalsIntroduction, animal.Sound());
            }
                
            return animalsIntroduction;
        }

        public int Patter(int HowMuch)
        {
            int patter = 0;

            foreach(Animal animal in Animals)
            {
                patter = patter + animal.CountLegs();               
            }

            return patter * HowMuch;
        }

        public string Show()
        {
            string tricks = "";

            foreach( Animal animal in Animals)
            {
                tricks = String.Format("{0}, {1}", tricks, animal.Trick());
            }

            return tricks;
        }
    }

    public class Zoo : IZoo
    {
        public List<Animal> Animals;
        public string Name;

        public Zoo()
        {
            Animals = new List<Animal>();

            Animals.Add(new Cat() { Name = "cat1", Weight = 5.4F, HaveFur = true, Color = "black" });
            Animals.Add(new Cat() { Name = "cat2", Weight = 5.4F, HaveFur = true, Color = "white" });
            Animals.Add(new Ant() { Name = "ant1", Weight = 0.01F, HaveFur = false, IsQueen = false });
            Animals.Add(new Giraffe() { Name = "giraffe1", Weight = 800.3F, HaveFur = true });
            Animals.Add(new Elephant() { Name = "elephant1", Weight = 2500.4F, HaveFur = false });
            Animals.Add(new Giraffe() { Name = "giraffe2", Weight = 800.3F, HaveFur = true });
            Animals.Add(new Giraffe() { Name = "giraffe3", Weight = 850.3F, HaveFur = true });
            Animals.Add(new Ant() { Name = "ant2", Weight = 0.01F, HaveFur = false, IsQueen = true });
            Animals.Add(new Elephant() { Name = "elephant2", Weight = 2500.4F, HaveFur = false });
            Animals.Add(new Elephant() { Name = "elephant3", Weight = 2500.4F, HaveFur = false });
        }

        public string Sounds()
        {
            string sounds = "";

            foreach (Animal animal in Animals)
            {
                sounds = String.Format("{0}, {1}", sounds, animal.Sound());
            }

            return sounds;
        }
    }

    public class Cat : Animal
    {
        public string Color;

        public override string Sound()
        {
            return "Miau";
        }

        public override string Trick()
        {
            return "Chasing mouse";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    public class Pony : Animal
    {
        public bool IsMagic;

        public override string Sound()
        {
            return "Ihaa";
        }

        public override string Trick()
        {
            return "Jumping over obstacles";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    public class Ant : Animal
    {
        public bool IsQueen;

        public override string Sound()
        {
            return "krz krz";
        }

        public override string Trick()
        {
            return "Lifting weights on their back";
        }

        public override int CountLegs()
        {
            return 6;
        }
    }

    public class Elephant : Animal
    {
        public override string Sound()
        {
            return "Truu";
        }

        public override string Trick()
        {
            return "Moving his trunk";
        }

        public override int CountLegs()
        {
            return 4;
        }
    };

    public class Giraffe : Animal
    {
        public override string Sound()
        {
            return "Girrr";
        }

        public override string Trick()
        {
            return "Reaching high positioned objects";
        }

        public override int CountLegs()
        {
            return 4;
        }
    };

    public interface ICircus
    {
        string AnimalsIntroduction();
        string Show();
        int Patter(int HowMuch);
    }

    public interface IZoo
    {
        string Sounds();
    }
}
