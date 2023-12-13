

using DonationModel.Model;

namespace DonationBlazorServerSide.Data;

public class PaymentMethodService
{
    private DonationContext _context;
    public PaymentMethodService(DonationContext context) {
        _context = context;
    }

    public async Task<List<PaymentMethod>> GetPaymentMethodsAsync()
    {

    
        if (_context.PaymentMethods != null)
        {
            return await _context.PaymentMethods.ToListAsync();
        }
        else
        {

            return new List<PaymentMethod>(); 
        }
    }
}
