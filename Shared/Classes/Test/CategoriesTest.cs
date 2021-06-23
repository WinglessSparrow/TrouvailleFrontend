using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class CategoriesTest : ICategoriesRetriever {
        public async Task<List<CategoryModel>> GetCategoriesAsync() {
            await Task.Run(() => Thread.Sleep(100));


            return new List<CategoryModel>(){
                new(){Name="Pencil", CategoryId="1"},
                new(){Name="Yo Mom", CategoryId="2"},
                new(){Name="Color", CategoryId="3"},
                new(){Name="Brush", CategoryId="4"}
                // new(){Name="Keanu", CategoryId="5"},
                // new(){Name="Senjougahara", CategoryId="6"},
                // new(){Name="Jouske", CategoryId="7"},
                // new(){Name="Araragi", CategoryId="8"},
                // new(){Name="Jotarou", CategoryId="9"},
                // new(){Name="Eren", CategoryId="10"},
                // new(){Name="Shmeren", CategoryId="11"},
                // new(){Name="Hurensohn", CategoryId="12"},
                // new(){Name="More", CategoryId="13"}
                };
        }
    }
}