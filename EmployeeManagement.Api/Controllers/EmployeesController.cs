using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(ISender mediator) : ControllerBase
    {
        private readonly ISender _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest req, CancellationToken ct)
        {
            var employee = await _mediator.Send(new CreateEmployeeCommand(req.Gender, req.LastName), ct);

            return Ok(employee);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeRequest req, CancellationToken ct)
        {
            await _mediator.Send(new UpdateEmployeeCommand(id, req.Gender, req.LastName), ct);

            return NoContent();
        }
    }
}
