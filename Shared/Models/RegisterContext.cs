using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class RegisterContext {
        [ValidateComplexType]
        public RegisterModel RegisterModel { get; set; } = new();
        [ValidateComplexType]
        public AddressModel AddressModel { get; set; } = new();

        //this right here is retarded, BUT! it lets me validate the whole form without extra classes.
        //API needs the RegisterModel, but validation through only it require development 
        //of already existing elements but slightly different
        //and I can't be fucked do develop the same thing twice.
        public void PrepareRegisterModel() {
            RegisterModel.CityName = AddressModel.CityName;
            RegisterModel.Country = AddressModel.Country;
            RegisterModel.PostalCode = AddressModel.PostalCode;
            RegisterModel.State = AddressModel.State;
            RegisterModel.Street = AddressModel.Street;
            RegisterModel.StreetNumber = AddressModel.StreetNumber;
        }
    }
}