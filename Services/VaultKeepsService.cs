using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly VaultsService _vs;
        public VaultKeepsService(VaultKeepsRepository repo, VaultsService vs)
        {
            _repo = repo;
            _vs = vs;
        }
        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);

        }
        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, string userId)
        {
            return _repo.GetKeepsByVaultId(id, userId);
        }


        public VaultKeep Get(int id, string userId)
        {
            VaultKeep exists = _repo.GetById(id, userId);
            if (exists == null)
            {
                throw new Exception("Wrong Keep Bud!");
            }
            return exists;
        }

        public VaultKeep Delete(int id, string userId)
        {

            _repo.Delete(id);
            return exists;
        }
    }
}