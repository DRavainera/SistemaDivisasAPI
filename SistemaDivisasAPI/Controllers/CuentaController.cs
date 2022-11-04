using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDivisasAPI.DTO;
using SistemaDivisasAPI.Mediator;
using SistemaDivisasAPI.Models;


namespace SistemaDivisasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public CuentaController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("CuentaPeso/Listar")]
        public async Task<IActionResult> ListarCuentasPeso(int clienteId)
        {
            if (clienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasPeso = await _mediator.Send(new ListarCuentaPesoQuery() { ClienteId = clienteId });

            var listaCuentasPesoResponse = _mapper.Map<List<ListarCuentasPesoResponseDTO>>(listaCuentasPeso);

            if (listaCuentasPesoResponse.Count > 0)
            {
                return Ok(listaCuentasPesoResponse);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaPeso/Ver")]
        public async Task<IActionResult> VerCuentaPeso(int cuentaId)
    {
            if (cuentaId is 0)
            {
                return BadRequest();
            }

            var verCuentaPeso = await _mediator.Send(new VerCuentaPesoQuery() { CuentaId = cuentaId});

            var verCuentaPesoResponse = _mapper.Map<VerCuentaPesoResponseDTO>(verCuentaPeso);

            if (verCuentaPesoResponse == null)
            {
                return NotFound();
            }

            return Ok(verCuentaPesoResponse);
        }

        [HttpPost]
        [Route("CuentaPeso/Crear")]
        public async Task<IActionResult> CrearCuentaPeso([FromBody] CrearCuentaPesoDTO cuentaPeso)
        {
            var cuentaPesoMapper = _mapper.Map<CrearCuentaPesoQuery>(cuentaPeso);

            if (cuentaPesoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPesoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaPeso/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaPeso([FromBody] ActualizarCuentaPesoDTO cuentaPeso)
        {
            var cuentaPesoMapper = _mapper.Map<ActualizarCuentaPesoQuery>(cuentaPeso);

            if (cuentaPesoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPesoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaPeso/Borrar")]
        public async Task<IActionResult> BorrarCuentaPeso([FromBody] BorrarCuentaPesoDTO cuentaPeso)
        {
            var cuentaPesoMapper = _mapper.Map<BorrarCuentaPesoQuery>(cuentaPeso);

            if (cuentaPesoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaPesoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CuentaDolar/Listar")]
        public async Task<IActionResult> ListarCuentasDolar(int clienteId)
        {
            if (clienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasDolar = await _mediator.Send(new ListarCuentaDolarQuery() { ClienteId = clienteId });

            var listaCuentasDolarResponse = _mapper.Map<List<ListarCuentasDolarResponseDTO>>(listaCuentasDolar);

            if (listaCuentasDolarResponse.Count > 0)
            {
                return Ok(listaCuentasDolarResponse);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaDolar/Ver")]
        public async Task<IActionResult> VerCuentaDolar(int cuentaId)
        {
            if (cuentaId is 0)
            {
                return BadRequest();
            }

            var verCuentaDolar = await _mediator.Send(new VerCuentaDolarQuery() { CuentaId = cuentaId });

            var verCuentaDolarResponse = _mapper.Map<VerCuentaDolarResponseDTO>(verCuentaDolar);

            if (verCuentaDolarResponse == null)
            {
                return NotFound();
            }

            return Ok(verCuentaDolarResponse);
        }

        [HttpPost]
        [Route("CuentaDolar/Crear")]
        public async Task<IActionResult> CrearCuentaDolar([FromBody] CrearCuentaDolarDTO cuentaDolar)
        {
            var cuentaDolarMapper = _mapper.Map<CrearCuentaDolarQuery>(cuentaDolar);

            if (cuentaDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolarMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaDolar/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaDolar([FromBody] ActualizarCuentaDolarDTO cuentaDolar)
        {
            var cuentaDolarMapper = _mapper.Map<ActualizarCuentaDolarQuery>(cuentaDolar);

            if (cuentaDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolarMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaDolar/Borrar")]
        public async Task<IActionResult> BorrarCuentaDolar([FromBody] BorrarCuentaDolarDTO cuentaDolar)
        {
            var cuentaDolarMapper = _mapper.Map<BorrarCuentaDolarQuery>(cuentaDolar);

            if (cuentaDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaDolarMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("CuentaCripto/Listar")]
        public async Task<IActionResult> ListarCuentasCripto(int clienteId)
        {
            if (clienteId is 0)
            {
                return BadRequest();
            }

            var listaCuentasCripto = await _mediator.Send(new ListarCuentaCriptoQuery() { ClienteId = clienteId });

            var listaCuentasCriptoResponse = _mapper.Map<List<ListarCuentasCriptoResponseDTO>>(listaCuentasCripto);

            if (listaCuentasCriptoResponse.Count > 0)
            {
                return Ok(listaCuentasCriptoResponse);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CuentaCripto/Ver")]
        public async Task<IActionResult> VerCuentaCripto(int cuentaId)
        {
            if (cuentaId is 0)
            {
                return BadRequest();
            }

            var verCuentaCripto = await _mediator.Send(new VerCuentaCriptoQuery() { CuentaId = cuentaId });

            var verCuentaCriptoResponse = _mapper.Map<VerCuentaCriptoResponseDTO>(verCuentaCripto);

            if (verCuentaCriptoResponse == null)
            {
                return NotFound();
            }

            return Ok(verCuentaCriptoResponse);
        }

        [HttpPost]
        [Route("CuentaCripto/Crear")]
        public async Task<IActionResult> CrearCuentaCripto([FromBody] CrearCuentaCriptoDTO cuentaCripto)
        {
            var cuentaCriptoMapper = _mapper.Map<CrearCuentaPesoQuery>(cuentaCripto);

            if (cuentaCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCriptoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaCripto/Actualizar")]
        public async Task<IActionResult> ActualizarCuentaCripto([FromBody] ActualizarCuentaCriptoDTO cuentaCripto)
        {
            var cuentaCriptoMapper = _mapper.Map<ActualizarCuentaCriptoQuery>(cuentaCripto);

            if (cuentaCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCriptoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("CuentaCripto/Borrar")]
        public async Task<IActionResult> BorrarCuentaCripto([FromBody] BorrarCuentaCriptoDTO cuentaCripto)
        {
            var cuentaCriptoMapper = _mapper.Map<BorrarCuentaCriptoQuery>(cuentaCripto);

            if (cuentaCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(cuentaCriptoMapper);

            if (respuesta)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("CuentaPeso/Deposito")]
        public async Task<IActionResult> DepositoCuentaPeso([FromBody] DepositoPesoDTO depositoPeso)
        {
            var depositoPesoMapper = _mapper.Map<DepositoPesoQuery>(depositoPeso);

            if (depositoPesoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoPesoQuery()
            {
                IdCuenta = depositoPesoMapper.IdCuenta,
                Saldo = depositoPesoMapper.Saldo
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
        public async Task<IActionResult> ExtraccionCuentaPeso([FromBody] ExtraccionPesoDTO extraccionPeso)
        {
            var extraccionPesoMapper = _mapper.Map<ExtraccionPesoQuery>(extraccionPeso);

            if (extraccionPesoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionPesoQuery()
            {
                IdCuenta = extraccionPesoMapper.IdCuenta,
                Saldo = extraccionPesoMapper.Saldo
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
        public async Task<IActionResult> DepositoCuentaDolar([FromBody] DepositoDolarDTO depositoDolar)
        {
            var depositoDolarMapper = _mapper.Map<DepositoDolarQuery>(depositoDolar);

            if (depositoDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoDolarQuery()
            {
                IdCuenta = depositoDolarMapper.IdCuenta,
                Saldo = depositoDolarMapper.Saldo
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
        public async Task<IActionResult> ExtraccionCuentaDolar([FromBody] ExtraccionDolarDTO extraccionDolar)
        {
            var extraccionDolarMapper = _mapper.Map<ExtraccionDolarQuery>(extraccionDolar);

            if (extraccionDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionDolarQuery()
            {
                IdCuenta = extraccionDolarMapper.IdCuenta,
                Saldo = extraccionDolarMapper.Saldo
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
        public async Task<IActionResult> DepositoCuentaCripto([FromBody] DepositoCriptoDTO depositoCripto)
        {
            var depositoCriptoMapper = _mapper.Map<DepositoCriptoQuery>(depositoCripto);

            if (depositoCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new DepositoCriptoQuery()
            {
                IdCuenta = depositoCriptoMapper.IdCuenta,
                Saldo = depositoCriptoMapper.Saldo
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
        public async Task<IActionResult> ExtraccionCuentaCripto([FromBody] ExtraccionCriptoDTO extraccionCripto)
        {
            var extraccionCriptoMapper = _mapper.Map<ExtraccionCriptoQuery>(extraccionCripto);

            if (extraccionCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ExtraccionCriptoQuery()
            {
                IdCuenta = extraccionCriptoMapper.IdCuenta,
                Saldo = extraccionCriptoMapper.Saldo
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
        public async Task<IActionResult> TransferirPesoPeso([FromBody] TransferPesoPesoDTO transferPesoPeso)
        {
            var transferPesoPesoMapper = _mapper.Map<TransferPesoPesoQuery>(transferPesoPeso);

            if (transferPesoPesoMapper == null)
            {
                return BadRequest();
            }

             var respuesta = await _mediator.Send(new TransferPesoPesoQuery()
            {
                IdCuentaOrigen = transferPesoPesoMapper.IdCuentaOrigen,
                IdCuentaDestino = transferPesoPesoMapper.IdCuentaDestino,
                Saldo = transferPesoPesoMapper.Saldo
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
        public async Task<IActionResult> TransferirDolarDolar([FromBody] TransferDolarDolarDTO transferDolarDolar)
        {
            var transferDolarDolarMapper = _mapper.Map<TransferDolarDolarQuery>(transferDolarDolar);

            if (transferDolarDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new TransferDolarDolarQuery()
            {
                IdCuentaOrigen = transferDolarDolarMapper.IdCuentaOrigen,
                IdCuentaDestino = transferDolarDolarMapper.IdCuentaDestino,
                Saldo = transferDolarDolarMapper.Saldo
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
        public async Task<IActionResult> TransferirCriptoCripto([FromBody] TransferCriptoCriptoDTO transferCriptoCripto)
        {
            var transferCriptoCriptoMapper = _mapper.Map<TransferCriptoCriptoQuery>(transferCriptoCripto);

            if (transferCriptoCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new TransferCriptoCriptoQuery()
            {
                IdCuentaOrigen = transferCriptoCriptoMapper.IdCuentaOrigen,
                IdCuentaDestino = transferCriptoCriptoMapper.IdCuentaDestino,
                Saldo = transferCriptoCriptoMapper.Saldo
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
        public async Task<IActionResult> ComprarDolar([FromBody] ComprarDolarDTO comprarDolar)
        {
            var comprarDolarMapper = _mapper.Map<ComprarDolarQuery>(comprarDolar);

            if (comprarDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ComprarDolarQuery()
            {
                CuentaPesoId = comprarDolarMapper.CuentaPesoId,
                CuentaDolarId = comprarDolarMapper.CuentaDolarId,
                Saldo = comprarDolarMapper.Saldo
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
        public async Task<IActionResult> VenderDolar([FromBody] VenderDolarDTO venderDolar)
        {
            var venderDolarMapper = _mapper.Map<VenderDolarQuery>(venderDolar);

            if (venderDolarMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new VenderDolarQuery()
            {
                CuentaPesoId = venderDolarMapper.CuentaPesoId,
                CuentaDolarId = venderDolarMapper.CuentaDolarId,
                Saldo = venderDolarMapper.Saldo
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
        public async Task<IActionResult> ComprarCripto([FromBody] ComprarCriptoDTO comprarCripto)
        {
            var comprarCriptoMapper = _mapper.Map<ComprarCriptoQuery>(comprarCripto);

            if (comprarCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new ComprarCriptoQuery()
            {
                CuentaCriptoId = comprarCriptoMapper.CuentaCriptoId,
                CuentaDolarId = comprarCriptoMapper.CuentaDolarId,
                Saldo = comprarCriptoMapper.Saldo
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
            var venderCriptoMapper = _mapper.Map<VenderCriptoQuery>(venderCripto);

            if (venderCriptoMapper == null)
            {
                return BadRequest();
            }

            var respuesta = await _mediator.Send(new VenderCriptoQuery()
            {
                CuentaCriptoId = venderCriptoMapper.CuentaCriptoId,
                CuentaDolarId = venderCriptoMapper.CuentaDolarId,
                Saldo = venderCriptoMapper.Saldo
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
        public async Task<IActionResult> VerMovimientos(string numCuenta)
        {
            if (numCuenta is null)
            {
                return BadRequest();
            }

            var listaMovimientos = await _mediator.Send(new VerMovimientosQuery() { NumCuenta = numCuenta });

            var listaMovimientosResponse = _mapper.Map<List<VerMovimientosResponseDTO>>(listaMovimientos);

            if (listaMovimientosResponse.Count > 0)
            {
                return Ok(listaMovimientosResponse);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
