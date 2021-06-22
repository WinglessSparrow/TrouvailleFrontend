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
                new(){Name="Brush", CategoryId="4"},
                new(){Name="More", CategoryId="5"}
                };
        }
    }
}