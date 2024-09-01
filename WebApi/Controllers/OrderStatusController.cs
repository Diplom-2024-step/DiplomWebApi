using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusController(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await _orderStatusRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatus>> GetByIdAsync(Guid id)
        {
            var orderStatus = await _orderStatusRepository.GetByIdAsync(id);
            if (orderStatus == null)
                return NotFound();
            return orderStatus;
        }

        [HttpPost]
        public async Task<ActionResult<OrderStatus>> CreateAsync(OrderStatus orderStatus)
        {
            await _orderStatusRepository.CreateAsync(orderStatus);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = orderStatus.Id }, orderStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, OrderStatus orderStatus)
        {
            if (id != orderStatus.Id)
                return BadRequest();

            await _orderStatusRepository.UpdateAsync(orderStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _orderStatusRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}