
namespace DonationBlazorServerSide.Controllers
{
    [Authorize (Roles="Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class ContactsController : ControllerBase
    {
        private readonly DonationContext _context;
        // private readonly HttpClient _httpClient;
        public ContactsController(DonationContext context/*,HttpClient httpClient*/)
        {
            _context = context;
            // _httpClient= httpClient;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContatcs()
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            return Ok(await _context.Contacts.ToListAsync());
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContatc(string id)
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(string id, Contact contact) //Changed  string id => int id
        {
            if (id != contact.AccountNo.ToString())
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
          if (_context.Contacts == null)
          {
              return Problem("Entity set 'SchoolDbContext.Students'  is null.");
          }
            _context.Contacts.Add(contact);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(contact.AccountNo.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContact", new { id = contact.AccountNo.ToString() }, contact);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var student = await _context.Contacts.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(string id)
        {
            return (_context.Contacts?.Any(e => e.AccountNo.ToString() == id)).GetValueOrDefault();
        }
    }
}
