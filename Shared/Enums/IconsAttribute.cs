using System;
using Blazorise;

namespace TrouvailleFrontend.Shared.Enums {
    public class IconsAttribute : Attribute {
        public string Icon { get; }

        public IconsAttribute(string icon) {
            Icon = icon;
        }
    }
}