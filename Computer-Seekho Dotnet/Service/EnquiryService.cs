using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class EnquiryService:IEnquiryService
    {
        private readonly Appdbcontext _context;

        public EnquiryService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddEnquiry(Enquiry enquiry)
        {
            _context.Enquiry.Add(enquiry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnquiry(int id)
        {
            var enquiry = await _context.Enquiry.FindAsync(id);
            if (enquiry != null)
            {
                _context.Enquiry.Remove(enquiry);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Enquiry> GetEnquiryById(int id)
        {
            return await _context.Enquiry.FindAsync(id);
        }

        public async Task<IEnumerable<Enquiry>> GetAllEnquiries()
        {
            return await _context.Enquiry.ToListAsync();
        }

        public async Task UpdateEnquiry(Enquiry enquiry)
        {
            _context.Entry(enquiry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEnquiryProcessedFlag(int enquiryId)
        {
            var enquiry = await _context.Enquiry.FindAsync(enquiryId);
            if (enquiry != null)
            {
                // Update the processed flag
                enquiry.EnquiryProcessedFlag = true; // Adjust according to your flag type
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Enquiry>> GetEnquiriesByStaffId(int staffId)
        {
            return await _context.Enquiry
                .Where(e => e.StaffId == staffId)
                .ToListAsync();
        }

        public async Task<Enquiry> GetByName(string name)
        {
            return await _context.Enquiry
                .FirstOrDefaultAsync(e => e.StudentName.Contains(name));
        }

        public async Task<Enquiry> GetByMobile(string mobile)
        {
            return await _context.Enquiry
                .FirstOrDefaultAsync(e => e.EnquirerMobile.Contains(mobile));
        }
    }
}
