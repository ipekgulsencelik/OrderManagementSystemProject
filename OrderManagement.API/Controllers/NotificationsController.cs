using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Business.Abstract;
using OrderManagement.DTO.DTOs.NotificationDTOs;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController(INotificationService _notificationService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var values = _notificationService.TGetList();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.TDelete(id);
            return Ok("Bildirim Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            var newNotification = _mapper.Map<Notification>(createNotificationDTO);
            _notificationService.TCreate(newNotification);
            return Ok("Bildirim Oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDTO);
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi");
        }

        [HttpGet("UnreadNotificationCount")]
        public IActionResult UnreadNotificationCount()
        {
            var value = _notificationService.TUnreadNotificationCount();
            return Ok(value);
        }

        [HttpGet("ReadNotificationCount")]
        public IActionResult ReadNotificationCount()
        {
            var value = _notificationService.TReadNotificationCount();
            return Ok(value);
        }

        [HttpGet("GetUnreadNotifications")]
        public IActionResult GetUnreadNotifications()
        {
            var values = _notificationService.TGetFilteredList(x => x.Status == false);
            return Ok(values);
        }

        [HttpGet("MarkAsRead/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            _notificationService.TMarkAsRead(id);
            return Ok("Okundu Olarak İşaretlendi");
        }

        [HttpGet("MarkAsUnread/{id}")]
        public IActionResult MarkAsUnread(int id)
        {
            _notificationService.TMarkAsUnread(id);
            return Ok("Okunmadı Olarak İşaretlendi");
        }
    }
}