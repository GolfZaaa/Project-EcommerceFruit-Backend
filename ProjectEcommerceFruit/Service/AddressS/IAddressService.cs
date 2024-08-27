using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.AddressS
{
    public interface IAddressService
    {
        Task<List<AddressRespone>> GetAddressByUserIdAsync();
        Task<AddressRespone> GetAddressgotoOrderByUserIdAsync();
        Task<AddressRespone> GetAddressByStoreAsync();
        Task<Object> CreateUpdateAddressAsync(AddressRequest request);
        Task<Object> RemoveAddressByIdAsync(int storeId);
        Task<Boolean> IsUsedAddressAsync(int addressId, bool storeormine);
    }
}
