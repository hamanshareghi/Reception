using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class CustomerService : ICustomer
    {
        private UserManager<ApplicationUser> _userManager;

        public CustomerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public Tuple<List<ApplicationUser>,int> GetAll(int pageId =1)
        {
            int take = 0;
            if (take == 0)
                take = 30;
            int skip = (pageId - 1) * take;
            int pageCount = _userManager.Users.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;

            }

            var query = _userManager.Users
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take)
                .ToList();
            return Tuple.Create(query,pageCount);
        }

        public Tuple<List<ApplicationUser>,int> GetUserBySearch(string search,int pageId=1)
        {
            int take = 0;
            if (take == 0)
                take = 30;
            int skip = (pageId - 1) * take;
            int pageCount = _userManager.Users
                .Count(s => s.FullName.ToLower().Contains(search)
                            || s.Contact.ToLower().Contains(search)
                            || s.Address.ToLower().Contains(search)
                            || s.Email.ToLower().Contains(search)
                            || s.PhoneNumber.ToLower().Contains(search));
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }
            var  model = _userManager.Users
                .OrderByDescending(s=>s.UpDateTime)
                .Where(
                s=>s.FullName.ToLower().Contains(search)
                || s.Contact.ToLower().Contains(search)
                || s.Address.ToLower().Contains(search)
                || s.Email.ToLower().Contains(search)
                || s.PhoneNumber.ToLower().Contains(search)
            )
                .Skip(skip)
                .Take(take)
                .ToList();
            return Tuple.Create(model, pageCount);
        }

        public int GetCustomerCount()
        {
            return  _userManager.Users.Count();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
