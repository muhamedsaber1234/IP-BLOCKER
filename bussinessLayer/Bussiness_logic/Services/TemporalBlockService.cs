using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataacsess.IRepositories;
using Dataacsess.Repositories;
namespace Bussiness_logic.Services
{
    public class TemporalBlockService
    {
        private readonly ITemporalBlockRepository _repository;

        public TemporalBlockService(ITemporalBlockRepository repository)
        {
            _repository = repository;
        }

        public bool AddTemporalBlock(string countryCode, int durationMinutes)
        {
            var expiration = DateTime.UtcNow.AddMinutes(durationMinutes);
            return _repository.AddTemporalBlock(countryCode, expiration);
        }

        public void CleanupExpiredBlocks()
        {
            foreach (var block in _repository.GetAllTemporalBlocks())
            {
                if (DateTime.UtcNow >= block.Value)
                    _repository.RemoveTemporalBlock(block.Key);
            }
        }
    }
}
