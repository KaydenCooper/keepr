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
        // public IEnumerable<Vault> Get()
        // {
        //     return _repo.Get();
        // }

        public IEnumerable<Vault> Get(string userId)
        {
            return _repo.Get(userId);

        }
        public Vault GetById(int id, string userId)
        {
            Vault foundVault = _repo.GetById(id, userId);
            if (foundVault == null)
            {
                throw new Exception("Invalid Vault Id");
            }
            return foundVault;
        }
        public Vault Create(Vault newVault)
        {
            int id = _repo.Create(newVault);
            newVault.Id = id;
            return newVault;
        }


        public string Delete(string userId, int id)
        {
            bool deleted = _repo.Delete(userId, id);
            if (!deleted)
            {
                throw new Exception("Sorry You No Own This!");
            }
            return "Deleted!";
        }

        public Vault Edit(Vault updatedVault, string userId)
        {
            Vault foundVault = GetById(updatedVault.Id, userId);
            bool edited = _repo.Edit(updatedVault);
            if (!edited)
            {
                throw new Exception("You No Own This!");
            }
            return updatedVault;
        }
    }
}