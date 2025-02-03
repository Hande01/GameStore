using GameStore.Models.DTO;

namespace GameStore.DL.StaticDB
{
    public static class InMemoryDb
    {
        public static List<Developer> Developers
            = new List<Developer>
        {
            new Developer
            {
                Id = "1",
                Name = "PUBG Studios"
            },
            new Developer
            {
                Id = "2",
                Name = "LightSpeed"
            },
            new Developer
            {
                Id = "3",
                Name = "Valve"
            },
            new Developer
            {
                Id = "4",
                Name = "Mike Morasky"
            },
            new Developer
            {
                Id = "5",
                Name = "Markus Persson"
            },
            new Developer
            {
                Id = "6",
                Name = "Jens Bergensten"
            },
        };

        //internal static List<Game> Games = new List<Game>
        //{
        //    new Game
        //    {
        //        Id = "1",
        //        Title = "Pubg",
        //        Year = 2018,
        //        Developers = new List<int>
        //        {
        //            1, 2
        //        }
        //    },
        //    new Game
        //    {
        //        Id = "2",
        //        Title = "CS:GO",
        //        Year = 2012,
        //        Developers = new List<int>
        //        {
        //            3, 4
        //        }
        //    },
        //    new Game
        //    {
        //        Id = "3",
        //        Title = "Mincraft",
        //        Year = 2011,
        //        Developers = new List<int>
        //        {
        //            5, 6
        //    }
        //},
        //};
    }
}