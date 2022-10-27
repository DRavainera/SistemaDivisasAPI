using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Mediator;


namespace SistemaDivisasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("CuentaPeso/Listar")]
        public async Task<IActionResult> ListarCuentasPeso([FromBody] ListarCuentaPesoQuery clienteId)
        {
            if (clienteId.ClienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasPeso = await _mediator.Send(new ListarCuentaPesoQuery() { ClienteId = clienteId.ClienteId});

            if (listaCuentasPeso.Count > 0)
            {
                return Ok(listaCuentasPeso);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaPeso/Ver")]
        public async Task<IActionResult> VerCuentaPeso([FromBody] VerCuentaPesoQuery cuentaId)
    {
            if (cuentaId.CuentaId is 0)
            {
                return BadRequest();
            }

            var cuentaPeso = await _mediator.Send(new VerCuentaPesoQuery() { CuentaId = cuentaId.CuentaId});

            if (cuentaPeso == null)
            {
                return NotFound();
            }

            return Ok(cuentaPeso);
        }

        [HttpPost]
        [Route("CuentaPeso/Crear")]
        public async Task<IActionResult> CrearCuentaPeso([FromBody] CrearCuentaPesoQuery cuentaPeso)
        {
            if (cuentaPeso == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPeso);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaPeso/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaPeso([FromBody] ActualizarCuentaPesoQuery cuentaPeso)
        {
            if (cuentaPeso == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPeso);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaPeso/Borrar")]
        public async Task<IActionResult> BorrarCuentaPeso([FromBody] BorrarCuentaPesoQuery cuentaPeso)
        {
            if (cuentaPeso == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPeso);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CuentaDolar/Listar")]
        public async Task<IActionResult> ListarCuentasDolar([FromBody] ListarCuentaDolarQuery clienteId)
        {
            if (clienteId.ClienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasDolar = await _mediator.Send(new ListarCuentaDolarQuery() { ClienteId = clienteId.ClienteId });

            if (listaCuentasDolar.Count > 0)
            {
                return Ok(listaCuentasDolar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaDolar/Ver")]
        public async Task<IActionResult> VerCuentaDolar([FromBody] VerCuentaDolarQuery cuentaId)
        {
            if (cuentaId.CuentaId is 0)
            {
                return BadRequest();
            }

            var cuentaDolar = await _mediator.Send(new VerCuentaDolarQuery() { CuentaId = cuentaId.CuentaId });

            if (cuentaDolar == null)
            {
                return NotFound();
            }

            return Ok(cuentaDolar);
        }

        [HttpPost]
        [Route("CuentaDolar/Crear")]
        public async Task<IActionResult> CrearCuentaDolar([FromBody] CrearCuentaDolarQuery cuentaDolar)
        {
            if (cuentaDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolar);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaDolar/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaDolar([FromBody] ActualizarCuentaDolarQuery cuentaDolar)
        {
            if (cuentaDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolar);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaDolar/Borrar")]
        public async Task<IActionResult> BorrarCuentaDolar([FromBody] BorrarCuentaDolarQuery cuentaDolar)
        {
            if (cuentaDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolar);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CuentaCripto/Listar")]
        public async Task<IActionResult> ListarCuentasCripto([FromBody] ListarCuentaCriptoQuery clienteId)
        {
            if (clienteId.ClienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasCripto = await _mediator.Send(new ListarCuentaCriptoQuery() { ClienteId = clienteId.ClienteId });

            if (listaCuentasCripto.Count > 0)
            {
                return Ok(listaCuentasCripto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaCripto/Ver")]
        public async Task<IActionResult> VerCuentaCripto([FromBody] VerCuentaCriptoQuery cuentaId)
        {
            if (cuentaId.CuentaId is 0)
            {
                return BadRequest();
            }

            var cuentaCripto = await _mediator.Send(new VerCuentaCriptoQuery() { CuentaId = cuentaId.CuentaId });

            if (cuentaCripto == null)
            {
                return NotFound();
            }

            return Ok(cuentaCripto);
        }

        [HttpPost]
        [Route("CuentaCripto/Crear")]
        public async Task<IActionResult> CrearCuentaCripto([FromBody] CrearCuentaCriptoQuery cuentaCripto)
        {
            if (cuentaCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCripto);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaCripto/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaCripto([FromBody] ActualizarCuentaCriptoQuery cuentaCripto)
        {
            if (cuentaCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCripto);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaCripto/Borrar")]
        public async Task<IActionResult> BorrarCuentaCripto([FromBody] BorrarCuentaCriptoQuery cuentaCripto)
        {
            if (cuentaCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCripto);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaPeso/Deposito")]
        public async Task<IActionResult> DepositoCuentaPeso([FromBody] DepositoPesoQuery depositoPeso)
        {
            if (depositoPeso == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoPesoQuery()
            {
                IdCuenta = depositoPeso.IdCuenta,
                Saldo = depositoPeso.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaPeso/Extraccion")]
        public async Task<IActionResult> ExtraccionCuentaPeso([FromBody] ExtraccionPesoQuery extraccionPeso)
        {
            if (extraccionPeso == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionPesoQuery()
            {
                IdCuenta = extraccionPeso.IdCuenta,
                Saldo = extraccionPeso.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaDolar/Deposito")]
        public async Task<IActionResult> DepositoCuentaDolar([FromBody] DepositoDolarQuery depositoDolar)
        {
            if (depositoDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoDolarQuery()
            {
                IdCuenta = depositoDolar.IdCuenta,
                Saldo = depositoDolar.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaDolar/Extraccion")]
        public async Task<IActionResult> ExtraccionCuentaDolar([FromBody] ExtraccionDolarQuery extraccionDolar)
        {
            if (extraccionDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionDolarQuery()
            {
                IdCuenta = extraccionDolar.IdCuenta,
                Saldo = extraccionDolar.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaCripto/Deposito")]
        public async Task<IActionResult> DepositoCuentaCripto([FromBody] DepositoCriptoQuery depositoCripto)
        {
            if (depositoCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoCriptoQuery()
            {
                IdCuenta = depositoCripto.IdCuenta,
                Saldo = depositoCripto.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaCripto/Extraccion")]
        public async Task<IActionResult> ExtraccionCuentaCripto([FromBody] ExtraccionCriptoQuery extraccionCripto)
        {
            if (extraccionCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionCriptoQuery()
            {
                IdCuenta = extraccionCripto.IdCuenta,
                Saldo = extraccionCripto.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaPeso/TransferirAPeso")]
        public async Task<IActionResult> TransferirPesoPeso([FromBody] TransferPesoPesoQuery transferPesoPeso)
        {
            if (transferPesoPeso == null)
            {
                return BadRequest();
            }

             var respuesta = await _mediator.Send(new TransferPesoPesoQuery()
            {
                IdCuentaOrigen = transferPesoPeso.IdCuentaOrigen,
                IdCuentaDestino = transferPesoPeso.IdCuentaDestino,
                Saldo = transferPesoPeso.Saldo
             });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaDolar/TransferirADolar")]
        public async Task<IActionResult> TransferirDolarDolar([FromBody] TransferDolarDolarQuery transferDolarDolar)
        {
            if (transferDolarDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new TransferDolarDolarQuery()
            {
                IdCuentaOrigen = transferDolarDolar.IdCuentaOrigen,
                IdCuentaDestino = transferDolarDolar.IdCuentaDestino,
                Saldo = transferDolarDolar.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaCripto/TransferirACripto")]
        public async Task<IActionResult> TransferirCriptoCripto([FromBody] TransferCriptoCriptoQuery transferCriptoCripto)
        {
            if (transferCriptoCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new TransferCriptoCriptoQuery()
            {
                IdCuentaOrigen = transferCriptoCripto.IdCuentaOrigen,
                IdCuentaDestino = transferCriptoCripto.IdCuentaDestino,
                Saldo = transferCriptoCripto.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaPeso/ComprarDolar")]
        public async Task<IActionResult> ComprarDolar([FromBody] ComprarDolarQuery comprarDolar)
        {
            if (comprarDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ComprarDolarQuery()
            {
                CuentaPesoId = comprarDolar.CuentaPesoId,
                CuentaDolarId = comprarDolar.CuentaDolarId,
                Saldo = comprarDolar.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaDolar/VenderDolar")]
        public async Task<IActionResult> VenderDolar([FromBody] VenderDolarQuery venderDolar)
        {
            if (venderDolar == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new VenderDolarQuery()
            {
                CuentaPesoId = venderDolar.CuentaPesoId,
                CuentaDolarId = venderDolar.CuentaDolarId,
                Saldo = venderDolar.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        [Route("CuentaDolar/ComprarCripto")]
        public async Task<IActionResult> ComprarCripto([FromBody] ComprarCriptoQuery comprarCripto)
        {
            if (comprarCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ComprarCriptoQuery()
            {
                CuentaCriptoId = comprarCripto.CuentaCriptoId,
                CuentaDolarId = comprarCripto.CuentaDolarId,
                Saldo = comprarCripto.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("CuentaCripto/VenderCripto")]
        public async Task<IActionResult> VenderCripto([FromBody] VenderCriptoQuery venderCripto)
        {
            if (venderCripto == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new VenderCriptoQuery()
            {
                CuentaCriptoId = venderCripto.CuentaCriptoId,
                CuentaDolarId = venderCripto.CuentaDolarId,
                Saldo = venderCripto.Saldo
            });

            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Movimientos/Ver")]
        public async Task<IActionResult> VerMovimientos([FromBody] VerMovimientosQuery numCuenta)
        {
            if (numCuenta.NumCuenta is null)
            {
                return BadRequest();
            }

            var listaMovimientos = await _mediator.Send(new VerMovimientosQuery() { NumCuenta = numCuenta.NumCuenta });

            if (listaMovimientos.Count > 0)
            {
                return Ok(listaMovimientos);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
