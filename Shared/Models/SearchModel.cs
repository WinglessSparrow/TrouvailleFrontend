using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Models {
    public class SearchModel {
        public List<CategoryModel> Categories { get; set; } = new();

        public List<string> GetCategoryIds() {
            var list = new List<string>();

            foreach (var id in Categories) {
                list.Add(id.CategoryId);
            }

            return list;
        }

        public string SearchWord {
            get {
                return Parameteres["searchWord"];
            }
            set {
                Parameteres["searchWord"] = value;
            }
        }
        public bool Ascending {
            get {
                return bool.Parse(Parameteres["asc"]);
            }
            set {
                Parameteres["asc"] = value.ToString().ToLower();
            }
        }
        public Dictionary<string, string> Parameteres { get; set; } = new Dictionary<string, string>(){
            {"searchWord", ""},
            {"asc", "false"},
            {"orderBy", "Price"},
            {"onlyActive", "true"}
        };
    }
}