using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.MessageDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageService _messageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageByID(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return Ok("Mesaj Silindi");
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var newMessage = _mapper.Map<Message>(createMessageDTO);
            _messageService.TCreate(newMessage);
            return Ok("Mesaj Oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var message = _mapper.Map<Message>(updateMessageDTO);
            _messageService.TUpdate(message);
            return Ok("Mesaj Güncellendi");
        }

        [HttpGet("ReadMessages")]
        public IActionResult ReadMessages()
        {
            var values = _messageService.TGetFilteredList(x => x.IsRead == true);
            return Ok(values);
        }

        [HttpGet("UnreadMessages")]
        public IActionResult UnreadMessages()
        {
            var values = _messageService.TGetFilteredList(x => x.IsRead == false);
            return Ok(values);
        }
    }
}