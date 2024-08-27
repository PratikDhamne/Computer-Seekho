using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IEnquiryService
    {
        Task AddEnquiry(Enquiry enquiry);
        Task UpdateEnquiry(Enquiry enquiry);
        Task DeleteEnquiry(int id);
        Task<Enquiry> GetEnquiryById(int id);
        Task<IEnumerable<Enquiry>> GetAllEnquiries();
        Task UpdateEnquiryProcessedFlag(int enquiryId);
        Task<IEnumerable<Enquiry>> GetEnquiriesByStaffId(int staffId);
        Task<Enquiry> GetByName(string name);
        Task<Enquiry> GetByMobile(string mobile);
    }
}
