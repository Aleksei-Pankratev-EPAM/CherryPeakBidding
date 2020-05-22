using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Messages;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Infrastructure.Contracts;
using CherryPeakTrading.Infrastructure.Contracts.Messaging;
using System;
using System.Threading.Tasks;
using Lot = CherryPeakTrading.Data.Contracts.Entities.Lot;

namespace CherryPeakTrading.BL
{
    public class LotsLogic : ILotsLogic
    {
        private IMapperAdapter _mapperAdapter;
        private ILotRepository _lotRepository;
        private IMessagePublisher<LotCreatedMessage> _messagePublisher;

        public LotsLogic(IMapperAdapter mapperAdapter, ILotRepository lotRepository, IMessagePublisher<LotCreatedMessage> messagePublisher)
        {
            _mapperAdapter = mapperAdapter;
            _lotRepository = lotRepository;
            _messagePublisher = messagePublisher;
        }

        public async Task<LotModel> CreateLot(LotModel filter)
        {
            Data.Contracts.Entities.Lot lot = _mapperAdapter.Map<Lot>(filter);

            Lot result = await _lotRepository.Add(lot);
            SentMessageToQueue(result.Id);

            var savedLot = _mapperAdapter.Map<LotModel>(result);
            return savedLot;
        }

        private void SentMessageToQueue(Guid lotId)
        {
            _messagePublisher.Publish(new LotCreatedMessage { LotId = lotId });
        }
    }
}
