﻿using E_commerceAPI.BL.Dtos.Order;
using E_commerceAPI.BL.Managers.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace E_commerceAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        [Authorize]
        [HttpPost("place-order")]
        public ActionResult PlaceOrder([FromBody] PlaceOrderRequestDto request)
        {
            try
            {
              _orderManager.PlaceOrder(request);
                return Ok("Done! Order place Successflly");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("order-history")]
        public ActionResult GetOrderHistory()
        {
            try
            {
                IEnumerable<OrderDto> orderHistory = _orderManager.GetOrderHistory();
                return Ok(orderHistory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
