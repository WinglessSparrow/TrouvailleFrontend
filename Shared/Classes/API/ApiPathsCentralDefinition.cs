namespace TrouvailleFrontend.Shared.Classes.API {
    public class ApiPathsCentralDefinition {
        public const string API_IP = "https://141.79.34.86:5001";
        public const string API_PRODUCTS_IN_RANGE = API_IP + "/api/products";
        public const string API_PRODUCT_BY_ID = API_IP + "/api/products";
        public const string API_PRODUCTS_BY_ID_ARRAY = API_IP + "/api/products/GetMultiple";
        public const string API_PRODUCT_COUNT = API_IP + "/api/Products/Count";
        public const string API_ORDER = API_IP + "/api/Orders";
        public const string API_LOGIN = API_IP + "/api/auth/customer/login";
        public const string API_REGISTER = API_IP + "/api/auth/customer/register";
        public const string API_RESET_PASSWORD = API_IP + "/api/auth/customer/resetPassword";
    }
}