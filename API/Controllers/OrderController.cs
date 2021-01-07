using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _unitOfWork.Order.ListAllAsync();
            return Ok(orders);
        }

        [HttpGet("GetOrderById/{id}",Name ="OrderDetails")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(Order model)
        {
            var order = await _unitOfWork.Order.Create(model);
            return CreatedAtRoute("OrderDetails", new { id = order.Id }, order);
        }

        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(string id, Order model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            throw new NotImplementedException();
        }
    }
}
