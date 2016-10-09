﻿using System.Collections.Generic;

namespace Investigation
{
    internal class Room
    {
        private readonly string _type = "house";
        public List<string> Infos = new List<string>();
        public string Name = "location";

        public Room()
        {
            // Generate name
            string[] First = {"An haunted", "A nice", "An abandonned", "A dirty"};
            string[] Second = {"house", "manor", "hut", "appartment"};

            var first = Application.Instance.Randomizer.Next(0, First.Length);
            var second = Application.Instance.Randomizer.Next(0, Second.Length);
            Name = First[first] + " " + Second[second];
            _type = Second[second];

            //Generate infos
            var rand = Application.Instance.Randomizer.Next(1, 4);
            for (var i = 0; i < rand; i++)
            {
                string owner;
                var thrust = Application.Instance.Randomizer.Next(0, 100);
                if (thrust <= 20)
                    owner = Application.Instance.Investigation.Properties.Murderer.Name;
                else
                {
                    var npcs = Application.Instance.Randomizer.Next(0,
                        Application.Instance.Investigation.Properties.Suspects.Count);
                    owner = Application.Instance.Investigation.Properties.Suspects[npcs].Name;
                }
                string[] Object = {"hat", "tissue", "clock", "knife", "glasses", "coat", "pen", "scarf"};
                var o = Application.Instance.Randomizer.Next(0, Object.Length);

                Infos.Add("A " + Object[o] + " that belongs to " + owner);
            }
        }

        public void Search()
        {
            Program.WriteScreen("You enter the " + _type + ". After a complete research, you have found :", 50,
                "Searching " + Name, true);
            foreach (var info in Infos)
            {
                Program.WriteScreen(info, 30);
            }
            Program.WaitKeyToContinue();
            Application.Instance.Investigation.ShowSearchScreen();
        }
    }
}