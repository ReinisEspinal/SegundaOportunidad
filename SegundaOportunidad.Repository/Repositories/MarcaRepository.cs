using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.Interfaces;
using SegundaOportunidad.Repository.BaseRepository;
using SegundaOportunidad.Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SegundaOportunidad.Repository.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        private readonly SegundaOportunidadContext db;

        public MarcaRepository(SegundaOportunidadContext db) : base(db)
        {
            this.db = db;
        }
        public async Task AddMarca(Marca marca)
        {
            try
            {
                await base.Add(marca);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateMarca(Marca marca)
        {
            try
            {
                base.Update(marca);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Marca> GetMarcas()
        {
            try
            {
                return base.FindAll(oMarca => !oMarca.Deleted);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Marca> GetMarcaById(int id)
        {
            try
            {
                return await base.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ExisteMarca()
        {
            try
            {
                return await base.Exists(oMarca => !oMarca.Deleted);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public async Task<bool> SaveMarca()
        {
            return await base.Commit();
        }

    }
}
