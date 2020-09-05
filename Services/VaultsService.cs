using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Vault> Get(string userId)
        {
            return _repo.Get(userId);
        }
        public Vault GetById(int id)
        {
            Vault foundVault = _repo.GetById(id);
            if (foundVault == null)
            {
                throw new Exception("Invalid Vault Id");
            }
            return foundVault;
        }
        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
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

        public Vault Edit(Vault updatedVault)
        {
            Vault foundVault = GetById(updatedVault.Id);
            bool edited = _repo.Edit(updatedVault);
            if (!edited)
            {
                throw new Exception("You No Own This!");
            }
            return updatedVault;
        }
    }
}