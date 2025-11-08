using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IContact
    {
        Task<Contacts> Addcontact(string firstname, string lastname, string email, string phone, string subject,string desc);
        Task<List<Contacts>> GetAllcontact();

        string Deletecontact(string id);
        Contacts getbyidcontact(string id);
        Task<Contacts> Updatecontact(string id, string firstname, string lastname, string email, string phone, string subject, string desc);
    }
}
