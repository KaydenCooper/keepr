using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Keep> Get(string userId)
        {
            return _repo.Get(userId);
        }
        public Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid Keep Id");
            }
            return foundKeep;
        }
        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }


        public string Delete(string userId, int id)
        {
            GetById(id);
            bool deleted = _repo.Delete(userId, id);
            if (!deleted)
            {
                throw new Exception("Sorry You No Own This!");
            }
            return "Deleted!";
        }

        public Keep Edit(Keep updatedKeep)
        {
            Keep foundKeep = GetById(updatedKeep.Id);
            foundKeep.Name = updatedKeep.Name == null ? foundKeep.Name : updatedKeep.Name;
            foundKeep.Description = updatedKeep.Description == null ? foundKeep.Description : updatedKeep.Description;
            foundKeep.Img = updatedKeep.Img == null ? foundKeep.Img : updatedKeep.Img;
            bool edited = _repo.Edit(updatedKeep);
            if (!edited)
            {
                throw new Exception("You No Own This!");
            }
            return updatedKeep;
        }
    }
}