using Blazorise;

namespace TrouvailleFrontend.Shared.Enums {
    public enum PaymentMethod {
        [Icons("<i class='fas fa-file-invoice-dollar'></i>")]
        Rechnung,
        [Icons("<i class='fas fa-money-bill-wave'></i>")]
        Vorkasse,
        [Icons("<i class='fab fa-paypal'></i>")]
        Paypal
    }
}