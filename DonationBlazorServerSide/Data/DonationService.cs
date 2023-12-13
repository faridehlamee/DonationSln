using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonationModel.Model;

namespace DonationBlazorServerSide.Data
{
    public class DonationService
    {
        
         private DonationContext _context;

        public DonationService(DonationContext context) {
            _context = context;           
        }

        public async Task<List<Donation>> GetDonationsAsync(int? accountNo = null)
        {
        
            if (_context.Donations != null)
            {              
                return await _context.Donations
                    .Include(c => c.Contact)
                    .Include(t=>t.TransactionType)
                    .Include(p=>p.PaymentMethod)
                    //.OrderByDescending(d => d.Date)
                    .ToListAsync();
                
            }
            else
            {

                return new List<Donation>(); 
            }
        }
        public async Task<List<Donation>> GetDonationsContactAsync(int accountNo)
        {
        
            if (_context.Donations != null)
            {
                return await _context.Donations
                    .Include(c => c.Contact)
                    .Include(t => t.TransactionType)
                    .Include(p => p.PaymentMethod)
                    .Where(d => d.AccountNo == accountNo)
                    //.OrderByDescending(d => d.Date)
                    .ToListAsync();
                  
            }
            else
            {
                return new List<Donation>(); 
            }
        }


        public async Task<Donation?> GetDonationByIdAsync(int id) {       
            if (_context.Contacts!= null){
                return await _context.Donations!.FindAsync(id) ?? null;
            }
            else
            {
                return new Donation(); 
            }
        }

        public async Task<Donation?> InsertDonationAsync(Donation donation, string createdBy) {
            donation.CreatedBy = createdBy;
            _context.Donations?.Add(donation);
            await _context!.SaveChangesAsync();

            return donation;
        }

        public async Task<Donation> UpdateDonationAsync(int id, Donation d, string modifiedBy) {
            var donation = await _context.Donations!.FindAsync(id);

            if (donation == null)
            return null!;

            donation.TransId = id;
            donation.Date = d.Date;
            donation.Amount = d.Amount;
            donation.Notes = d.Notes;
            donation.AccountNo = d.AccountNo;
            donation.TransactionTypeId = d.TransactionTypeId;
            donation.PaymentMethodId = d.PaymentMethodId;


            donation.Modified = DateTime.UtcNow;
            donation.ModifiedBy = modifiedBy;


            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();

            return donation!;
        }

        public async Task<Donation> DeleteDonationAsync(int id) {
            var donation = await _context.Donations!.FindAsync(id);

            if (donation == null)
            return null!;

            _context.Donations.Remove(donation);
            await _context.SaveChangesAsync();

            return donation!;
        }

        private bool DonationExists(int id) {
            return _context.Donations!.Any(e => e.TransId == id);
        }
    }
}