using AutoMapper;
using SistemaDivisasAPI.Mediator;
using SistemaDivisasAPI.DTO;

namespace SistemaDivisasAPI.Data
{
    public class AutoMapperPerfil : Profile
    {
        public AutoMapperPerfil()
        {
            CreateMap<LoginDTO, LoginQuery>();
            CreateMap<LoginQueryResponse, LoginResponseDTO>();
            CreateMap<ListarCuentasPesoDTO, ListarCuentaPesoQuery>();
            CreateMap<ListarCuentaPesoQueryResponse, ListarCuentasPesoResponseDTO>();
            CreateMap<ListarCuentasDolarDTO, ListarCuentaDolarQuery>();
            CreateMap<ListarCuentaDolarQueryResponse, ListarCuentasDolarResponseDTO>();
            CreateMap<ListarCuentasCriptoDTO, ListarCuentaCriptoQuery>();
            CreateMap<ListarCuentaCriptoQueryResponse, ListarCuentasCriptoResponseDTO>();
            CreateMap<VerCuentaPesoDTO, VerCuentaPesoQuery>();
            CreateMap<VerCuentaPesoQueryResponse, VerCuentaPesoResponseDTO>();
            CreateMap<VerCuentaDolarDTO, VerCuentaDolarQuery>();
            CreateMap<VerCuentaDolarQueryResponse, VerCuentaDolarResponseDTO>();
            CreateMap<VerCuentaCriptoDTO, VerCuentaCriptoQuery>();
            CreateMap<VerCuentaCriptoQueryResponse, VerCuentaCriptoResponseDTO>();
            CreateMap<CrearCuentaPesoDTO, CrearCuentaPesoQuery>();
            CreateMap<CrearCuentaDolarDTO, CrearCuentaDolarQuery>();
            CreateMap<CrearCuentaCriptoDTO, CrearCuentaCriptoQuery>();
            CreateMap<ActualizarCuentaPesoDTO, ActualizarCuentaPesoQuery>();
            CreateMap<ActualizarCuentaDolarDTO, ActualizarCuentaDolarQuery>();
            CreateMap<ActualizarCuentaCriptoDTO, ActualizarCuentaCriptoQuery>();
            CreateMap<BorrarCuentaPesoDTO, BorrarCuentaPesoQuery>();
            CreateMap<BorrarCuentaDolarDTO, BorrarCuentaDolarQuery>();
            CreateMap<BorrarCuentaCriptoDTO, BorrarCuentaCriptoQuery>();
            CreateMap<DepositoPesoDTO, DepositoPesoQuery>();
            CreateMap<DepositoDolarDTO, DepositoDolarQuery>();
            CreateMap<DepositoCriptoDTO, DepositoCriptoQuery>();
            CreateMap<ExtraccionPesoDTO, ExtraccionPesoQuery>();
            CreateMap<ExtraccionDolarDTO, ExtraccionDolarQuery>();
            CreateMap<ExtraccionCriptoDTO, ExtraccionCriptoQuery>();
            CreateMap<TransferPesoPesoDTO, TransferPesoPesoQuery>();
            CreateMap<TransferDolarDolarDTO, TransferDolarDolarQuery>();
            CreateMap<TransferCriptoCriptoDTO, TransferCriptoCriptoQuery>();
            CreateMap<ComprarDolarDTO, ComprarDolarQuery>();
            CreateMap<VenderDolarDTO, VenderDolarQuery>();
            CreateMap<ComprarCriptoDTO, ComprarCriptoQuery>();
            CreateMap<VenderCriptoDTO, VenderCriptoQuery>();
            CreateMap<VerMovimientosDTO, VerMovimientosQuery>();
            CreateMap<VerMovimientosQueryResponse, VerMovimientosResponseDTO>();
        }
    }
}
