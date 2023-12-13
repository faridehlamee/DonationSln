
namespace DonationBlazorServerSide.Data
{
    //[Authorize(Roles = "Admin")]
    public class ContactService
    {
         private DonationContext _context;
         //private readonly IAuthorizationService _authorizationService;
        public ContactService(DonationContext context/*,IAuthorizationService authorizationService*/) {
            _context = context;
            // _authorizationService = authorizationService;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {

        
            if (_context.Contacts != null)
            {
                return await _context.Contacts.ToListAsync();
            }
            else
            {

                return new List<Contact>(); 
            }
        }


        public async Task<Contact?> GetContactByIdAsync(int id) {
            // challenge 1 : why if (_context.Contacts.FindAsync(id) != null) doesn't work?????
            if (_context.Contacts!= null){
                return await _context.Contacts.FindAsync(id) ?? null;
            }
            else
            {
                return new Contact(); 
            }
        }

        public async Task<Contact?> InsertContactAsync(Contact contact, string createdBy) {
            contact.CreatedBy = createdBy;
            _context.Contacts?.Add(contact);
            await _context!.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact c, string modifiedBy) {
            var contact = await _context.Contacts!.FindAsync(id);

            if (contact == null)
            return null!;

            contact.FirstName = c.FirstName;
            contact.LastName = c.LastName;
            contact.Email = c.Email;
            contact.City = c.City;
            contact.PostalCode = c.PostalCode;
            contact.Country = c.Country;

            contact.Modified = DateTime.UtcNow;
            contact.ModifiedBy = modifiedBy;


            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return contact!;
        }

        public async Task<Contact> DeleteContactAsync(int id) {
            var contact = await _context.Contacts!.FindAsync(id);

            if (contact == null)
            return null!;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact!;
        }

        private bool ContactExists(int id) {
            return _context.Contacts!.Any(e => e.AccountNo == id);
        }
    }
}