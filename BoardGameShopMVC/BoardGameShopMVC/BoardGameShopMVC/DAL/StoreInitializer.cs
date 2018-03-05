using System;
using System.Collections.Generic;
using System.Data.Entity;
using BoardGameShopMVC.Models;

namespace BoardGameShopMVC.DAL
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            SeedStoreData(context);

            base.Seed(context);
        }

        private void SeedStoreData(StoreContext context)
        {
            var category = new List<Category>
            {
                new Category() {CategoryId = 1, Name = "Edukacyjne", IconFileName = "educational.png"},
                new Category() {CategoryId = 2, Name = "Ekonomiczne", IconFileName = "economic.png"},
                new Category() {CategoryId = 3, Name = "Horror", IconFileName = "horror.png"},
                new Category() {CategoryId = 4, Name = "Imprezowe", IconFileName = "partyGame.png"},
                new Category() {CategoryId = 5, Name = "Karciane", IconFileName = "cardGame.png"},
                new Category() {CategoryId = 6, Name = "Kooperacyjne", IconFileName = "cooperative.png"},
                new Category() {CategoryId = 7, Name = "Logiczne", IconFileName = "logic.png"},
                new Category() {CategoryId = 8, Name = "Przygodowe", IconFileName = "adventure.png"},
                new Category() {CategoryId = 9, Name = "Strategiczne", IconFileName = "strategy.png"},
                new Category() {CategoryId = 10, Name = "Wojenne", IconFileName = "wargame.png"},
                new Category() {CategoryId = 11, Name = "Inne", IconFileName = "other.png"},
                new Category() {CategoryId = 12, Name = "Promocje", IconFileName = "promos.png"},
            };
            
            category.ForEach(x => context.Categories.Add(x));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game() { GameID = 1, DesignerName = "Antoine Bauza", GameTitle = "7 Wonders", Price = 129.99M, GameFileName = "7wonder.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 9},
                new Game() { GameID = 2, DesignerName = "Eric Lange", GameTitle = "Blood Rage", Price = 259.99M, GameFileName = "bloodRage.png", IsBestseller = true, DateAdded = new DateTime(2018, 03, 05), CategoryId = 10},
                new Game() { GameID = 3, DesignerName = "Jean-Louis Roubira", GameTitle = "Dixit", Price = 89.99M, GameFileName = "dixit.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 4},
                new Game() { GameID = 4, DesignerName = "Corey Konieczka, Nikki Valens", GameTitle = "Eldritch Horror", Price = 299.99M, GameFileName = "eldritchHorror.png", IsBestseller = true, DateAdded = new DateTime(2018, 03, 05), CategoryId = 3},
                new Game() { GameID = 5, DesignerName = "Bruno Cathala", GameTitle = "Five Tribes", Price = 149.99M , GameFileName = "fiveTribes.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 2},
                new Game() { GameID = 6, DesignerName = "Nikki Valens", GameTitle = "Mansions of Madness", Price = 359.99M, GameFileName = "mansionsOfMadness.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 3},
                new Game() { GameID = 7, DesignerName = "Uwe Rosenberg", GameTitle = "Patchwork", Price = 59.99M, GameFileName = "patchwork.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 7},
                new Game() { GameID = 8, DesignerName = "Philippe Keyaerts", GameTitle = "Smallwordl", Price = 149.99M, GameFileName = "smallworld.png", IsBestseller = true, DateAdded = new DateTime(2018, 03, 05), CategoryId = 9},
                new Game() { GameID = 9, DesignerName = "Colby Dauch", GameTitle = "Summoner Wars", Price = 159.99M , GameFileName = "summonerWars.png", IsBestseller = false, DateAdded = new DateTime(2018, 03, 05), CategoryId = 5}
            };

            games.ForEach(x => context.Games.Add(x));
        }
    }
}